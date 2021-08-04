using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagmentSystemMVC.Infrastructure.Migrations
{
    public partial class changeIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservationStateId",
                table: "Reservations");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationStateId",
                table: "Reservations",
                column: "ReservationStateId");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
               name: "IX_Reservations_ReservationStateId",
               table: "Reservations");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationStateId",
                table: "Reservations",
                column: "ReservationStateId");
        }
    }
}
