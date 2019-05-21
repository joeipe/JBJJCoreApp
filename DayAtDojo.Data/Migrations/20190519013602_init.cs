using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DayAtDojo.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DayAtDojo");

            migrationBuilder.CreateTable(
                name: "Attendance",
                schema: "DayAtDojo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TimeTableId = table.Column<int>(nullable: false),
                    AttendedOn = table.Column<DateTime>(nullable: false),
                    TechniqueOfTheDay = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Outcomes",
                schema: "DayAtDojo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outcomes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SparringDetails",
                schema: "DayAtDojo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttendanceId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    OutcomeId = table.Column<int>(nullable: false),
                    TechniqueUsed = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SparringDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SparringDetails_Attendance_AttendanceId",
                        column: x => x.AttendanceId,
                        principalSchema: "DayAtDojo",
                        principalTable: "Attendance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SparringDetails_Outcomes_OutcomeId",
                        column: x => x.OutcomeId,
                        principalSchema: "DayAtDojo",
                        principalTable: "Outcomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SparringDetails_AttendanceId",
                schema: "DayAtDojo",
                table: "SparringDetails",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_SparringDetails_OutcomeId",
                schema: "DayAtDojo",
                table: "SparringDetails",
                column: "OutcomeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SparringDetails",
                schema: "DayAtDojo");

            migrationBuilder.DropTable(
                name: "Attendance",
                schema: "DayAtDojo");

            migrationBuilder.DropTable(
                name: "Outcomes",
                schema: "DayAtDojo");
        }
    }
}