using FunlandV3.Areas.Customer.Data.Data;
using FunlandV3.Areas.Customer.Models;
using FunlandV3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace FunlandV3.Areas.Customer.Controllers
{
    [Authorize]
    [Area("Customer")]
    public class BookingController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public BookingController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Confirmation()
        {
            return View();
        }

        

        [HttpGet]
        public async Task<IActionResult> DisplayBookings()
        {
            var userId = User.Identity.Name;

            var bookings = await _context.Bookings
                                .Where(b => userId == userId).ToListAsync();

            var bookingDetails = new List<BookingDetailView>();

            foreach (var booking in bookings)
            {
                string roomName = "";
                switch (booking.BookingType)
                {
                    case (int)enumBookingType.Game:
                        var game = await _context.Games.FirstOrDefaultAsync(g => g.GameId == booking.RoomId);
                        if (game != null)
                            roomName = game.Name;
                        break;
                    case (int)enumBookingType.Ammenity:
                        var pool = await _context.Amenities.FirstOrDefaultAsync(g => g.AmenityId == booking.RoomId);
                        if (pool != null)
                            roomName = pool.Name;
                        break;
                    case (int)enumBookingType.PartyRoom:
                        var party = await _context.PartyRooms.FirstOrDefaultAsync(g => g.PartyRoomId == booking.RoomId);
                        if (party != null)
                            roomName = party.Name;
                        break;
                }



                bookingDetails.Add(new BookingDetailView
                {
                    BookingDate = booking.BookingDate,
                    RoomName = roomName,
                    BookingType = booking.BookingType,
                    BookingId = booking.BookingID,
                    StartTime = booking.StartTime,
                    EndTime = booking.EndTime
                });
            }
            // Pass the amenityId to the View if necessary            
            return View(bookingDetails);
        }


        [HttpGet("Customer/Booking/BookEdit/{BookingId}")]
        public async Task<IActionResult> BookEdit(int BookingId)
        {
            var userId = User.Identity.Name;

            var booking = await _context.Bookings
                                .Where(b => b.BookingID == BookingId).FirstOrDefaultAsync();


            
            // Pass the amenityId to the View if necessary            
            return View(booking);
        }

        // GET: Bookings/BookAmenity
        [HttpGet]
        public IActionResult Book(int RoomId, int BookingType)
        {
            //we create a new booking model so we can pass the roomid and booking type through.
            Booking booking = new Booking();
            // Pass the amenityId to the View if necessary
            booking.RoomId = RoomId;
            booking.BookingType = BookingType;
            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Book([Bind("BookingID,BookingType,BookingDate,StartTime,EndTime,Duration,RoomId,Age,NumberOfKids,KidsAgeConfirmed,RequiredParentsConfirmed")] Booking booking, int BookingType, int RoomId)
        {
            Console.WriteLine($"RoomId: {RoomId}");
            Console.WriteLine($"BookingTypeID: {BookingType}");

            // Check if the booking type is Ammenity and RoomId is 1
            if (BookingType == (int)enumBookingType.Ammenity && RoomId == 1)
            {
                // Log the model state errors
                if (!ModelState.IsValid)
                {
                    foreach (var state in ModelState)
                    {
                        foreach (var error in state.Value.Errors)
                        {
                            Console.WriteLine($"Error in {state.Key}: {error.ErrorMessage}");
                        }
                    }
                    return View(booking);
                }
            }
            else
            {
                // Remove validation for fields not required for other booking types
                ModelState.Remove("Age");
                ModelState.Remove("NumberOfKids");
                ModelState.Remove("KidsAgeConfirmed");
                ModelState.Remove("RequiredParentsConfirmed");
            }


            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                booking.UserID = user.Id;
                booking.CreatedOn = DateTime.Now;
                booking.BookingType = BookingType;
                // Check booking time restrictions                
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return View("Confirmation", booking);
            }
            // Return a view or redirect as needed
            return View(booking);
        }


        [HttpPost]
        public async Task<IActionResult> BookUpdate([Bind("BookingID,BookingType,BookingDate,StartTime,EndTime,Duration,RoomId,Age,NumberOfKids,KidsAgeConfirmed,RequiredParentsConfirmed")] Booking booking, int BookingType, int RoomId, int BookingId)
        {
            var user = await _userManager.GetUserAsync(User);
            var existingBooking = await _context.Bookings.FindAsync(BookingId);

            if (existingBooking.BookingType == (int)enumBookingType.Game ||
                existingBooking.BookingType == (int)enumBookingType.PartyRoom)
            {
                ModelState.Remove("Age");
                ModelState.Remove("NumberOfKids");
            }

            if (ModelState.IsValid)
            {                
                if (existingBooking != null)
                {
                    // Update existing booking
                    existingBooking.UserID = user.Id;
                    existingBooking.BookingType = BookingType;
                    existingBooking.BookingDate = booking.BookingDate;
                    existingBooking.CreatedOn = DateTime.Now; // Or use the original CreatedOn if you don't want to update it
                    existingBooking.StartTime = booking.StartTime;
                    existingBooking.EndTime = booking.EndTime;
                    // Check booking time restrictions                
                    existingBooking.RoomId = booking.RoomId;
                    existingBooking.Age = booking.Age;
                    existingBooking.NumberOfKids = booking.NumberOfKids;
                    existingBooking.KidsAgeConfirmed = booking.KidsAgeConfirmed;
                    existingBooking.RequiredParentsConfirmed = booking.RequiredParentsConfirmed;
                    // Save updated booking
                    _context.Update(existingBooking);
                    await _context.SaveChangesAsync();
                    return View("Confirmation", existingBooking);
                }               
            }
            // Return a view or redirect as needed
            return View("BookEdit",existingBooking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            return RedirectToAction("DisplayBookings"); // Redirect back to the list after deletion
        }

        // GET: Bookings/Confirmation
        public async Task<IActionResult> Confirmation(int bookingId)
        {
            var booking = await _context.Bookings
                .FirstOrDefaultAsync(b => b.BookingID == bookingId);

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }


        
        
        


    }
}
