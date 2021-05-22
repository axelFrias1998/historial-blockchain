using Microsoft.EntityFrameworkCore.Migrations;

namespace historial_blockchain.Migrations
{
    public partial class hospitalAdministradoresNulos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HospitalAdministrador_AspNetUsers_AdminId",
                table: "HospitalAdministrador");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalAdministrador_Hospitals_HospitalId",
                table: "HospitalAdministrador");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d1a608b5-87cf-4093-aa7f-7ca28a80754d", "b3f75bdd-0b6e-4b48-aac7-23f4897ce68b", "SysAdmin", "SysAdmin" },
                    { "f17cc931-f799-4cef-ada3-9e4a1b3d5a47", "cd260677-ba7c-4982-8b81-42b2f7317938", "PacsAdmin", "PacsAdmin" },
                    { "eb1ece78-a1e9-404d-a647-4bdfe6acd9b3", "de7b8441-7ba1-4bfc-8f37-bc7d34a5b7ac", "ClinicAdmin", "ClinicAdmin" },
                    { "8c02722f-cd50-4436-bff8-d334ee3cb4bf", "b7157334-092b-45a2-8528-6beb2132990b", "Pacient", "Pacient" },
                    { "f43b17e3-8126-42c6-9646-ae5e75bb72f3", "dbbf0deb-a7fb-4bcc-8d0c-48fa0f7e0488", "Doctor", "Doctor" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalAdministrador_AspNetUsers_AdminId",
                table: "HospitalAdministrador",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalAdministrador_Hospitals_HospitalId",
                table: "HospitalAdministrador",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "HospitalId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HospitalAdministrador_AspNetUsers_AdminId",
                table: "HospitalAdministrador");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalAdministrador_Hospitals_HospitalId",
                table: "HospitalAdministrador");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c02722f-cd50-4436-bff8-d334ee3cb4bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1a608b5-87cf-4093-aa7f-7ca28a80754d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb1ece78-a1e9-404d-a647-4bdfe6acd9b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f17cc931-f799-4cef-ada3-9e4a1b3d5a47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f43b17e3-8126-42c6-9646-ae5e75bb72f3");

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

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalAdministrador_AspNetUsers_AdminId",
                table: "HospitalAdministrador",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalAdministrador_Hospitals_HospitalId",
                table: "HospitalAdministrador",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "HospitalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
