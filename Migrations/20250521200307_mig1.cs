using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LGS_Tracking_Application.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    TGID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    TurkishTrueNumber = table.Column<int>(type: "int", nullable: false),
                    TurkishFalseNumber = table.Column<int>(type: "int", nullable: false),
                    MathTrueNumber = table.Column<int>(type: "int", nullable: false),
                    MathFalseNumber = table.Column<int>(type: "int", nullable: false),
                    ScienceTrueNumber = table.Column<int>(type: "int", nullable: false),
                    ScienceFalseNumber = table.Column<int>(type: "int", nullable: false),
                    HistoryTrueNumber = table.Column<int>(type: "int", nullable: false),
                    HistoryFalseNumber = table.Column<int>(type: "int", nullable: false),
                    ReligionTrueNumber = table.Column<int>(type: "int", nullable: false),
                    ReligionFalseNumber = table.Column<int>(type: "int", nullable: false),
                    EnglishTrueNumber = table.Column<int>(type: "int", nullable: false),
                    EnglishFalseNumber = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_UserId",
                table: "Results",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
