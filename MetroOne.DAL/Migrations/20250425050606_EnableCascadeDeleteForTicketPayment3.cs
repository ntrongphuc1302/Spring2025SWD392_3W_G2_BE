using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetroOne.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EnableCascadeDeleteForTicketPayment3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__PaymentSt__Ticke__4E88ABD4",
                table: "PaymentStatus");

            migrationBuilder.AddForeignKey(
                name: "FK__PaymentSt__Ticke__4E88ABD4",
                table: "PaymentStatus",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "TicketID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__PaymentSt__Ticke__4E88ABD4",
                table: "PaymentStatus");

            migrationBuilder.AddForeignKey(
                name: "FK__PaymentSt__Ticke__4E88ABD4",
                table: "PaymentStatus",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "TicketID");
        }
    }
}
