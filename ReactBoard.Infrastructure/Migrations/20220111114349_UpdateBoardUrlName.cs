using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactBoard.Infrastructure.Migrations
{
    public partial class UpdateBoardUrlName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoardUrlName",
                table: "Board");

            migrationBuilder.AddColumn<string>(
                name: "UrlName",
                table: "Board",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Board_CategoryId",
                table: "Board",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Board_Category_CategoryId",
                table: "Board",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Board_Category_CategoryId",
                table: "Board");

            migrationBuilder.DropIndex(
                name: "IX_Board_CategoryId",
                table: "Board");

            migrationBuilder.DropColumn(
                name: "UrlName",
                table: "Board");

            migrationBuilder.AddColumn<string>(
                name: "BoardUrlName",
                table: "Board",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
