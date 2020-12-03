using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TKXDPM_API.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AddressName = table.Column<string>(type: "varchar(255)", nullable: true),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    BikeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BikeName = table.Column<string>(type: "varchar(255)", nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", nullable: true),
                    StartingRent = table.Column<int>(type: "integer", nullable: false),
                    HourlyRent = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    LicensePlates = table.Column<string>(type: "varchar(255)", nullable: true),
                    BatterCapacity = table.Column<int>(type: "integer", nullable: false),
                    PowerDrain = table.Column<float>(type: "real", nullable: false),
                    Deposit = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.BikeId);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RenterId = table.Column<int>(type: "integer", nullable: false),
                    PaymentMethod = table.Column<string>(type: "varchar(255)", nullable: true),
                    Cvv = table.Column<int>(type: "integer", nullable: false),
                    ExpirationDate = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "Renters",
                columns: table => new
                {
                    RenterId = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renters", x => x.RenterId);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    StationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AddressId = table.Column<int>(type: "integer", nullable: false),
                    ContactName = table.Column<string>(type: "varchar(255)", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(255)", nullable: true),
                    Area = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.StationId);
                    table.ForeignKey(
                        name: "FK_Stations_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    RentalId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BikeId = table.Column<int>(type: "integer", nullable: false),
                    CardId = table.Column<int>(type: "integer", nullable: false),
                    RenterId = table.Column<string>(type: "varchar(255)", nullable: true),
                    RateContent = table.Column<string>(type: "varchar(255)", nullable: true),
                    RateNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.RentalId);
                    table.ForeignKey(
                        name: "FK_Rentals_Bikes_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Bikes",
                        principalColumn: "BikeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "CardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Renters_RenterId",
                        column: x => x.RenterId,
                        principalTable: "Renters",
                        principalColumn: "RenterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BikeInStation",
                columns: table => new
                {
                    StationId = table.Column<int>(type: "integer", nullable: false),
                    BikeId = table.Column<int>(type: "integer", nullable: false),
                    DateTimeIn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateTimeOut = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeInStation", x => new { x.BikeId, x.StationId });
                    table.ForeignKey(
                        name: "FK_BikeInStation_Bikes_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Bikes",
                        principalColumn: "BikeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BikeInStation_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RentalId = table.Column<int>(type: "integer", nullable: false),
                    PaymentStatus = table.Column<string>(type: "varchar(255)", nullable: true),
                    BookedStartDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BookedEndDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ActualStartDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ActualEndDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Rentals_RentalId",
                        column: x => x.RentalId,
                        principalTable: "Rentals",
                        principalColumn: "RentalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "AddressName", "Latitude", "Longitude" },
                values: new object[,]
                {
                    { 1, "Duong Lang, Ha Noi", 100f, 99f },
                    { 2, "Truong Chinh, Ha Noi", 100f, 99f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BikeInStation_StationId",
                table: "BikeInStation",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_BikeId",
                table: "Rentals",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CardId",
                table: "Rentals",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_RenterId",
                table: "Rentals",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_AddressId",
                table: "Stations",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_RentalId",
                table: "Transactions",
                column: "RentalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BikeInStation");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Bikes");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Renters");
        }
    }
}
