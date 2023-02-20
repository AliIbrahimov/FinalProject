using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProjectWithRepositoryDesignPattern.Migrations
{
    public partial class AddStatisticsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HappyClients = table.Column<int>(type: "int", nullable: false),
                    HappyClientsIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectsDone = table.Column<int>(type: "int", nullable: false),
                    ProjectsDoneIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WinAwards = table.Column<int>(type: "int", nullable: false),
                    WinAwardsIcon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistics");
        }
    }
}
