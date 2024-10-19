namespace FunlandV3.Models
{
    public class BookingDetailView
    {
        public DateTime BookingDate { get; set; }
        public string RoomName { get; set; }  // The name of the room (Game, Amenity, or PartyRoom)
        public int BookingType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int BookingId { get; set; }  // For possible actions like "Details"
    }

}
