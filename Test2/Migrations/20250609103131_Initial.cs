using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Test2.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Racers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LengthInKm = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrackRaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaceId = table.Column<int>(type: "int", nullable: false),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    BestTimeInSeconds = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackRaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackRaces_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackRaces_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RacerId = table.Column<int>(type: "int", nullable: false),
                    TrackRaceId = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    FinishTimeInSeconds = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participations_Racers_RacerId",
                        column: x => x.RacerId,
                        principalTable: "Racers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participations_TrackRaces_TrackRaceId",
                        column: x => x.TrackRaceId,
                        principalTable: "TrackRaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Racers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Lewis Hamilton" },
                    { 2, "Max Verstappen" }
                });

            migrationBuilder.InsertData(
                table: "Races",
                columns: new[] { "Id", "Date", "Location", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monte Carlo", "Monaco Grand Prix" },
                    { 2, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Silverstone", "British Grand Prix" }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "LengthInKm", "Name" },
                values: new object[,]
                {
                    { 1, 3.3370000000000002, "Monaco Circuit" },
                    { 2, 5.891, "Silverstone Circuit" }
                });

            migrationBuilder.InsertData(
                table: "TrackRaces",
                columns: new[] { "Id", "BestTimeInSeconds", "RaceId", "TrackId" },
                values: new object[,]
                {
                    { 1, 5460.0, 1, 1 },
                    { 2, 5550.0, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Participations",
                columns: new[] { "Id", "FinishTimeInSeconds", "Position", "RacerId", "TrackRaceId" },
                values: new object[,]
                {
                    { 1, 5460.0, 1, 1, 1 },
                    { 2, 5550.0, 2, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participations_RacerId",
                table: "Participations",
                column: "RacerId");

            migrationBuilder.CreateIndex(
                name: "IX_Participations_TrackRaceId",
                table: "Participations",
                column: "TrackRaceId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackRaces_RaceId",
                table: "TrackRaces",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackRaces_TrackId",
                table: "TrackRaces",
                column: "TrackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participations");

            migrationBuilder.DropTable(
                name: "Racers");

            migrationBuilder.DropTable(
                name: "TrackRaces");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Tracks");
        }
    }
}
