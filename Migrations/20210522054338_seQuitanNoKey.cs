using Microsoft.EntityFrameworkCore.Migrations;

namespace historial_blockchain.Migrations
{
    public partial class seQuitanNoKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c55c00a-7779-4bdb-a913-83cb6691e6a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "532d329c-f1cb-4869-91bf-128e81cd2232");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60960e54-2543-4116-a466-7c7533815295");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ed00ebd-5fcd-4e52-9c85-5c69f9392a51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6e7af9d-ff43-41db-a1c8-e5e7fc1b3f5f");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalEspecialidades",
                table: "HospitalEspecialidades",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalDoctor",
                table: "HospitalDoctor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalConsulta",
                table: "HospitalConsulta",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HospitalAdministrador",
                table: "HospitalAdministrador",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46a5ef55-16bb-49e4-8405-f81d50162428", "e6f19e20-2188-4f0f-912a-806100595c67", "SysAdmin", "SysAdmin" },
                    { "b305c2c6-38fa-441e-b87c-b9ab3c264017", "be9ee729-f450-4fc4-805b-87263812c945", "PacsAdmin", "PacsAdmin" },
                    { "e251fd3c-b2b2-4840-b889-07ba9220d999", "65da9d5f-cbd4-40b1-ab20-8c7cc3467e37", "ClinicAdmin", "ClinicAdmin" },
                    { "d249d1c4-9dc7-40c3-8bf2-f5273d8d4d55", "a29ab80c-bcd2-41ab-881d-63edba869127", "Pacient", "Pacient" },
                    { "0fc35bb9-a849-4d59-a628-c377f2f1e3bd", "2d67fe53-9e07-4106-b8e1-9177bd216aeb", "Doctor", "Doctor" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalEspecialidades",
                table: "HospitalEspecialidades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalDoctor",
                table: "HospitalDoctor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalConsulta",
                table: "HospitalConsulta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HospitalAdministrador",
                table: "HospitalAdministrador");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fc35bb9-a849-4d59-a628-c377f2f1e3bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46a5ef55-16bb-49e4-8405-f81d50162428");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b305c2c6-38fa-441e-b87c-b9ab3c264017");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d249d1c4-9dc7-40c3-8bf2-f5273d8d4d55");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e251fd3c-b2b2-4840-b889-07ba9220d999");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "532d329c-f1cb-4869-91bf-128e81cd2232", "f8577383-339e-4071-9ebe-d73be469eb04", "SysAdmin", "SysAdmin" },
                    { "7ed00ebd-5fcd-4e52-9c85-5c69f9392a51", "1da0b9fa-6473-406d-a92e-726635ac7206", "PacsAdmin", "PacsAdmin" },
                    { "d6e7af9d-ff43-41db-a1c8-e5e7fc1b3f5f", "e8cb6d05-2cd6-48f0-92a7-6e27780f7bca", "ClinicAdmin", "ClinicAdmin" },
                    { "60960e54-2543-4116-a466-7c7533815295", "528f28d6-21aa-4d00-b8e4-32c05f9d7c4a", "Pacient", "Pacient" },
                    { "0c55c00a-7779-4bdb-a913-83cb6691e6a4", "184afb45-cf84-419f-808a-027511f613fd", "Doctor", "Doctor" }
                });
        }
    }
}
