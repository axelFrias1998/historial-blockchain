using Microsoft.EntityFrameworkCore.Migrations;

namespace historial_blockchain.Migrations
{
    public partial class ClinicaRuralEncatalogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ecd109b-cd9f-40d5-b218-5c623cbe6bc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fa74b16-1af5-455b-bf88-09ce04585c45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5043dbba-9e37-4057-8130-310f5b570d34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78902708-5c20-4fba-9c7f-cf0bed718df6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1c569cc-5a38-4c4f-9071-d86300bf3832");

            migrationBuilder.DeleteData(
                table: "SpecialitiesCatalog",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3dad77b4-236c-41df-9949-4c7d36af9e98", "0759a95b-1702-4491-ae0b-a08a991cfb9b", "SysAdmin", "SysAdmin" },
                    { "036c6c21-7003-4903-9c1f-9c41a1f316ff", "ccecec48-fe2d-4460-a44c-b2e10dd882d3", "PacsAdmin", "PacsAdmin" },
                    { "ce56e3fd-ba01-465e-9b17-8b19b138b085", "ad6e96ad-9d69-4d7c-a566-a1d60671e0a5", "ClinicAdmin", "ClinicAdmin" },
                    { "42375587-5fe3-42c0-92ba-2851706398ef", "661c75b9-ea16-4624-8097-cbceca626e2e", "Pacient", "Pacient" },
                    { "f5d67d7b-cb59-4bac-bdc0-34afc993bd62", "f04ec776-d081-41c9-9fae-1fa9aa5643fb", "Doctor", "Doctor" }
                });

            migrationBuilder.InsertData(
                table: "ServicesCatalog",
                columns: new[] { "Id", "IsPublic", "Type" },
                values: new object[] { 5, false, "Clínica rural pública" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "036c6c21-7003-4903-9c1f-9c41a1f316ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3dad77b4-236c-41df-9949-4c7d36af9e98");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42375587-5fe3-42c0-92ba-2851706398ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce56e3fd-ba01-465e-9b17-8b19b138b085");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5d67d7b-cb59-4bac-bdc0-34afc993bd62");

            migrationBuilder.DeleteData(
                table: "ServicesCatalog",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5043dbba-9e37-4057-8130-310f5b570d34", "33cf1275-9670-45d8-897e-c33be9485931", "SysAdmin", "SysAdmin" },
                    { "78902708-5c20-4fba-9c7f-cf0bed718df6", "1402de2a-a192-4bb4-a7a5-b993ed97ec6a", "PacsAdmin", "PacsAdmin" },
                    { "d1c569cc-5a38-4c4f-9071-d86300bf3832", "fac9a681-52b9-478c-be42-c7892e2b5017", "ClinicAdmin", "ClinicAdmin" },
                    { "2fa74b16-1af5-455b-bf88-09ce04585c45", "59a81139-ebc7-4eda-ba5a-8611f8fe7221", "Pacient", "Pacient" },
                    { "0ecd109b-cd9f-40d5-b218-5c623cbe6bc2", "a7d03417-4b4a-49f7-98c3-c9754ee9eb80", "Doctor", "Doctor" }
                });

            migrationBuilder.InsertData(
                table: "SpecialitiesCatalog",
                columns: new[] { "Id", "Type" },
                values: new object[] { 6, "Prueba" });
        }
    }
}
