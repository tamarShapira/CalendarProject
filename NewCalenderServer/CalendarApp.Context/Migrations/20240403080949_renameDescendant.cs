using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalendarApp.Context.Migrations
{
    /// <inheritdoc />
    public partial class renameDescendant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calenders_Descendants_DirectorId",
                table: "Calenders");

            migrationBuilder.DropForeignKey(
                name: "FK_CalenderUsers_Descendants_DescendantId",
                table: "CalenderUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Descendants_DescendantId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Descendants");

            migrationBuilder.RenameColumn(
                name: "DescendantId",
                table: "Events",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_DescendantId",
                table: "Events",
                newName: "IX_Events_UserId");

            migrationBuilder.RenameColumn(
                name: "DescendantId",
                table: "CalenderUsers",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CalenderUsers_DescendantId",
                table: "CalenderUsers",
                newName: "IX_CalenderUsers_UserId");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteUserId = table.Column<int>(type: "int", nullable: true),
                    TZ = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BornDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpouseID = table.Column<int>(type: "int", nullable: true),
                    FatherID = table.Column<int>(type: "int", nullable: true),
                    MotherID = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_SiteUsers_SiteUserId",
                        column: x => x.SiteUserId,
                        principalTable: "SiteUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_FatherID",
                        column: x => x.FatherID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_MotherID",
                        column: x => x.MotherID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_SpouseID",
                        column: x => x.SpouseID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_Users_SiteUserId",
                table: "Users",
                column: "SiteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_SpouseID",
                table: "Users",
                column: "SpouseID",
                unique: true,
                filter: "[SpouseID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Calenders_Users_DirectorId",
                table: "Calenders",
                column: "DirectorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CalenderUsers_Users_UserId",
                table: "CalenderUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_UserId",
                table: "Events",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calenders_Users_DirectorId",
                table: "Calenders");

            migrationBuilder.DropForeignKey(
                name: "FK_CalenderUsers_Users_UserId",
                table: "CalenderUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_UserId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Events",
                newName: "DescendantId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_UserId",
                table: "Events",
                newName: "IX_Events_DescendantId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CalenderUsers",
                newName: "DescendantId");

            migrationBuilder.RenameIndex(
                name: "IX_CalenderUsers_UserId",
                table: "CalenderUsers",
                newName: "IX_CalenderUsers_DescendantId");

            migrationBuilder.CreateTable(
                name: "Descendants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FatherID = table.Column<int>(type: "int", nullable: true),
                    MotherID = table.Column<int>(type: "int", nullable: true),
                    SiteUserId = table.Column<int>(type: "int", nullable: true),
                    SpouseID = table.Column<int>(type: "int", nullable: true),
                    BornDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TZ = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descendants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Descendants_Descendants_FatherID",
                        column: x => x.FatherID,
                        principalTable: "Descendants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Descendants_Descendants_MotherID",
                        column: x => x.MotherID,
                        principalTable: "Descendants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Descendants_Descendants_SpouseID",
                        column: x => x.SpouseID,
                        principalTable: "Descendants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Descendants_SiteUsers_SiteUserId",
                        column: x => x.SiteUserId,
                        principalTable: "SiteUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Descendants_FatherID",
                table: "Descendants",
                column: "FatherID",
                unique: true,
                filter: "[FatherID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Descendants_MotherID",
                table: "Descendants",
                column: "MotherID",
                unique: true,
                filter: "[MotherID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Descendants_SiteUserId",
                table: "Descendants",
                column: "SiteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Descendants_SpouseID",
                table: "Descendants",
                column: "SpouseID",
                unique: true,
                filter: "[SpouseID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Calenders_Descendants_DirectorId",
                table: "Calenders",
                column: "DirectorId",
                principalTable: "Descendants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CalenderUsers_Descendants_DescendantId",
                table: "CalenderUsers",
                column: "DescendantId",
                principalTable: "Descendants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Descendants_DescendantId",
                table: "Events",
                column: "DescendantId",
                principalTable: "Descendants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
