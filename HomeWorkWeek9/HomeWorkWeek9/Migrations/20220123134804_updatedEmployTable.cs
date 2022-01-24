using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeWorkWeek9.Migrations
{
    public partial class updatedEmployTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FetchedData",
                table: "Employs",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastFetchDate",
                table: "Employs",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FetchedData",
                table: "Employs");

            migrationBuilder.DropColumn(
                name: "LastFetchDate",
                table: "Employs");
        }
    }
}
