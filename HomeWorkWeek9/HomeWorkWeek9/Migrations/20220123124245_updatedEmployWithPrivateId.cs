using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeWorkWeek9.Migrations
{
    public partial class updatedEmployWithPrivateId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrivateId",
                table: "Employs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrivateId",
                table: "Employs");
        }
    }
}
