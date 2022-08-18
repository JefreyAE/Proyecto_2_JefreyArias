using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Proyecto_2.Migrations
{
    public partial class Agregando_atributo_code_a_Client : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Clients_ClientId",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_Article_Dispatchers_DispatcherId",
                table: "Article");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Article",
                table: "Article");

            migrationBuilder.RenameTable(
                name: "Article",
                newName: "Articles");

            migrationBuilder.RenameIndex(
                name: "IX_Article_DispatcherId",
                table: "Articles",
                newName: "IX_Articles_DispatcherId");

            migrationBuilder.RenameIndex(
                name: "IX_Article_ClientId",
                table: "Articles",
                newName: "IX_Articles_ClientId");

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articles",
                table: "Articles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Clients_ClientId",
                table: "Articles",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Dispatchers_DispatcherId",
                table: "Articles",
                column: "DispatcherId",
                principalTable: "Dispatchers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Clients_ClientId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Dispatchers_DispatcherId",
                table: "Articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articles",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Articles",
                newName: "Article");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_DispatcherId",
                table: "Article",
                newName: "IX_Article_DispatcherId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_ClientId",
                table: "Article",
                newName: "IX_Article_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Article",
                table: "Article",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Clients_ClientId",
                table: "Article",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Dispatchers_DispatcherId",
                table: "Article",
                column: "DispatcherId",
                principalTable: "Dispatchers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
