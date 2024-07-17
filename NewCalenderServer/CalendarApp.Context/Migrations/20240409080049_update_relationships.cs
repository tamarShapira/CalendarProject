using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalendarApp.Context.Migrations
{
    /// <inheritdoc />
    public partial class updaterelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CalendarUsers_UserId",
                table: "CalendarUsers");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarUsers_UserId",
                table: "CalendarUsers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CalendarUsers_UserId",
                table: "CalendarUsers");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarUsers_UserId",
                table: "CalendarUsers",
                column: "UserId",
                unique: true);
        }
    }
}
