using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoxShop.Migrations
{
    /// <inheritdoc />
    public partial class someones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<ulong>(
                name: "AdminId",
                table: "Vendors",
                type: "integer",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<ulong>(
                name: "AdminId",
                table: "LoginAdmins",
                type: "integer",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<ulong>(
                name: "AdminId",
                table: "Banners",
                type: "integer",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceInfo",
                table: "AdminSessions",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "AdminId",
                table: "AdminSessions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<ulong>(
                name: "AdminSessionId",
                table: "AdminSessions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<ulong>(
                name: "AdminId",
                table: "Admins",
                type: "integer",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<ulong>(
                name: "AdminId",
                table: "Vendors",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "integer");

            migrationBuilder.AlterColumn<ulong>(
                name: "AdminId",
                table: "LoginAdmins",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "integer");

            migrationBuilder.AlterColumn<ulong>(
                name: "AdminId",
                table: "Banners",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceInfo",
                table: "AdminSessions",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<ulong>(
                name: "AdminId",
                table: "AdminSessions",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "integer");

            migrationBuilder.AlterColumn<ulong>(
                name: "AdminSessionId",
                table: "AdminSessions",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "integer")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<ulong>(
                name: "AdminId",
                table: "Admins",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "integer")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);
        }
    }
}
