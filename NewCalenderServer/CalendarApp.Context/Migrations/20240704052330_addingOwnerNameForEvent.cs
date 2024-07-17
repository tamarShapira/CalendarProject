using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalendarApp.Context.Migrations
{
    /// <inheritdoc />
    public partial class addingOwnerNameForEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventOwnerName",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventOwnerName",
                table: "Events");
        }
    }
}
