using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boardgames.Migrations
{
    public partial class UpdateBoardgameId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardgamesSellers_Boardgames_BoardGameId",
                table: "BoardgamesSellers");

            migrationBuilder.RenameColumn(
                name: "BoardGameId",
                table: "BoardgamesSellers",
                newName: "BoardgameId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardgamesSellers_Boardgames_BoardgameId",
                table: "BoardgamesSellers",
                column: "BoardgameId",
                principalTable: "Boardgames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardgamesSellers_Boardgames_BoardgameId",
                table: "BoardgamesSellers");

            migrationBuilder.RenameColumn(
                name: "BoardgameId",
                table: "BoardgamesSellers",
                newName: "BoardGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardgamesSellers_Boardgames_BoardGameId",
                table: "BoardgamesSellers",
                column: "BoardGameId",
                principalTable: "Boardgames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
