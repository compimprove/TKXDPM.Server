using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TKXDPM_API.Migrations
{
    public partial class Test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rentals_RenterId",
                table: "Rentals");

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 100001);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 100002);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_RenterId",
                table: "Rentals",
                column: "RenterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rentals_RenterId",
                table: "Rentals");

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 100001);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 100002);

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "ActualEndDateTime", "ActualStartDateTime", "BookedEndDateTime", "BookedStartDateTime", "PaymentStatus", "RentalId" },
                values: new object[,]
                {
                    { 100002, new DateTime(2020, 12, 3, 10, 14, 54, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 3, 8, 32, 54, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 100001 },
                    { 100001, new DateTime(2020, 12, 3, 10, 14, 54, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 3, 8, 32, 54, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 100001 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_RenterId",
                table: "Rentals",
                column: "RenterId",
                unique: true);
        }
    }
}
