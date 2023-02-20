using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectWithRepositoryDesignPattern.Migrations
{
    public partial class addReletionBetweenQuotesAndAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Quotes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Quotes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_AppUserId",
                table: "Quotes",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_AspNetUsers_AppUserId",
                table: "Quotes",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_AspNetUsers_AppUserId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_AppUserId",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Quotes");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Quotes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
