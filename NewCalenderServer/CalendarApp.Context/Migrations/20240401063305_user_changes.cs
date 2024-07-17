using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalendarApp.Context.Migrations
{
    /// <inheritdoc />
    public partial class userchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserFatherID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserMotherID",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserPassword",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserSpouseID",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserTZ",
                table: "Users",
                newName: "DescendantId");

            migrationBuilder.RenameColumn(
                name: "UserPhoneNumber",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "UserPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "DescendantId",
                table: "Users",
                newName: "UserTZ");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserFatherID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserMotherID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserPassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserSpouseID",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
