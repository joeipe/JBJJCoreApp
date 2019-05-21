using Microsoft.EntityFrameworkCore.Migrations;

namespace Student.Data.Migrations
{
    public partial class AddPersonListView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql
                (
                @"CREATE VIEW Student.PersonList AS
                    SELECT P.Id, P.FirstName + ' ' + P.LastName FullName, P.Stripe, G.Name Grade
                    FROM Student.People P
                    inner join Student.Grades G on G.Id=P.GradeId"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW Student.PersonList");
        }
    }
}