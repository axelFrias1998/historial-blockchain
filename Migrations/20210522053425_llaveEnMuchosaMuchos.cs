using Microsoft.EntityFrameworkCore.Migrations;

namespace historial_blockchain.Migrations
{
    public partial class llaveEnMuchosaMuchos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HospitalConsulta_Consultas_ConsultaId",
                table: "HospitalConsulta");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalConsulta_Hospitals_HospitalId",
                table: "HospitalConsulta");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalDoctor_AspNetUsers_DoctorId",
                table: "HospitalDoctor");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalDoctor_Hospitals_HospitalId",
                table: "HospitalDoctor");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalEspecialidades_Hospitals_HospitalId",
                table: "HospitalEspecialidades");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "128808ae-065b-4f85-95e7-b3f61d7df5f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "481f42dc-a4b7-4693-9011-ac29b332891d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ab79905-b757-4956-b573-5ae70f93fbec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2e2f8b7-bf31-4966-b805-943984d4114e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcb092e5-e0d9-46e9-a36e-85844cc0a829");

            migrationBuilder.AlterColumn<string>(
                name: "HospitalId",
                table: "HospitalEspecialidades",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HospitalEspecialidades",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "HospitalId",
                table: "HospitalDoctor",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "HospitalDoctor",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HospitalDoctor",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "HospitalId",
                table: "HospitalConsulta",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ConsultaId",
                table: "HospitalConsulta",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HospitalConsulta",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HospitalAdministrador",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalConsulta_Consultas_ConsultaId",
                table: "HospitalConsulta",
                column: "ConsultaId",
                principalTable: "Consultas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalConsulta_Hospitals_HospitalId",
                table: "HospitalConsulta",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "HospitalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalDoctor_AspNetUsers_DoctorId",
                table: "HospitalDoctor",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalDoctor_Hospitals_HospitalId",
                table: "HospitalDoctor",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "HospitalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalEspecialidades_Hospitals_HospitalId",
                table: "HospitalEspecialidades",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "HospitalId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HospitalConsulta_Consultas_ConsultaId",
                table: "HospitalConsulta");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalConsulta_Hospitals_HospitalId",
                table: "HospitalConsulta");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalDoctor_AspNetUsers_DoctorId",
                table: "HospitalDoctor");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalDoctor_Hospitals_HospitalId",
                table: "HospitalDoctor");

            migrationBuilder.DropForeignKey(
                name: "FK_HospitalEspecialidades_Hospitals_HospitalId",
                table: "HospitalEspecialidades");

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

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HospitalEspecialidades");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HospitalDoctor");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HospitalConsulta");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HospitalAdministrador");

            migrationBuilder.AlterColumn<string>(
                name: "HospitalId",
                table: "HospitalEspecialidades",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HospitalId",
                table: "HospitalDoctor",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "HospitalDoctor",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HospitalId",
                table: "HospitalConsulta",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConsultaId",
                table: "HospitalConsulta",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c2e2f8b7-bf31-4966-b805-943984d4114e", "80cbd1a5-75d6-4edd-abf3-b2607d7c9fbb", "SysAdmin", "SysAdmin" },
                    { "128808ae-065b-4f85-95e7-b3f61d7df5f2", "edbc2fec-d350-480c-afc6-7e1ffd702cf8", "PacsAdmin", "PacsAdmin" },
                    { "fcb092e5-e0d9-46e9-a36e-85844cc0a829", "ebcf809d-e501-4412-80e7-98470bf680be", "ClinicAdmin", "ClinicAdmin" },
                    { "481f42dc-a4b7-4693-9011-ac29b332891d", "a66dd545-cb8a-4818-899c-15d931675124", "Pacient", "Pacient" },
                    { "6ab79905-b757-4956-b573-5ae70f93fbec", "c6698f74-26e0-49b6-ad16-27310ca4842a", "Doctor", "Doctor" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalConsulta_Consultas_ConsultaId",
                table: "HospitalConsulta",
                column: "ConsultaId",
                principalTable: "Consultas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalConsulta_Hospitals_HospitalId",
                table: "HospitalConsulta",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "HospitalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalDoctor_AspNetUsers_DoctorId",
                table: "HospitalDoctor",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalDoctor_Hospitals_HospitalId",
                table: "HospitalDoctor",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "HospitalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HospitalEspecialidades_Hospitals_HospitalId",
                table: "HospitalEspecialidades",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "HospitalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
