using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FunlandV3.Migrations
{
    /// <inheritdoc />
    public partial class SeedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "PartyRooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Amenities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "AmenityId", "AgeRestriction", "Block", "ClosingTime", "ImageUrl", "MaxBookingHours", "Name", "OpeningTime", "PoolType", "RequiresSupervision" },
                values: new object[,]
                {
                    { 1, "1-8", "Amenities Block", new TimeSpan(0, 20, 0, 0, 0), "/images/SwimmingPool.jpg", 5, "Kids Pool", new TimeSpan(0, 8, 0, 0, 0), "Kids", true },
                    { 2, "9+", "Amenities Block", new TimeSpan(0, 20, 0, 0, 0), "/images/KidsSwimmingPool.jpg", 5, "Adult Pool", new TimeSpan(0, 8, 0, 0, 0), "Adult", true }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "Block", "ClosingTime", "ImageUrl", "MaxBookingHours", "Name", "OpeningTime" },
                values: new object[,]
                {
                    { 1, "Gaming Block", new TimeSpan(0, 19, 0, 0, 0), "/images/LaserTag.jpg", 3, "Laser Tag", new TimeSpan(0, 10, 0, 0, 0) },
                    { 2, "Gaming Block", new TimeSpan(0, 19, 0, 0, 0), "/images/Bowling.png", 3, "Bowling", new TimeSpan(0, 10, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "PartyRooms",
                columns: new[] { "PartyRoomId", "Block", "ClosingTime", "Floor", "ImageUrl", "Name", "OpeningTime", "RoomNumber" },
                values: new object[,]
                {
                    { 1, "Party Block", new TimeSpan(0, 23, 0, 0, 0), 1, "/images/PartyRoom1.jfif", "Room A", new TimeSpan(0, 7, 0, 0, 0), 1 },
                    { 2, "Party Block", new TimeSpan(0, 23, 0, 0, 0), 1, "/images/PartyRoom2.JPEG", "Room B", new TimeSpan(0, 7, 0, 0, 0), 2 },
                    { 3, "Party Block", new TimeSpan(0, 23, 0, 0, 0), 2, "/images/PartyRoom3.jpeg", "Room C", new TimeSpan(0, 7, 0, 0, 0), 1 },
                    { 4, "Party Block", new TimeSpan(0, 23, 0, 0, 0), 2, "/images/PartyRoom4.jfif", "Room D", new TimeSpan(0, 7, 0, 0, 0), 2 },
                    { 5, "Party Block", new TimeSpan(0, 23, 0, 0, 0), 3, "/images/PartyRoom5,jpg", "Room E", new TimeSpan(0, 7, 0, 0, 0), 1 },
                    { 6, "Party Block", new TimeSpan(0, 23, 0, 0, 0), 3, "/images/PartyRoom6.JPEG", "Room F", new TimeSpan(0, 7, 0, 0, 0), 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "AmenityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "AmenityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PartyRooms",
                keyColumn: "PartyRoomId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PartyRooms",
                keyColumn: "PartyRoomId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PartyRooms",
                keyColumn: "PartyRoomId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PartyRooms",
                keyColumn: "PartyRoomId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PartyRooms",
                keyColumn: "PartyRoomId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PartyRooms",
                keyColumn: "PartyRoomId",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "PartyRooms");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Amenities");
        }
    }
}
