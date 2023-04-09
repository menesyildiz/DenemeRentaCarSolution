using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DenemeRentaCar.Migrations
{
    /// <inheritdoc />
    public partial class cartableaddcustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CustomerId",
                table: "Cars",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Customers_CustomerId",
                table: "Cars",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Customers_CustomerId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CustomerId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Cars");
        }
    }
}
