using Microsoft.EntityFrameworkCore.Migrations;

namespace historial_blockchain.Migrations.ManagementDb
{
    public partial class servicescatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServicesCatalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesCatalog", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ServicesCatalog",
                columns: new[] { "Id", "IsPublic", "Type" },
                values: new object[,]
                {
                    { 1, true, "Hospital" },
                    { 2, false, "Hospital" },
                    { 3, true, "Clínica" },
                    { 4, false, "Clínica" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicesCatalog");
        }
    }
}
