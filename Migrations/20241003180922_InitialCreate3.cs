using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunlandV3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Amenities_AmenityId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_UserID",
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

            migrationBuilder.DropIndex(
                name: "IX_Bookings_UserID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "AmenityId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BookingTypeID",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "PartyRoomId",
                table: "Bookings",
                newName: "RoomId");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Bookings",
                newName: "PartyRoomId");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Bookings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AmenityId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingTypeID",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GameId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserID",
                table: "Bookings",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Amenities_AmenityId",
                table: "Bookings",
                column: "AmenityId",
                principalTable: "Amenities",
                principalColumn: "AmenityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_UserID",
                table: "Bookings",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
