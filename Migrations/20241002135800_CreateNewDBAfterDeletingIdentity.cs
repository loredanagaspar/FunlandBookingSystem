using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunlandV3.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewDBAfterDeletingIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmenityId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PartyRoomId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_AmenityId",
                table: "Bookings",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GameId",
                table: "Bookings",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PartyRoomId",
                table: "Bookings",
                column: "PartyRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Amenities_AmenityId",
                table: "Bookings",
                column: "AmenityId",
                principalTable: "Amenities",
                principalColumn: "AmenityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Games_GameId",
                table: "Bookings",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_PartyRooms_PartyRoomId",
                table: "Bookings",
                column: "PartyRoomId",
                principalTable: "PartyRooms",
                principalColumn: "PartyRoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Amenities_AmenityId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Games_GameId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_PartyRooms_PartyRoomId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_AmenityId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_GameId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_PartyRoomId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "AmenityId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PartyRoomId",
                table: "Bookings");
        }
    }
}
