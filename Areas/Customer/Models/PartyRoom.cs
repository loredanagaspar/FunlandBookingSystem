using System.ComponentModel.DataAnnotations;

namespace FunlandV3.Models
{
    public class PartyRoom
    {
        [Key]
        public int PartyRoomId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Block is required.")]
        [StringLength(50, ErrorMessage = "Block cannot exceed 50 characters.")]
        public string Block { get; set; }

        [Required(ErrorMessage = "Opening time is required.")]
        public TimeSpan OpeningTime { get; set; }

        [Required(ErrorMessage = "Closing time is required.")]
        public TimeSpan ClosingTime { get; set; }

        [Required(ErrorMessage = "Floor is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Floor must be a positive number.")]
        public int Floor { get; set; }

        [Required(ErrorMessage = "Room number is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Room number must be a positive number.")]
        public int RoomNumber { get; set; }

        public string ImageUrl { get; set; }
    }
}
