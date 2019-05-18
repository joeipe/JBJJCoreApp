using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DayAtDojo.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DayAtDojo");

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
                name: "PersonSparringPartner",
                schema: "DayAtDojo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: true),
                    Stripe = table.Column<int>(nullable: false),
                    Grade = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonSparringPartner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeTableClassAttended",
                schema: "DayAtDojo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DayofWeek = table.Column<string>(nullable: true),
                    StartTimeHr = table.Column<int>(nullable: false),
                    StartTimeMin = table.Column<int>(nullable: false),
                    EndTimeHr = table.Column<int>(nullable: false),
                    EndTimeMin = table.Column<int>(nullable: false),
                    ClassType = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTableClassAttended", x => x.Id);
                });

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
                    TimeTableClassAttendedId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendance_TimeTableClassAttended_TimeTableClassAttendedId",
                        column: x => x.TimeTableClassAttendedId,
                        principalSchema: "DayAtDojo",
                        principalTable: "TimeTableClassAttended",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    PersonSparringPartnerId = table.Column<int>(nullable: true),
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
                    table.ForeignKey(
                        name: "FK_SparringDetails_PersonSparringPartner_PersonSparringPartnerId",
                        column: x => x.PersonSparringPartnerId,
                        principalSchema: "DayAtDojo",
                        principalTable: "PersonSparringPartner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_TimeTableClassAttendedId",
                schema: "DayAtDojo",
                table: "Attendance",
                column: "TimeTableClassAttendedId");

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

            migrationBuilder.CreateIndex(
                name: "IX_SparringDetails_PersonSparringPartnerId",
                schema: "DayAtDojo",
                table: "SparringDetails",
                column: "PersonSparringPartnerId");
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

            migrationBuilder.DropTable(
                name: "PersonSparringPartner",
                schema: "DayAtDojo");

            migrationBuilder.DropTable(
                name: "TimeTableClassAttended",
                schema: "DayAtDojo");
        }
    }
}
