using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcomWebApp.Migrations.Identity
{
    /// <inheritdoc />
    public partial class newseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3ae3278-6f9a-41bb-9d21-a7a963d67980");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f3ae3278-6f9a-41bb-9d21-a7a963d67980", null, "System Administrator", "SYSTEM ADMINISTRATOR" });
        }
    }
}
