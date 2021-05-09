using Microsoft.EntityFrameworkCore.Migrations;

namespace historial_blockchain.Migrations.MigrationsApplicationDbContext
{
    public partial class ServiceCatalogCorregido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Hospitals_AdminId",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_ServiceCatalogId",
                table: "Hospitals");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05f93caa-b9bf-47a9-a809-d4989abd9cf1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e80ca4b-b0ed-4d4f-bce2-70488dbf1478");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "619f1ae8-3e07-4a29-b6b1-ea516809d3ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f0c4ad9-a864-49ea-84e0-ad2ebc3ec5c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2a59a2e-140f-48ec-9d19-af8fe39dffe3");

            migrationBuilder.AlterColumn<string>(
                name: "HospitalId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a1e24c8-0e77-40d2-93ec-01c9f2923816", "3b1cc407-c9cd-4003-911c-92d7c87a5a47", "SysAdmin", "SysAdmin" },
                    { "9301ec3a-ffe0-41d1-b003-64708e976668", "7d264661-3f74-426e-8d2a-f4fe31bbbd1c", "PacsAdmin", "PacsAdmin" },
                    { "7bd1e3a0-df9c-4a7f-a802-38e44a0805b2", "c9b83ea6-c023-4e82-bcc9-ff8c40c09737", "ClinicAdmin", "ClinicAdmin" },
                    { "6325c230-54a1-451c-a9c0-aaa94a029813", "8d1cbcfb-6657-458a-94fd-97ea0252ddaf", "Pacient", "Pacient" },
                    { "1f4092bd-5b64-4c66-9cb0-03a5b05124c5", "18c6b0a7-690b-42ea-b785-30ba0e3b37aa", "Doctor", "Doctor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_AdminId",
                table: "Hospitals",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_ServiceCatalogId",
                table: "Hospitals",
                column: "ServiceCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HospitalId",
                table: "AspNetUsers",
                column: "HospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Hospitals_HospitalId",
                table: "AspNetUsers",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Hospitals_HospitalId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_AdminId",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_ServiceCatalogId",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_HospitalId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f4092bd-5b64-4c66-9cb0-03a5b05124c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a1e24c8-0e77-40d2-93ec-01c9f2923816");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6325c230-54a1-451c-a9c0-aaa94a029813");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bd1e3a0-df9c-4a7f-a802-38e44a0805b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9301ec3a-ffe0-41d1-b003-64708e976668");

            migrationBuilder.AlterColumn<string>(
                name: "HospitalId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "619f1ae8-3e07-4a29-b6b1-ea516809d3ee", "fe2db917-8ed9-4d1f-9e96-79c0f6d30746", "SysAdmin", "SysAdmin" },
                    { "f2a59a2e-140f-48ec-9d19-af8fe39dffe3", "38f90b4c-a099-460e-b3b3-f0bba703e08c", "PacsAdmin", "PacsAdmin" },
                    { "05f93caa-b9bf-47a9-a809-d4989abd9cf1", "5faab9f0-50dc-4f1a-b8e5-2d43c47c6ba4", "ClinicAdmin", "ClinicAdmin" },
                    { "5e80ca4b-b0ed-4d4f-bce2-70488dbf1478", "d4c7f1c7-fe7e-4559-aa05-f13ca7b0f298", "Pacient", "Pacient" },
                    { "7f0c4ad9-a864-49ea-84e0-ad2ebc3ec5c8", "9a21ec0a-8a70-459a-b5f8-002d85fd6401", "Doctor", "Doctor" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_AdminId",
                table: "Hospitals",
                column: "AdminId",
                unique: true,
                filter: "[AdminId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_ServiceCatalogId",
                table: "Hospitals",
                column: "ServiceCatalogId",
                unique: true);
        }
    }
}
