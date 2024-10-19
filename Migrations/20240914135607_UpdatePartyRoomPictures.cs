using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunlandV3.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePartyRoomPictures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PartyRooms",
                keyColumn: "PartyRoomId",
                keyValue: 4,
                column: "ImageUrl",
                value: "/Images/PartyRoomD.jpeg");

            migrationBuilder.UpdateData(
                table: "PartyRooms",
                keyColumn: "PartyRoomId",
                keyValue: 5,
                column: "ImageUrl",
                value: "/Images/PartyRoomE.jfif");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
