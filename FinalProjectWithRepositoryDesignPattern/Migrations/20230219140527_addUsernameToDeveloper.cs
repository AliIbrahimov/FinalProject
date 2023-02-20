using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectWithRepositoryDesignPattern.Migrations
{
    public partial class addUsernameToDeveloper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Developers");
        }
    }
}
