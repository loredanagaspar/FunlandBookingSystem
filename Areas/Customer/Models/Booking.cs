using FunlandV3.Areas.Customer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunlandV3.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [Required]
        [DisplayName("Book Facility")]
        public int BookingType { get; set; }        
        public int? RoomId { get; set; }

        [Required]        
        [DateInFuture(DaysInFuture = 21, ErrorMessage = "The Booking date must be at least three weeks in the future.")]
        [DisplayName("Booking Date")]
        public DateTime BookingDate { get; set; }

        [DisplayName("Booking Start Time")]
        [Required(ErrorMessage ="Start Time is Required")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage ="End Time is Required")]
        [DisplayName("Booking End Time")]
        [EndTimeGreaterThanStartTimeAttribute("StartTime", ErrorMessage = "End time must be after the start time!")]
        [BookingTimeWithinOpeningHours(ErrorMessage = "Booking time is outside the opening hours for the selected facility.")]
        public DateTime EndTime { get; set; }

        [Required]
        [DisplayName("Booking Duration")]
        [MaxDurationForBookingType(amenityMaxHours: 5, gameMaxHours: 3, partyRoomMaxHours: 3, ErrorMessage = "The booing duration exceeds the allowed time!")]
        public TimeSpan Duration
        {
            get
            {
                return EndTime - StartTime;  // Calculate duration based on EndTime and StartTime
            }            
        }

        [Required(ErrorMessage = "Age is required")]
        [DisplayName("Your Age")]
        [Range(1, 120, ErrorMessage = "Please enter a valid age")]
        public int Age { get; set; }

        [DisplayName("Number of Kids")]
        [RequiredIf("RoomId", 1, ErrorMessage = "Number of kids is required for kids pool.")]
        [Range(1, 15, ErrorMessage = "Number of kids must be between 1 and 15.")]
        public int NumberOfKids { get; set; }

        [DisplayName("Confirm the range of age is between 1 and 8 years")]
        [RequiredIf("RoomId", 1, ErrorMessage = "Confirmation of kids' ages is required for kids pool.")]
        public bool KidsAgeConfirmed { get; set; }

        [DisplayName("Confirm parental suppervision - 1 parent for 3 kids")]
        [RequiredIf("RoomId", 1, ErrorMessage = "Confirmation of required number of parents is required for kids pool.")]
        public bool RequiredParentsConfirmed { get; set; }

        [ForeignKey("UserID")]
        [ValidateNever]
        [HiddenInput(DisplayValue = false)]
        public string UserID { get; set; }
        public DateTime CreatedOn { get; set; }
        
    }

    public class DateInFutureAttribute : ValidationAttribute 
    {
        public int DaysInFuture { get; set; } = 21; // Default to 3 weeks

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var selectedDate = (DateTime)value;

            if (selectedDate < DateTime.Now.AddDays(DaysInFuture))
            {
                return new ValidationResult($"The selected date must be at least {DaysInFuture / 7} weeks in the future.");
            }

            return ValidationResult.Success;
        }
    }

    // Custom Validation Attribute
    public class EndTimeGreaterThanStartTimeAttribute : ValidationAttribute
    {
        private readonly string _startTimePropertyName;

        public EndTimeGreaterThanStartTimeAttribute(string startTimePropertyName)
        {
            _startTimePropertyName = startTimePropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var endTime = (DateTime)value;

            // Get the StartTime value from the model
            var startTimeProperty = validationContext.ObjectType.GetProperty(_startTimePropertyName);
            if (startTimeProperty == null)
            {
                return new ValidationResult($"Unknown property: {_startTimePropertyName}");
            }

            var startTime = (DateTime)startTimeProperty.GetValue(validationContext.ObjectInstance);

            if (endTime < startTime)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }

    public class MaxDurationForBookingTypeAttribute : ValidationAttribute
    {
        private readonly int _amenityMaxHours;
        private readonly int _gameMaxHours;
        private readonly int _partyRoomMaxHours;

        public MaxDurationForBookingTypeAttribute(int amenityMaxHours, int gameMaxHours, int partyRoomMaxHours)
        {
            _amenityMaxHours = amenityMaxHours;
            _gameMaxHours = gameMaxHours;
            _partyRoomMaxHours = partyRoomMaxHours;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string bookTypeText = "";
            var booking = (Booking)validationContext.ObjectInstance;
            if (value is TimeSpan duration)
            {
                int maxAllowedHours = 0;

                switch ((enumBookingType)booking.BookingType)
                {
                    case enumBookingType.Ammenity:
                        maxAllowedHours = _amenityMaxHours;
                        bookTypeText = "Swimming Pool";
                        break;
                    case enumBookingType.Game:
                        maxAllowedHours = _gameMaxHours;
                        bookTypeText = "Game Room";
                        break;
                    case enumBookingType.PartyRoom:
                        maxAllowedHours = _partyRoomMaxHours;
                        bookTypeText = "Party Room";
                        break;
                    default:
                        return new ValidationResult("Invalid booking type");
                }

                if (duration.TotalHours > maxAllowedHours)
                {
                    return new ValidationResult($"The maximum allowed duration for {bookTypeText} is {maxAllowedHours} hours.");
                }
            }

            return ValidationResult.Success;
        }
    }

    public class BookingTimeWithinOpeningHoursAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var booking = (Booking)validationContext.ObjectInstance;

            DateTime startTime = booking.StartTime;
            DateTime endTime = booking.EndTime;
            var bookingType = booking.BookingType;

            switch ((enumBookingType)bookingType)
            {
                case enumBookingType.Ammenity:
                    if (startTime.TimeOfDay < TimeSpan.FromHours(8) || endTime.TimeOfDay > TimeSpan.FromHours(20))
                    {
                        return new ValidationResult("Amenities are open from 8 AM to 8 PM.");
                    }
                    break;

                case enumBookingType.Game:
                    if (startTime.TimeOfDay < TimeSpan.FromHours(10) || endTime.TimeOfDay > TimeSpan.FromHours(19))
                    {
                        return new ValidationResult("Gaming facilities are open from 10 AM to 7 PM.");
                    }
                    break;

                case enumBookingType.PartyRoom:
                    if (startTime.TimeOfDay < TimeSpan.FromHours(7) || endTime.TimeOfDay > TimeSpan.FromHours(23))
                    {
                        return new ValidationResult("Party rooms are available from 7 AM to 11 PM.");
                    }
                    break;

                default:
                    return new ValidationResult("Invalid booking type.");
            }

            return ValidationResult.Success;
        }
    }

    public class RequiredIfAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;
        private readonly object _comparisonValue;

        public RequiredIfAttribute(string comparisonProperty, object comparisonValue)
        {
            _comparisonProperty = comparisonProperty;
            _comparisonValue = comparisonValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
            if (property == null)
                throw new ArgumentException("Property with this name not found");

            var comparisonValue = property.GetValue(validationContext.ObjectInstance);

            if (comparisonValue != null && comparisonValue.Equals(_comparisonValue))
            {
                if (value == null || (value is bool && !(bool)value))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }



    public enum enumBookingType
    {
        Ammenity = 1,
        Game = 2,
        PartyRoom = 3,

    }
}
