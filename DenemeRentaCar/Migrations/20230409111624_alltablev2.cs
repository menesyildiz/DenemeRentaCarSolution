using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DenemeRentaCar.Migrations
{
    /// <inheritdoc />
    public partial class alltablev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Paid",
                table: "Renters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "Renters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plate",
                table: "Renters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RentDate",
                table: "Renters",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Renters");

            migrationBuilder.DropColumn(
                name: "Plate",
                table: "Renters");

            migrationBuilder.DropColumn(
                name: "RentDate",
                table: "Renters");

            migrationBuilder.AlterColumn<string>(
                name: "Paid",
                table: "Renters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
