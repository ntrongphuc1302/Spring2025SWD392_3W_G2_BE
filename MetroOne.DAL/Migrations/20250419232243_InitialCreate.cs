using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetroOne.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    StationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StationCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OrderInRoute = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Stations__E0D8A6DDFD19AA1E", x => x.StationID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "('Active')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__1788CCAC603571B7", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Train",
                columns: table => new
                {
                    TrainID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StartStationID = table.Column<int>(type: "int", nullable: false),
                    EndStationID = table.Column<int>(type: "int", nullable: false),
                    EstimatedTime = table.Column<TimeOnly>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Train__8ED2725A69305F0E", x => x.TrainID);
                    table.ForeignKey(
                        name: "FK__Train__EndStatio__403A8C7D",
                        column: x => x.EndStationID,
                        principalTable: "Stations",
                        principalColumn: "StationID");
                    table.ForeignKey(
                        name: "FK__Train__StartStat__3F466844",
                        column: x => x.StartStationID,
                        principalTable: "Stations",
                        principalColumn: "StationID");
                });

            migrationBuilder.CreateTable(
                name: "Passes",
                columns: table => new
                {
                    PassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    PassType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    RemainingUses = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Passes__C6740948D56535F2", x => x.PassID);
                    table.ForeignKey(
                        name: "FK__Passes__UserID__3A81B327",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainID = table.Column<int>(type: "int", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ArrivalTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrainCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CoachNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Trips__51DC711EA65A7046", x => x.TripID);
                    table.ForeignKey(
                        name: "FK__Trips__TrainID__4316F928",
                        column: x => x.TrainID,
                        principalTable: "Train",
                        principalColumn: "TrainID");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    TripID = table.Column<int>(type: "int", nullable: false),
                    StartStationID = table.Column<int>(type: "int", nullable: false),
                    EndStationID = table.Column<int>(type: "int", nullable: false),
                    BookingTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    QRCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tickets__712CC627BFE3C37A", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK__Tickets__EndStat__49C3F6B7",
                        column: x => x.EndStationID,
                        principalTable: "Stations",
                        principalColumn: "StationID");
                    table.ForeignKey(
                        name: "FK__Tickets__StartSt__48CFD27E",
                        column: x => x.StartStationID,
                        principalTable: "Stations",
                        principalColumn: "StationID");
                    table.ForeignKey(
                        name: "FK__Tickets__TripID__47DBAE45",
                        column: x => x.TripID,
                        principalTable: "Trips",
                        principalColumn: "TripID");
                    table.ForeignKey(
                        name: "FK__Tickets__UserID__46E78A0C",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "PaymentStatus",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketID = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PaymentTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    PaymentStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PaymentS__9B556A585DC4EE80", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK__PaymentSt__Ticke__4E88ABD4",
                        column: x => x.TicketID,
                        principalTable: "Tickets",
                        principalColumn: "TicketID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passes_UserID",
                table: "Passes",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "UQ__PaymentS__712CC62662DA0492",
                table: "PaymentStatus",
                column: "TicketID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EndStationID",
                table: "Tickets",
                column: "EndStationID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_StartStationID",
                table: "Tickets",
                column: "StartStationID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TripID",
                table: "Tickets",
                column: "TripID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserID",
                table: "Tickets",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Train_EndStationID",
                table: "Train",
                column: "EndStationID");

            migrationBuilder.CreateIndex(
                name: "IX_Train_StartStationID",
                table: "Train",
                column: "StartStationID");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_TrainID",
                table: "Trips",
                column: "TrainID");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D105345F5E05B1",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passes");

            migrationBuilder.DropTable(
                name: "PaymentStatus");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Train");

            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}
