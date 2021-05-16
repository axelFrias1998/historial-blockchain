using Microsoft.EntityFrameworkCore.Migrations;

namespace historial_blockchain.Migrations
{
    public partial class idEnModelBuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HospitalEspecialidad_Hospitals_HospitalId",
                table: "HospitalEspecialidad");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalEspecialidad_SpecialitiesCatalog_EspecialidadId",
                table: "HospitalEspecialidad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalEspecialidad",
                table: "HospitalEspecialidad");

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

            migrationBuilder.RenameTable(
                name: "HospitalEspecialidad",
                newName: "HospitalEspecialidades");

            migrationBuilder.RenameIndex(
                name: "IX_HospitalEspecialidad_HospitalId",
                table: "HospitalEspecialidades",
                newName: "IX_HospitalEspecialidades_HospitalId");

            migrationBuilder.AddColumn<bool>(
                name: "IsEnable",
                table: "Hospitals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalEspecialidades",
                table: "HospitalEspecialidades",
                columns: new[] { "EspecialidadId", "HospitalId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalEspecialidades_Hospitals_HospitalId",
                table: "HospitalEspecialidades",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "HospitalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalEspecialidades_SpecialitiesCatalog_EspecialidadId",
                table: "HospitalEspecialidades",
                column: "EspecialidadId",
                principalTable: "SpecialitiesCatalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HospitalEspecialidades_Hospitals_HospitalId",
                table: "HospitalEspecialidades");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalEspecialidades_SpecialitiesCatalog_EspecialidadId",
                table: "HospitalEspecialidades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalEspecialidades",
                table: "HospitalEspecialidades");

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
                name: "IsEnable",
                table: "Hospitals");

            migrationBuilder.RenameTable(
                name: "HospitalEspecialidades",
                newName: "HospitalEspecialidad");

            migrationBuilder.RenameIndex(
                name: "IX_HospitalEspecialidades_HospitalId",
                table: "HospitalEspecialidad",
                newName: "IX_HospitalEspecialidad_HospitalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalEspecialidad",
                table: "HospitalEspecialidad",
                columns: new[] { "EspecialidadId", "HospitalId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalEspecialidad_Hospitals_HospitalId",
                table: "HospitalEspecialidad",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "HospitalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalEspecialidad_SpecialitiesCatalog_EspecialidadId",
                table: "HospitalEspecialidad",
                column: "EspecialidadId",
                principalTable: "SpecialitiesCatalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
