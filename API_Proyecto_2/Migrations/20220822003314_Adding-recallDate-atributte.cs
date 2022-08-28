using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Proyecto_2.Migrations
{
    public partial class AddingrecallDateatributte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RecallDate",
                table: "Articles",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecallDate",
                table: "Articles");
        }
    }
}
