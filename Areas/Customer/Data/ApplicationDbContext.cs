using FunlandV3.Areas.Customer.Models;
using FunlandV3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FunlandV3.Areas.Customer.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<PartyRoom> PartyRooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Amenity>().HasData(
                new Amenity { AmenityId = 1, Name = "Kids Pool", Block = "Amenities Block", OpeningTime = new TimeSpan(8, 0, 0), ClosingTime = new TimeSpan(20, 0, 0), PoolType = "Kids", MaxBookingHours = 5, RequiresSupervision = true, AgeRestriction = "1-8", ImageUrl = "/Images/SwimmingPool.jpg" },
                new Amenity { AmenityId = 2, Name = "Adult Pool", Block = "Amenities Block", OpeningTime = new TimeSpan(8, 0, 0), ClosingTime = new TimeSpan(20, 0, 0), PoolType = "Adult", MaxBookingHours = 5, RequiresSupervision = true, AgeRestriction = "9+", ImageUrl = "/Images/KidsSwimmingPool.jpg" }
                );
            modelBuilder.Entity<Game>().HasData(
                new Game { GameId = 1, Name = "Laser Tag", Block = "Gaming Block", OpeningTime = new TimeSpan(10, 0, 0), ClosingTime = new TimeSpan(19, 0, 0), MaxBookingHours = 3, ImageUrl = "/Images/LaserTag.jpg" },
                new Game { GameId = 2, Name = "Bowling", Block = "Gaming Block", OpeningTime = new TimeSpan(10, 0, 0), ClosingTime = new TimeSpan(19, 0, 0), MaxBookingHours = 3, ImageUrl = "/Images/Bowling.png" }
                );

            // Seed Party Rooms
            modelBuilder.Entity<PartyRoom>().HasData(
                new PartyRoom { PartyRoomId = 1, Name = "Room A", Block = "Party Block", OpeningTime = new TimeSpan(7, 0, 0), ClosingTime = new TimeSpan(23, 0, 0), Floor = 1, RoomNumber = 1, ImageUrl = "/Images/PartyRoom1.jfif" },
                new PartyRoom { PartyRoomId = 2, Name = "Room B", Block = "Party Block", OpeningTime = new TimeSpan(7, 0, 0), ClosingTime = new TimeSpan(23, 0, 0), Floor = 1, RoomNumber = 2, ImageUrl = "/Images/PartyRoom2.JPEG" },
                new PartyRoom { PartyRoomId = 3, Name = "Room C", Block = "Party Block", OpeningTime = new TimeSpan(7, 0, 0), ClosingTime = new TimeSpan(23, 0, 0), Floor = 2, RoomNumber = 1, ImageUrl = "/Images/PartyRoom3.jpeg" },
                new PartyRoom { PartyRoomId = 4, Name = "Room D", Block = "Party Block", OpeningTime = new TimeSpan(7, 0, 0), ClosingTime = new TimeSpan(23, 0, 0), Floor = 2, RoomNumber = 2, ImageUrl = "/Images/PartyRoomD.jpeg" },
                new PartyRoom { PartyRoomId = 5, Name = "Room E", Block = "Party Block", OpeningTime = new TimeSpan(7, 0, 0), ClosingTime = new TimeSpan(23, 0, 0), Floor = 3, RoomNumber = 1, ImageUrl = "/Images/PartyRoomE.jfif" },
                new PartyRoom { PartyRoomId = 6, Name = "Room F", Block = "Party Block", OpeningTime = new TimeSpan(7, 0, 0), ClosingTime = new TimeSpan(23, 0, 0), Floor = 3, RoomNumber = 2, ImageUrl = "/Images/PartyRoom6.JPEG" }
            );
        }
    }


}
