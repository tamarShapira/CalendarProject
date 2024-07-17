using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalendarApp.Context.Migrations
{
    /// <inheritdoc />
    public partial class renamecalendar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Calenders_CalenderId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_YearEvents_Calenders_CalenderId",
                table: "YearEvents");

            migrationBuilder.DropTable(
                name: "CalenderUsers");

            migrationBuilder.DropTable(
                name: "CalenderYears");

            migrationBuilder.DropTable(
                name: "Calenders");

            migrationBuilder.RenameColumn(
                name: "CalenderId",
                table: "YearEvents",
                newName: "CalendarId");

            migrationBuilder.RenameIndex(
                name: "IX_YearEvents_CalenderId",
                table: "YearEvents",
                newName: "IX_YearEvents_CalendarId");

            migrationBuilder.RenameColumn(
                name: "CalenderId",
                table: "Events",
                newName: "CalendarId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_CalenderId",
                table: "Events",
                newName: "IX_Events_CalendarId");

            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectorId = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calendars_SiteUsers_SiteUserId",
                        column: x => x.SiteUserId,
                        principalTable: "SiteUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Calendars_Users_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalendarUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CalendarId = table.Column<int>(type: "int", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarUsers_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalendarUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CalendarYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalendarId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarYears", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarYears_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_DirectorId",
                table: "Calendars",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_SiteUserId",
                table: "Calendars",
                column: "SiteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarUsers_CalendarId",
                table: "CalendarUsers",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarUsers_UserId",
                table: "CalendarUsers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CalendarYears_CalendarId",
                table: "CalendarYears",
                column: "CalendarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Calendars_CalendarId",
                table: "Events",
                column: "CalendarId",
                principalTable: "Calendars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_YearEvents_Calendars_CalendarId",
                table: "YearEvents",
                column: "CalendarId",
                principalTable: "Calendars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Calendars_CalendarId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_YearEvents_Calendars_CalendarId",
                table: "YearEvents");

            migrationBuilder.DropTable(
                name: "CalendarUsers");

            migrationBuilder.DropTable(
                name: "CalendarYears");

            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.RenameColumn(
                name: "CalendarId",
                table: "YearEvents",
                newName: "CalenderId");

            migrationBuilder.RenameIndex(
                name: "IX_YearEvents_CalendarId",
                table: "YearEvents",
                newName: "IX_YearEvents_CalenderId");

            migrationBuilder.RenameColumn(
                name: "CalendarId",
                table: "Events",
                newName: "CalenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_CalendarId",
                table: "Events",
                newName: "IX_Events_CalenderId");

            migrationBuilder.CreateTable(
                name: "Calenders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DirectorId = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calenders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calenders_SiteUsers_SiteUserId",
                        column: x => x.SiteUserId,
                        principalTable: "SiteUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Calenders_Users_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalenderUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalenderId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalenderUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalenderUsers_Calenders_CalenderId",
                        column: x => x.CalenderId,
                        principalTable: "Calenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalenderUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CalenderYears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalenderId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalenderYears", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalenderYears_Calenders_CalenderId",
                        column: x => x.CalenderId,
                        principalTable: "Calenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calenders_DirectorId",
                table: "Calenders",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Calenders_SiteUserId",
                table: "Calenders",
                column: "SiteUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CalenderUsers_CalenderId",
                table: "CalenderUsers",
                column: "CalenderId");

            migrationBuilder.CreateIndex(
                name: "IX_CalenderUsers_UserId",
                table: "CalenderUsers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CalenderYears_CalenderId",
                table: "CalenderYears",
                column: "CalenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Calenders_CalenderId",
                table: "Events",
                column: "CalenderId",
                principalTable: "Calenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_YearEvents_Calenders_CalenderId",
                table: "YearEvents",
                column: "CalenderId",
                principalTable: "Calenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
