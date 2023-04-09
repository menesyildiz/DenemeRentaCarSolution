using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DenemeRentaCar.Migrations
{
    /// <inheritdoc />
    public partial class cartablevsecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Paid",
                table: "Renters",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "Cars",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RentDate",
                table: "Cars",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Rented",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "RentDate",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Rented",
                table: "Cars");

            migrationBuilder.AlterColumn<decimal>(
                name: "Paid",
                table: "Renters",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
