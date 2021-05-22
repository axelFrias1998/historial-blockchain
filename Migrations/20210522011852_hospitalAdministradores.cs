using Microsoft.EntityFrameworkCore.Migrations;

namespace historial_blockchain.Migrations
{
    public partial class hospitalAdministradores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_AspNetUsers_AdminId",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_AdminId",
                table: "Hospitals");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0feb0fe4-bd75-46b6-a801-7096b99daf05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e337817-079b-4bbf-a4c8-658d15947f4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d2fa19e-4563-4c87-a382-9b67c086d117");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ca74fdb-2285-4e81-bca6-242c6f4731e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9d3cf77-ac36-4d02-bb74-d7651485a632");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Hospitals");

            migrationBuilder.CreateTable(
                name: "HospitalAdministrador",
                columns: table => new
                {
                    AdminId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HospitalId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalAdministrador", x => new { x.AdminId, x.HospitalId });
                    table.ForeignKey(
                        name: "FK_HospitalAdministrador_AspNetUsers_AdminId",
                        column: x => x.AdminId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospitalAdministrador_Hospitals_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospitals",
                        principalColumn: "HospitalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c1e1037a-89c7-4c83-8e82-b1d263990545", "889c8082-9490-4baf-a45f-05a08279b623", "SysAdmin", "SysAdmin" },
                    { "3e4045af-1646-4a9f-af7d-b1ab7e8a1ce9", "990ffbf9-5846-4901-810e-c1031b19a2e9", "PacsAdmin", "PacsAdmin" },
                    { "3da6701e-5f7c-437b-b49c-6cc5e82fe3f0", "2553a691-a38e-4a80-9cb4-1ad284c92585", "ClinicAdmin", "ClinicAdmin" },
                    { "890a3741-0777-47ec-97fa-b98f5367eacb", "f4149eb5-1417-4e4f-abc7-6b46e4705e6d", "Pacient", "Pacient" },
                    { "1484ac9b-68b0-445a-be74-a8b7f2027977", "6cd29492-d92b-4cab-a2ad-35eef571f0cd", "Doctor", "Doctor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HospitalAdministrador_HospitalId",
                table: "HospitalAdministrador",
                column: "HospitalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HospitalAdministrador");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1484ac9b-68b0-445a-be74-a8b7f2027977");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3da6701e-5f7c-437b-b49c-6cc5e82fe3f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e4045af-1646-4a9f-af7d-b1ab7e8a1ce9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "890a3741-0777-47ec-97fa-b98f5367eacb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1e1037a-89c7-4c83-8e82-b1d263990545");

            migrationBuilder.AddColumn<string>(
                name: "AdminId",
                table: "Hospitals",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d2fa19e-4563-4c87-a382-9b67c086d117", "bf8e5901-1014-4d84-9d45-dc9923bba7e6", "SysAdmin", "SysAdmin" },
                    { "0feb0fe4-bd75-46b6-a801-7096b99daf05", "0bd8dcfc-9e98-4e81-b38c-428f141e1a3c", "PacsAdmin", "PacsAdmin" },
                    { "9ca74fdb-2285-4e81-bca6-242c6f4731e0", "03d979ad-7dd3-4f2c-a757-1b8ae1d84c86", "ClinicAdmin", "ClinicAdmin" },
                    { "a9d3cf77-ac36-4d02-bb74-d7651485a632", "2d201d41-d29e-4246-a325-ef43ae78a750", "Pacient", "Pacient" },
                    { "1e337817-079b-4bbf-a4c8-658d15947f4f", "e3ae400b-162f-402a-9d93-0d9eb1429fb5", "Doctor", "Doctor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_AdminId",
                table: "Hospitals",
                column: "AdminId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_AspNetUsers_AdminId",
                table: "Hospitals",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
