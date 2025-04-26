using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetroOne.DAL.Migrations
{
    /// <inheritdoc />
    public partial class REBUILD_DATABASE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Tickets__EndStat__49C3F6B7",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK__Tickets__StartSt__48CFD27E",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK__Tickets__TripID__47DBAE45",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK__Tickets__UserID__46E78A0C",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK__Train__EndStatio__403A8C7D",
                table: "Train");

            migrationBuilder.DropForeignKey(
                name: "FK__Train__StartStat__3F466844",
                table: "Train");

            migrationBuilder.DropForeignKey(
                name: "FK__Trips__TrainID__4316F928",
                table: "Trips");

            migrationBuilder.DropTable(
                name: "Passes");

            migrationBuilder.DropTable(
                name: "PaymentStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Users__1788CCAC603571B7",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "UQ__Users__A9D105345F5E05B1",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Trips__51DC711EA65A7046",
                table: "Trips");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Tickets__712CC627BFE3C37A",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_EndStationID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_StartStationID",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Stations__E0D8A6DDFD19AA1E",
                table: "Stations");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Train__8ED2725A69305F0E",
                table: "Train");

            migrationBuilder.DropIndex(
                name: "IX_Train_EndStationID",
                table: "Train");

            migrationBuilder.DropIndex(
                name: "IX_Train_StartStationID",
                table: "Train");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EndStationID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "QRCode",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "StartStationID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "StationCode",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "EndStationID",
                table: "Train");

            migrationBuilder.DropColumn(
                name: "StartStationID",
                table: "Train");

            migrationBuilder.RenameTable(
                name: "Train",
                newName: "Trains");

            migrationBuilder.RenameColumn(
                name: "OrderInRoute",
                table: "Stations",
                newName: "LocationID");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValue: "Active",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValueSql: "('Active')");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Permission",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                defaultValue: "Passenger");

            migrationBuilder.AlterColumn<int>(
                name: "TrainID",
                table: "Trips",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RouteID",
                table: "Trips",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TripID",
                table: "Tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTo",
                table: "Tickets",
                type: "datetime",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "Trains",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RouteLocationID",
                table: "Trains",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Users__1788CCAC771F4B79",
                table: "Users",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Trips__51DC711E210B0AA6",
                table: "Trips",
                column: "TripID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Tickets__712CC62751153BBF",
                table: "Tickets",
                column: "TicketID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Stations__E0D8A6DDF89A2067",
                table: "Stations",
                column: "StationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Trains__8ED2725A8D149518",
                table: "Trains",
                column: "TrainID");

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Location__E7FEA477A7F2D653", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "RouteLocation",
                columns: table => new
                {
                    RouteLocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RouteLoc__ADC74A46D96938ED", x => x.RouteLocationID);
                    table.ForeignKey(
                        name: "FK__RouteLoca__Locat__4222D4EF",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartStationID = table.Column<int>(type: "int", nullable: true),
                    EndStationID = table.Column<int>(type: "int", nullable: true),
                    RouteName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RouteLocationID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Routes__80979AAD0D2925EC", x => x.RouteID);
                    table.ForeignKey(
                        name: "FK__Routes__EndStati__45F365D3",
                        column: x => x.EndStationID,
                        principalTable: "Stations",
                        principalColumn: "StationID");
                    table.ForeignKey(
                        name: "FK__Routes__RouteLoc__46E78A0C",
                        column: x => x.RouteLocationID,
                        principalTable: "RouteLocation",
                        principalColumn: "RouteLocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Routes__StartSta__44FF419A",
                        column: x => x.StartStationID,
                        principalTable: "Stations",
                        principalColumn: "StationID");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D1053400F650C6",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_RouteID",
                table: "Trips",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_LocationID",
                table: "Stations",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Trains_RouteLocationID",
                table: "Trains",
                column: "RouteLocationID");

            migrationBuilder.CreateIndex(
                name: "UQ__RouteLoc__E7FEA4764EF80374",
                table: "RouteLocation",
                column: "LocationID",
                unique: true,
                filter: "[LocationID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_EndStationID",
                table: "Routes",
                column: "EndStationID");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_RouteLocationID",
                table: "Routes",
                column: "RouteLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_StartStationID",
                table: "Routes",
                column: "StartStationID");

            migrationBuilder.AddForeignKey(
                name: "FK__Stations__Locati__3E52440B",
                table: "Stations",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Tickets__TripID__52593CB8",
                table: "Tickets",
                column: "TripID",
                principalTable: "Trips",
                principalColumn: "TripID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Tickets__UserID__5165187F",
                table: "Tickets",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Trains__RouteLoc__49C3F6B7",
                table: "Trains",
                column: "RouteLocationID",
                principalTable: "RouteLocation",
                principalColumn: "RouteLocationID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK__Trips__RouteID__4CA06362",
                table: "Trips",
                column: "RouteID",
                principalTable: "Routes",
                principalColumn: "RouteID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Trips__TrainID__4D94879B",
                table: "Trips",
                column: "TrainID",
                principalTable: "Trains",
                principalColumn: "TrainID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Stations__Locati__3E52440B",
                table: "Stations");

            migrationBuilder.DropForeignKey(
                name: "FK__Tickets__TripID__52593CB8",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK__Tickets__UserID__5165187F",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK__Trains__RouteLoc__49C3F6B7",
                table: "Trains");

            migrationBuilder.DropForeignKey(
                name: "FK__Trips__RouteID__4CA06362",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK__Trips__TrainID__4D94879B",
                table: "Trips");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "RouteLocation");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Users__1788CCAC771F4B79",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "UQ__Users__A9D1053400F650C6",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Trips__51DC711E210B0AA6",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_RouteID",
                table: "Trips");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Tickets__712CC62751153BBF",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Stations__E0D8A6DDF89A2067",
                table: "Stations");

            migrationBuilder.DropIndex(
                name: "IX_Stations_LocationID",
                table: "Stations");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Trains__8ED2725A8D149518",
                table: "Trains");

            migrationBuilder.DropIndex(
                name: "IX_Trains_RouteLocationID",
                table: "Trains");

            migrationBuilder.DropColumn(
                name: "Permission",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RouteID",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "ValidTo",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "RouteLocationID",
                table: "Trains");

            migrationBuilder.RenameTable(
                name: "Trains",
                newName: "Train");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "Stations",
                newName: "OrderInRoute");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                defaultValueSql: "('Active')",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldDefaultValue: "Active");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "TrainID",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TripID",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EndStationID",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "QRCode",
                table: "Tickets",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartStationID",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Stations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StationCode",
                table: "Stations",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "Train",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EndStationID",
                table: "Train",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartStationID",
                table: "Train",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Users__1788CCAC603571B7",
                table: "Users",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Trips__51DC711EA65A7046",
                table: "Trips",
                column: "TripID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Tickets__712CC627BFE3C37A",
                table: "Tickets",
                column: "TicketID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Stations__E0D8A6DDFD19AA1E",
                table: "Stations",
                column: "StationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Train__8ED2725A69305F0E",
                table: "Train",
                column: "TrainID");

            migrationBuilder.CreateTable(
                name: "Passes",
                columns: table => new
                {
                    PassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    PassType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    RemainingUses = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true)
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
                name: "PaymentStatus",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaymentTime = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PaymentS__9B556A585DC4EE80", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK__PaymentSt__Ticke__4E88ABD4",
                        column: x => x.TicketID,
                        principalTable: "Tickets",
                        principalColumn: "TicketID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D105345F5E05B1",
                table: "Users",
                column: "Email",
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
                name: "IX_Train_EndStationID",
                table: "Train",
                column: "EndStationID");

            migrationBuilder.CreateIndex(
                name: "IX_Train_StartStationID",
                table: "Train",
                column: "StartStationID");

            migrationBuilder.CreateIndex(
                name: "IX_Passes_UserID",
                table: "Passes",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "UQ__PaymentS__712CC62662DA0492",
                table: "PaymentStatus",
                column: "TicketID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK__Tickets__EndStat__49C3F6B7",
                table: "Tickets",
                column: "EndStationID",
                principalTable: "Stations",
                principalColumn: "StationID");

            migrationBuilder.AddForeignKey(
                name: "FK__Tickets__StartSt__48CFD27E",
                table: "Tickets",
                column: "StartStationID",
                principalTable: "Stations",
                principalColumn: "StationID");

            migrationBuilder.AddForeignKey(
                name: "FK__Tickets__TripID__47DBAE45",
                table: "Tickets",
                column: "TripID",
                principalTable: "Trips",
                principalColumn: "TripID");

            migrationBuilder.AddForeignKey(
                name: "FK__Tickets__UserID__46E78A0C",
                table: "Tickets",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK__Train__EndStatio__403A8C7D",
                table: "Train",
                column: "EndStationID",
                principalTable: "Stations",
                principalColumn: "StationID");

            migrationBuilder.AddForeignKey(
                name: "FK__Train__StartStat__3F466844",
                table: "Train",
                column: "StartStationID",
                principalTable: "Stations",
                principalColumn: "StationID");

            migrationBuilder.AddForeignKey(
                name: "FK__Trips__TrainID__4316F928",
                table: "Trips",
                column: "TrainID",
                principalTable: "Train",
                principalColumn: "TrainID");
        }
    }
}
