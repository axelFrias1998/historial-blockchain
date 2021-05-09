using Microsoft.EntityFrameworkCore.Migrations;

namespace historial_blockchain.Migrations.MigrationsApplicationDbContext
{
    public partial class LongitudesDeStrings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_AspNetUsers_AdminId",
                table: "Hospitals");

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
                name: "Type",
                table: "ServicesCatalog",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Hospitals",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hospitals",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdminId",
                table: "Hospitals",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25e9abb4-4ba4-4177-b048-c302b57e42f9", "a1b90b7a-ea46-42ac-8985-b62e19c0bba8", "SysAdmin", "SysAdmin" },
                    { "d7ee7bdd-8443-4d46-83d1-47846b865a9d", "e0069305-3a22-4371-a162-d32e9bdc2e49", "PacsAdmin", "PacsAdmin" },
                    { "23d29712-6c1d-43fd-934f-4d099dacacd3", "5437e09c-1240-4050-b458-1cd18fa94f94", "ClinicAdmin", "ClinicAdmin" },
                    { "e8d22924-ec55-4ccf-85f7-425ec379eb8a", "c5ea6033-e12c-4b16-bc98-1c01f553ab3c", "Pacient", "Pacient" },
                    { "fb081bd5-5380-4a99-8937-194c33d53694", "c215a32c-633d-48e1-ab3f-b915cf25adbc", "Doctor", "Doctor" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_AspNetUsers_AdminId",
                table: "Hospitals",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_AspNetUsers_AdminId",
                table: "Hospitals");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23d29712-6c1d-43fd-934f-4d099dacacd3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25e9abb4-4ba4-4177-b048-c302b57e42f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7ee7bdd-8443-4d46-83d1-47846b865a9d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8d22924-ec55-4ccf-85f7-425ec379eb8a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb081bd5-5380-4a99-8937-194c33d53694");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "ServicesCatalog",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Hospitals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hospitals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "AdminId",
                table: "Hospitals",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_AspNetUsers_AdminId",
                table: "Hospitals",
                column: "AdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
