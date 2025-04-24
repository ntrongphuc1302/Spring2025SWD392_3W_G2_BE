using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetroOne.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCoachNumberAndTrainCodeFromTrips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoachNumber",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "TrainCode",
                table: "Trips");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoachNumber",
                table: "Trips",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainCode",
                table: "Trips",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
