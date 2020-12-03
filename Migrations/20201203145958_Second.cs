using Microsoft.EntityFrameworkCore.Migrations;

namespace TKXDPM_API.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RenterId",
                table: "Cards",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_RenterId",
                table: "Cards",
                column: "RenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Renters_RenterId",
                table: "Cards",
                column: "RenterId",
                principalTable: "Renters",
                principalColumn: "RenterId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Renters_RenterId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_RenterId",
                table: "Cards");

            migrationBuilder.AlterColumn<int>(
                name: "RenterId",
                table: "Cards",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true);
        }
    }
}
