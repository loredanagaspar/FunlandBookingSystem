using System.ComponentModel.DataAnnotations;

namespace FunlandV3.Models
{
    public class PartyRoom
    {
        [Key]
        public int GameId { get; set; }

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

        [Required(ErrorMessage = "Max booking hours is required.")]
        [Range(1, 24, ErrorMessage = "Max booking hours must be between 1 and 24.")]
        public int MaxBookingHours { get; set; }
    }
}
