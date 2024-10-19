using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunlandV3.Migrations
{
    /// <inheritdoc />
    public partial class NEwPictures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenityId",
                keyValue: 1,
                column: "ImageUrl",
                value: "/Images/SwimmingPool.jpg");

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenityId",
                keyValue: 2,
                column: "ImageUrl",
                value: "/Images/KidsSwimmingPool.jpg");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 1,
                column: "ImageUrl",
                value: "/Images/LaserTag.jpg");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 2,
                column: "ImageUrl",
                value: "/Images/Bowling.png");

            migrationBuilder.UpdateData(
                table: "PartyRooms",
                keyColumn: "PartyRoomId",
                keyValue: 1,
                column: "ImageUrl",
                value: "/Images/PartyRoom1.jfif");

            migrationBuilder.UpdateData(
                table: "PartyRooms",
                keyColumn: "PartyRoomId",
                keyValue: 2,
                column: "ImageUrl",
                value: "/Images/PartyRoom2.JPEG");

            migrationBuilder.UpdateData(
                table: "PartyRooms",
                keyColumn: "PartyRoomId",
                keyValue: 3,
                column: "ImageUrl",
                value: "/Images/PartyRoom3.jpeg");

            migrationBuilder.UpdateData(
                table: "PartyRooms",
                keyColumn: "PartyRoomId",
                keyValue: 4,
                column: "ImageUrl",
                value: "/Images/PartyRoom4.jfif");

            migrationBuilder.UpdateData(
                table: "PartyRooms",
                keyColumn: "PartyRoomId",
                keyValue: 5,
                column: "ImageUrl",
                value: "/Images/PartyRoom5,jpg");

            migrationBuilder.UpdateData(
                table: "PartyRooms",
                keyColumn: "PartyRoomId",
                keyValue: 6,
                column: "ImageUrl",
                value: "/Images/PartyRoom6.JPEG");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenityId",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/SwimmingPool.jpg");

            migrationBuilder.UpdateData(
                table: "Amenities",
                keyColumn: "AmenityId",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/KidsSwimmingPool.jpg");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/LaserTag.jpg");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/Bowling.png");

            migrationBuilder.UpdateData(
                table: "PartyRooms",
                keyColumn: "PartyRoomId",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/PartyRoom1.jfif");

            migrationBuilder.UpdateData(
                table: "PartyRooms",
                keyColumn: "PartyRoomId",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/PartyRoom2.JPEG");

            migrationBuilder.UpdateData(
                table: "PartyRooms",
                keyColumn: "PartyRoomId",
                keyValue: 3,
                column: "ImageUrl",
                value: "/images/PartyRoom3.jpeg");

            migrationBuilder.UpdateData(
                table: "PartyRooms",
                keyColumn: "PartyRoomId",
                keyValue: 4,
                column: "ImageUrl",
                value: "/images/PartyRoom4.jfif");

            migrationBuilder.UpdateData(
                table: "PartyRooms",
                keyColumn: "PartyRoomId",
                keyValue: 5,
                column: "ImageUrl",
                value: "/images/PartyRoom5,jpg");

            migrationBuilder.UpdateData(
                table: "PartyRooms",
                keyColumn: "PartyRoomId",
                keyValue: 6,
                column: "ImageUrl",
                value: "/images/PartyRoom6.JPEG");
        }
    }
}
