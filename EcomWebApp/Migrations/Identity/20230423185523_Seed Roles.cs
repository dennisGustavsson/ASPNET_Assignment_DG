using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcomWebApp.Migrations.Identity
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f3ae3278-6f9a-41bb-9d21-a7a963d67980", null, "Admin", "ADMIN" });
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f3ab3278-6f9a-51bb-9f21-a7a983d67981", null, "User", "USER" });
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f3ac3278-6f9a-61bb-4e21-a7a993d67982", null, "Product Manager", "PRODUCTMANAGER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3ae3278-6f9a-41bb-9d21-a7a963d67980");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3ab3278-6f9a-51bb-9f21-a7a983d67981");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3ac3278-6f9a-61bb-9e21-a7a993d67982");
        }
    }
}
