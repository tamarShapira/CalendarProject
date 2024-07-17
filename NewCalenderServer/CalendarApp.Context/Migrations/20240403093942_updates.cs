using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalendarApp.Context.Migrations
{
    /// <inheritdoc />
    public partial class updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_FatherID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_MotherID",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_SpouseID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FatherID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_MotherID",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SpouseID",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "SpouseID",
                table: "Users",
                newName: "SpouseId");

            migrationBuilder.RenameColumn(
                name: "MotherID",
                table: "Users",
                newName: "MotherId");

            migrationBuilder.RenameColumn(
                name: "FatherID",
                table: "Users",
                newName: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FatherId",
                table: "Users",
                column: "FatherId",
                unique: true,
                filter: "[FatherId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MotherId",
                table: "Users",
                column: "MotherId",
                unique: true,
                filter: "[MotherId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SpouseId",
                table: "Users",
                column: "SpouseId",
                unique: true,
                filter: "[SpouseId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_FatherId",
                table: "Users",
                column: "FatherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_MotherId",
                table: "Users",
                column: "MotherId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_SpouseId",
                table: "Users",
                column: "SpouseId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_FatherId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_MotherId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_SpouseId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FatherId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_MotherId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SpouseId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "SpouseId",
                table: "Users",
                newName: "SpouseID");

            migrationBuilder.RenameColumn(
                name: "MotherId",
                table: "Users",
                newName: "MotherID");

            migrationBuilder.RenameColumn(
                name: "FatherId",
                table: "Users",
                newName: "FatherID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FatherID",
                table: "Users",
                column: "FatherID",
                unique: true,
                filter: "[FatherID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MotherID",
                table: "Users",
                column: "MotherID",
                unique: true,
                filter: "[MotherID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SpouseID",
                table: "Users",
                column: "SpouseID",
                unique: true,
                filter: "[SpouseID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_FatherID",
                table: "Users",
                column: "FatherID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_MotherID",
                table: "Users",
                column: "MotherID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_SpouseID",
                table: "Users",
                column: "SpouseID",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
