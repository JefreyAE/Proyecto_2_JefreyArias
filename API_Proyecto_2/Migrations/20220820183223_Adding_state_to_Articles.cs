using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Proyecto_2.Migrations
{
    public partial class Adding_state_to_Articles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Articles");
        }
    }
}
