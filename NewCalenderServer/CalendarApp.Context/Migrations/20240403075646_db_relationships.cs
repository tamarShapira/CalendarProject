using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalendarApp.Context.Migrations
{
    /// <inheritdoc />
    public partial class dbrelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Descendants");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Events",
                newName: "DescendantId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CalenderUsers",
                newName: "DescendantId");

            migrationBuilder.AlterColumn<int>(
                name: "SpouseID",
                table: "Descendants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MotherID",
                table: "Descendants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FatherID",
                table: "Descendants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SiteUserId",
                table: "Descendants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SiteUserId",
                table: "Calenders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SiteUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_YearEvents_CalenderId",
                table: "YearEvents",
                column: "CalenderId");

            migrationBuilder.CreateIndex(
                name: "IX_YearEvents_EventId",
                table: "YearEvents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CalenderId",
                table: "Events",
                column: "CalenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_DescendantId",
                table: "Events",
                column: "DescendantId");

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

            migrationBuilder.CreateIndex(
                name: "IX_CalenderYears_CalenderId",
                table: "CalenderYears",
                column: "CalenderId");

            migrationBuilder.CreateIndex(
                name: "IX_CalenderUsers_CalenderId",
                table: "CalenderUsers",
                column: "CalenderId");

            migrationBuilder.CreateIndex(
                name: "IX_CalenderUsers_DescendantId",
                table: "CalenderUsers",
                column: "DescendantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Calenders_DirectorId",
                table: "Calenders",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Calenders_SiteUserId",
                table: "Calenders",
                column: "SiteUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calenders_Descendants_DirectorId",
                table: "Calenders",
                column: "DirectorId",
                principalTable: "Descendants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calenders_SiteUsers_SiteUserId",
                table: "Calenders",
                column: "SiteUserId",
                principalTable: "SiteUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CalenderUsers_Calenders_CalenderId",
                table: "CalenderUsers",
                column: "CalenderId",
                principalTable: "Calenders",
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
                name: "FK_CalenderYears_Calenders_CalenderId",
                table: "CalenderYears",
                column: "CalenderId",
                principalTable: "Calenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Descendants_Descendants_FatherID",
                table: "Descendants",
                column: "FatherID",
                principalTable: "Descendants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Descendants_Descendants_MotherID",
                table: "Descendants",
                column: "MotherID",
                principalTable: "Descendants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Descendants_Descendants_SpouseID",
                table: "Descendants",
                column: "SpouseID",
                principalTable: "Descendants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Descendants_SiteUsers_SiteUserId",
                table: "Descendants",
                column: "SiteUserId",
                principalTable: "SiteUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Calenders_CalenderId",
                table: "Events",
                column: "CalenderId",
                principalTable: "Calenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Descendants_DescendantId",
                table: "Events",
                column: "DescendantId",
                principalTable: "Descendants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YearEvents_Calenders_CalenderId",
                table: "YearEvents",
                column: "CalenderId",
                principalTable: "Calenders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_YearEvents_Events_EventId",
                table: "YearEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calenders_Descendants_DirectorId",
                table: "Calenders");

            migrationBuilder.DropForeignKey(
                name: "FK_Calenders_SiteUsers_SiteUserId",
                table: "Calenders");

            migrationBuilder.DropForeignKey(
                name: "FK_CalenderUsers_Calenders_CalenderId",
                table: "CalenderUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CalenderUsers_Descendants_DescendantId",
                table: "CalenderUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CalenderYears_Calenders_CalenderId",
                table: "CalenderYears");

            migrationBuilder.DropForeignKey(
                name: "FK_Descendants_Descendants_FatherID",
                table: "Descendants");

            migrationBuilder.DropForeignKey(
                name: "FK_Descendants_Descendants_MotherID",
                table: "Descendants");

            migrationBuilder.DropForeignKey(
                name: "FK_Descendants_Descendants_SpouseID",
                table: "Descendants");

            migrationBuilder.DropForeignKey(
                name: "FK_Descendants_SiteUsers_SiteUserId",
                table: "Descendants");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Calenders_CalenderId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Descendants_DescendantId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_YearEvents_Calenders_CalenderId",
                table: "YearEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_YearEvents_Events_EventId",
                table: "YearEvents");

            migrationBuilder.DropTable(
                name: "SiteUsers");

            migrationBuilder.DropIndex(
                name: "IX_YearEvents_CalenderId",
                table: "YearEvents");

            migrationBuilder.DropIndex(
                name: "IX_YearEvents_EventId",
                table: "YearEvents");

            migrationBuilder.DropIndex(
                name: "IX_Events_CalenderId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_DescendantId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Descendants_FatherID",
                table: "Descendants");

            migrationBuilder.DropIndex(
                name: "IX_Descendants_MotherID",
                table: "Descendants");

            migrationBuilder.DropIndex(
                name: "IX_Descendants_SiteUserId",
                table: "Descendants");

            migrationBuilder.DropIndex(
                name: "IX_Descendants_SpouseID",
                table: "Descendants");

            migrationBuilder.DropIndex(
                name: "IX_CalenderYears_CalenderId",
                table: "CalenderYears");

            migrationBuilder.DropIndex(
                name: "IX_CalenderUsers_CalenderId",
                table: "CalenderUsers");

            migrationBuilder.DropIndex(
                name: "IX_CalenderUsers_DescendantId",
                table: "CalenderUsers");

            migrationBuilder.DropIndex(
                name: "IX_Calenders_DirectorId",
                table: "Calenders");

            migrationBuilder.DropIndex(
                name: "IX_Calenders_SiteUserId",
                table: "Calenders");

            migrationBuilder.DropColumn(
                name: "SiteUserId",
                table: "Descendants");

            migrationBuilder.DropColumn(
                name: "SiteUserId",
                table: "Calenders");

            migrationBuilder.RenameColumn(
                name: "DescendantId",
                table: "Events",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "DescendantId",
                table: "CalenderUsers",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "SpouseID",
                table: "Descendants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MotherID",
                table: "Descendants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FatherID",
                table: "Descendants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Descendants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }
    }
}
