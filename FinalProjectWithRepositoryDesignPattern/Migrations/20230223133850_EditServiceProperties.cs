using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectWithRepositoryDesignPattern.Migrations
{
    public partial class EditServiceProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "Services",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Services",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Services",
                newName: "Icon");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Services",
                newName: "Description");
        }
    }
}
