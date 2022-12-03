using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoxShop.Migrations
{
    /// <inheritdoc />
    public partial class smos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VendorName",
                table: "LoginVendors",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<DateTime>(
                name: "Expires",
                table: "LoginVendors",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expires",
                table: "LoginVendors");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "LoginVendors",
                newName: "VendorName");
        }
    }
}
