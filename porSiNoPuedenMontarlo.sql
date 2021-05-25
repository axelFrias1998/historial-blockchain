Build started...
Build succeeded.
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [Nombre] nvarchar(100) NOT NULL,
    [Apellido] nvarchar(100) NOT NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [ServicesCatalog] (
    [Id] int NOT NULL IDENTITY,
    [Type] nvarchar(50) NULL,
    [IsPublic] bit NOT NULL,
    CONSTRAINT [PK_ServicesCatalog] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [SpecialitiesCatalog] (
    [Id] int NOT NULL IDENTITY,
    [Type] nvarchar(max) NULL,
    CONSTRAINT [PK_SpecialitiesCatalog] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Consultas] (
    [Id] nvarchar(450) NOT NULL,
    [DateStamp] datetime2 NOT NULL,
    [PacienteId] nvarchar(450) NULL,
    [DoctorId] nvarchar(450) NULL,
    CONSTRAINT [PK_Consultas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Consultas_AspNetUsers_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Consultas_AspNetUsers_PacienteId] FOREIGN KEY ([PacienteId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Hospitals] (
    [HospitalId] nvarchar(450) NOT NULL,
    [Name] nvarchar(150) NOT NULL,
    [PhoneNumber] nvarchar(20) NOT NULL,
    [RegisterDate] datetime2 NOT NULL,
    [ServiceCatalogId] int NOT NULL,
    [AdminId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_Hospitals] PRIMARY KEY ([HospitalId]),
    CONSTRAINT [FK_Hospitals_AspNetUsers_AdminId] FOREIGN KEY ([AdminId]) REFERENCES [AspNetUsers] ([Id]),
    CONSTRAINT [FK_Hospitals_ServicesCatalog_ServiceCatalogId] FOREIGN KEY ([ServiceCatalogId]) REFERENCES [ServicesCatalog] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [HospitalConsulta] (
    [ConsultaId] nvarchar(450) NOT NULL,
    [HospitalId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_HospitalConsulta] PRIMARY KEY ([ConsultaId], [HospitalId]),
    CONSTRAINT [FK_HospitalConsulta_Consultas_ConsultaId] FOREIGN KEY ([ConsultaId]) REFERENCES [Consultas] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_HospitalConsulta_Hospitals_HospitalId] FOREIGN KEY ([HospitalId]) REFERENCES [Hospitals] ([HospitalId]) ON DELETE CASCADE
);
GO

CREATE TABLE [HospitalDoctor] (
    [DoctorId] nvarchar(450) NOT NULL,
    [HospitalId] nvarchar(450) NOT NULL,
    [EspecialidadId] int NOT NULL,
    CONSTRAINT [PK_HospitalDoctor] PRIMARY KEY ([DoctorId], [HospitalId]),
    CONSTRAINT [FK_HospitalDoctor_AspNetUsers_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_HospitalDoctor_Hospitals_HospitalId] FOREIGN KEY ([HospitalId]) REFERENCES [Hospitals] ([HospitalId]) ON DELETE CASCADE,
    CONSTRAINT [FK_HospitalDoctor_SpecialitiesCatalog_EspecialidadId] FOREIGN KEY ([EspecialidadId]) REFERENCES [SpecialitiesCatalog] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [HospitalEspecialidad] (
    [EspecialidadId] int NOT NULL,
    [HospitalId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_HospitalEspecialidad] PRIMARY KEY ([EspecialidadId], [HospitalId]),
    CONSTRAINT [FK_HospitalEspecialidad_Hospitals_HospitalId] FOREIGN KEY ([HospitalId]) REFERENCES [Hospitals] ([HospitalId]) ON DELETE CASCADE,
    CONSTRAINT [FK_HospitalEspecialidad_SpecialitiesCatalog_EspecialidadId] FOREIGN KEY ([EspecialidadId]) REFERENCES [SpecialitiesCatalog] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] ON;
INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
VALUES (N'5043dbba-9e37-4057-8130-310f5b570d34', N'33cf1275-9670-45d8-897e-c33be9485931', N'SysAdmin', N'SysAdmin'),
(N'78902708-5c20-4fba-9c7f-cf0bed718df6', N'1402de2a-a192-4bb4-a7a5-b993ed97ec6a', N'PacsAdmin', N'PacsAdmin'),
(N'd1c569cc-5a38-4c4f-9071-d86300bf3832', N'fac9a681-52b9-478c-be42-c7892e2b5017', N'ClinicAdmin', N'ClinicAdmin'),
(N'2fa74b16-1af5-455b-bf88-09ce04585c45', N'59a81139-ebc7-4eda-ba5a-8611f8fe7221', N'Pacient', N'Pacient'),
(N'0ecd109b-cd9f-40d5-b218-5c623cbe6bc2', N'a7d03417-4b4a-49f7-98c3-c9754ee9eb80', N'Doctor', N'Doctor');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsPublic', N'Type') AND [object_id] = OBJECT_ID(N'[ServicesCatalog]'))
    SET IDENTITY_INSERT [ServicesCatalog] ON;
INSERT INTO [ServicesCatalog] ([Id], [IsPublic], [Type])
VALUES (1, CAST(1 AS bit), N'Hospital público'),
(2, CAST(0 AS bit), N'Hospital privado'),
(3, CAST(1 AS bit), N'Clínica pública'),
(4, CAST(0 AS bit), N'Clínica privada');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsPublic', N'Type') AND [object_id] = OBJECT_ID(N'[ServicesCatalog]'))
    SET IDENTITY_INSERT [ServicesCatalog] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Type') AND [object_id] = OBJECT_ID(N'[SpecialitiesCatalog]'))
    SET IDENTITY_INSERT [SpecialitiesCatalog] ON;
INSERT INTO [SpecialitiesCatalog] ([Id], [Type])
VALUES (1, N'Pediatría'),
(2, N'Ginecología'),
(3, N'Geriatría'),
(4, N'Odontología'),
(5, N'General'),
(6, N'Prueba');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Type') AND [object_id] = OBJECT_ID(N'[SpecialitiesCatalog]'))
    SET IDENTITY_INSERT [SpecialitiesCatalog] OFF;
GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;
GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
GO

CREATE INDEX [IX_Consultas_DoctorId] ON [Consultas] ([DoctorId]);
GO

CREATE INDEX [IX_Consultas_PacienteId] ON [Consultas] ([PacienteId]);
GO

CREATE INDEX [IX_HospitalConsulta_HospitalId] ON [HospitalConsulta] ([HospitalId]);
GO

CREATE INDEX [IX_HospitalDoctor_EspecialidadId] ON [HospitalDoctor] ([EspecialidadId]);
GO

CREATE INDEX [IX_HospitalDoctor_HospitalId] ON [HospitalDoctor] ([HospitalId]);
GO

CREATE INDEX [IX_HospitalEspecialidad_HospitalId] ON [HospitalEspecialidad] ([HospitalId]);
GO

CREATE UNIQUE INDEX [IX_Hospitals_AdminId] ON [Hospitals] ([AdminId]);
GO

CREATE INDEX [IX_Hospitals_ServiceCatalogId] ON [Hospitals] ([ServiceCatalogId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210516052135_modeloBaseDeDatos', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'0ecd109b-cd9f-40d5-b218-5c623cbe6bc2';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'2fa74b16-1af5-455b-bf88-09ce04585c45';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'5043dbba-9e37-4057-8130-310f5b570d34';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'78902708-5c20-4fba-9c7f-cf0bed718df6';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'd1c569cc-5a38-4c4f-9071-d86300bf3832';
SELECT @@ROWCOUNT;

GO

DELETE FROM [SpecialitiesCatalog]
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] ON;
INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
VALUES (N'3dad77b4-236c-41df-9949-4c7d36af9e98', N'0759a95b-1702-4491-ae0b-a08a991cfb9b', N'SysAdmin', N'SysAdmin'),
(N'036c6c21-7003-4903-9c1f-9c41a1f316ff', N'ccecec48-fe2d-4460-a44c-b2e10dd882d3', N'PacsAdmin', N'PacsAdmin'),
(N'ce56e3fd-ba01-465e-9b17-8b19b138b085', N'ad6e96ad-9d69-4d7c-a566-a1d60671e0a5', N'ClinicAdmin', N'ClinicAdmin'),
(N'42375587-5fe3-42c0-92ba-2851706398ef', N'661c75b9-ea16-4624-8097-cbceca626e2e', N'Pacient', N'Pacient'),
(N'f5d67d7b-cb59-4bac-bdc0-34afc993bd62', N'f04ec776-d081-41c9-9fae-1fa9aa5643fb', N'Doctor', N'Doctor');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsPublic', N'Type') AND [object_id] = OBJECT_ID(N'[ServicesCatalog]'))
    SET IDENTITY_INSERT [ServicesCatalog] ON;
INSERT INTO [ServicesCatalog] ([Id], [IsPublic], [Type])
VALUES (5, CAST(0 AS bit), N'Clínica rural pública');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsPublic', N'Type') AND [object_id] = OBJECT_ID(N'[ServicesCatalog]'))
    SET IDENTITY_INSERT [ServicesCatalog] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210516061932_ClinicaRuralEncatalogo', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [HospitalEspecialidad] DROP CONSTRAINT [FK_HospitalEspecialidad_Hospitals_HospitalId];
GO

ALTER TABLE [HospitalEspecialidad] DROP CONSTRAINT [FK_HospitalEspecialidad_SpecialitiesCatalog_EspecialidadId];
GO

ALTER TABLE [HospitalEspecialidad] DROP CONSTRAINT [PK_HospitalEspecialidad];
GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'036c6c21-7003-4903-9c1f-9c41a1f316ff';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'3dad77b4-236c-41df-9949-4c7d36af9e98';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'42375587-5fe3-42c0-92ba-2851706398ef';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'ce56e3fd-ba01-465e-9b17-8b19b138b085';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'f5d67d7b-cb59-4bac-bdc0-34afc993bd62';
SELECT @@ROWCOUNT;

GO

DELETE FROM [ServicesCatalog]
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

EXEC sp_rename N'[HospitalEspecialidad]', N'HospitalEspecialidades';
GO

EXEC sp_rename N'[HospitalEspecialidades].[IX_HospitalEspecialidad_HospitalId]', N'IX_HospitalEspecialidades_HospitalId', N'INDEX';
GO

ALTER TABLE [Hospitals] ADD [IsEnable] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

ALTER TABLE [HospitalEspecialidades] ADD CONSTRAINT [PK_HospitalEspecialidades] PRIMARY KEY ([EspecialidadId], [HospitalId]);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] ON;
INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
VALUES (N'4d2fa19e-4563-4c87-a382-9b67c086d117', N'bf8e5901-1014-4d84-9d45-dc9923bba7e6', N'SysAdmin', N'SysAdmin'),
(N'0feb0fe4-bd75-46b6-a801-7096b99daf05', N'0bd8dcfc-9e98-4e81-b38c-428f141e1a3c', N'PacsAdmin', N'PacsAdmin'),
(N'9ca74fdb-2285-4e81-bca6-242c6f4731e0', N'03d979ad-7dd3-4f2c-a757-1b8ae1d84c86', N'ClinicAdmin', N'ClinicAdmin'),
(N'a9d3cf77-ac36-4d02-bb74-d7651485a632', N'2d201d41-d29e-4246-a325-ef43ae78a750', N'Pacient', N'Pacient'),
(N'1e337817-079b-4bbf-a4c8-658d15947f4f', N'e3ae400b-162f-402a-9d93-0d9eb1429fb5', N'Doctor', N'Doctor');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] OFF;
GO

ALTER TABLE [HospitalEspecialidades] ADD CONSTRAINT [FK_HospitalEspecialidades_Hospitals_HospitalId] FOREIGN KEY ([HospitalId]) REFERENCES [Hospitals] ([HospitalId]) ON DELETE CASCADE;
GO

ALTER TABLE [HospitalEspecialidades] ADD CONSTRAINT [FK_HospitalEspecialidades_SpecialitiesCatalog_EspecialidadId] FOREIGN KEY ([EspecialidadId]) REFERENCES [SpecialitiesCatalog] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210516082049_idEnModelBuilder', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Hospitals] DROP CONSTRAINT [FK_Hospitals_AspNetUsers_AdminId];
GO

DROP INDEX [IX_Hospitals_AdminId] ON [Hospitals];
GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'0feb0fe4-bd75-46b6-a801-7096b99daf05';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'1e337817-079b-4bbf-a4c8-658d15947f4f';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'4d2fa19e-4563-4c87-a382-9b67c086d117';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'9ca74fdb-2285-4e81-bca6-242c6f4731e0';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'a9d3cf77-ac36-4d02-bb74-d7651485a632';
SELECT @@ROWCOUNT;

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Hospitals]') AND [c].[name] = N'AdminId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Hospitals] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Hospitals] DROP COLUMN [AdminId];
GO

CREATE TABLE [HospitalAdministrador] (
    [AdminId] nvarchar(450) NOT NULL,
    [HospitalId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_HospitalAdministrador] PRIMARY KEY ([AdminId], [HospitalId]),
    CONSTRAINT [FK_HospitalAdministrador_AspNetUsers_AdminId] FOREIGN KEY ([AdminId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_HospitalAdministrador_Hospitals_HospitalId] FOREIGN KEY ([HospitalId]) REFERENCES [Hospitals] ([HospitalId]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] ON;
INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
VALUES (N'c1e1037a-89c7-4c83-8e82-b1d263990545', N'889c8082-9490-4baf-a45f-05a08279b623', N'SysAdmin', N'SysAdmin'),
(N'3e4045af-1646-4a9f-af7d-b1ab7e8a1ce9', N'990ffbf9-5846-4901-810e-c1031b19a2e9', N'PacsAdmin', N'PacsAdmin'),
(N'3da6701e-5f7c-437b-b49c-6cc5e82fe3f0', N'2553a691-a38e-4a80-9cb4-1ad284c92585', N'ClinicAdmin', N'ClinicAdmin'),
(N'890a3741-0777-47ec-97fa-b98f5367eacb', N'f4149eb5-1417-4e4f-abc7-6b46e4705e6d', N'Pacient', N'Pacient'),
(N'1484ac9b-68b0-445a-be74-a8b7f2027977', N'6cd29492-d92b-4cab-a2ad-35eef571f0cd', N'Doctor', N'Doctor');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] OFF;
GO

CREATE INDEX [IX_HospitalAdministrador_HospitalId] ON [HospitalAdministrador] ([HospitalId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210522011852_hospitalAdministradores', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [HospitalAdministrador] DROP CONSTRAINT [FK_HospitalAdministrador_AspNetUsers_AdminId];
GO

ALTER TABLE [HospitalAdministrador] DROP CONSTRAINT [FK_HospitalAdministrador_Hospitals_HospitalId];
GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'1484ac9b-68b0-445a-be74-a8b7f2027977';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'3da6701e-5f7c-437b-b49c-6cc5e82fe3f0';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'3e4045af-1646-4a9f-af7d-b1ab7e8a1ce9';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'890a3741-0777-47ec-97fa-b98f5367eacb';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'c1e1037a-89c7-4c83-8e82-b1d263990545';
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] ON;
INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
VALUES (N'd1a608b5-87cf-4093-aa7f-7ca28a80754d', N'b3f75bdd-0b6e-4b48-aac7-23f4897ce68b', N'SysAdmin', N'SysAdmin'),
(N'f17cc931-f799-4cef-ada3-9e4a1b3d5a47', N'cd260677-ba7c-4982-8b81-42b2f7317938', N'PacsAdmin', N'PacsAdmin'),
(N'eb1ece78-a1e9-404d-a647-4bdfe6acd9b3', N'de7b8441-7ba1-4bfc-8f37-bc7d34a5b7ac', N'ClinicAdmin', N'ClinicAdmin'),
(N'8c02722f-cd50-4436-bff8-d334ee3cb4bf', N'b7157334-092b-45a2-8528-6beb2132990b', N'Pacient', N'Pacient'),
(N'f43b17e3-8126-42c6-9646-ae5e75bb72f3', N'dbbf0deb-a7fb-4bcc-8d0c-48fa0f7e0488', N'Doctor', N'Doctor');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] OFF;
GO

ALTER TABLE [HospitalAdministrador] ADD CONSTRAINT [FK_HospitalAdministrador_AspNetUsers_AdminId] FOREIGN KEY ([AdminId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
GO

ALTER TABLE [HospitalAdministrador] ADD CONSTRAINT [FK_HospitalAdministrador_Hospitals_HospitalId] FOREIGN KEY ([HospitalId]) REFERENCES [Hospitals] ([HospitalId]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210522052313_hospitalAdministradoresNulos', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [HospitalConsulta] DROP CONSTRAINT [PK_HospitalConsulta];
GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'8c02722f-cd50-4436-bff8-d334ee3cb4bf';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'd1a608b5-87cf-4093-aa7f-7ca28a80754d';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'eb1ece78-a1e9-404d-a647-4bdfe6acd9b3';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'f17cc931-f799-4cef-ada3-9e4a1b3d5a47';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'f43b17e3-8126-42c6-9646-ae5e75bb72f3';
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] ON;
INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
VALUES (N'a5d52774-d3d1-4355-ab16-777d9ad43708', N'59607257-135b-4a41-826b-af78f22ae4c3', N'SysAdmin', N'SysAdmin'),
(N'3367cc01-cd66-475e-89b2-8bbc7e8d76e0', N'dc4bd7cb-2318-447c-8baf-c8aeb64f07da', N'PacsAdmin', N'PacsAdmin'),
(N'ca7ae0eb-1dff-4e07-b654-64420bc8dc4a', N'9075c22c-5c1f-4a70-b5bc-d9a11d07234d', N'ClinicAdmin', N'ClinicAdmin'),
(N'c13591a7-9551-4566-ac7b-0141cb05ca33', N'04022cd3-7696-4bc7-a790-deb6d87666ed', N'Pacient', N'Pacient'),
(N'248896d5-a23c-4056-8d08-2cf085bfe879', N'a5214c27-0f96-49a1-97bb-600fd87297c4', N'Doctor', N'Doctor');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] OFF;
GO

CREATE INDEX [IX_HospitalConsulta_ConsultaId] ON [HospitalConsulta] ([ConsultaId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210522052746_pruebaNoKey', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [HospitalEspecialidades] DROP CONSTRAINT [PK_HospitalEspecialidades];
GO

ALTER TABLE [HospitalDoctor] DROP CONSTRAINT [PK_HospitalDoctor];
GO

ALTER TABLE [HospitalAdministrador] DROP CONSTRAINT [PK_HospitalAdministrador];
GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'248896d5-a23c-4056-8d08-2cf085bfe879';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'3367cc01-cd66-475e-89b2-8bbc7e8d76e0';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'a5d52774-d3d1-4355-ab16-777d9ad43708';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'c13591a7-9551-4566-ac7b-0141cb05ca33';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'ca7ae0eb-1dff-4e07-b654-64420bc8dc4a';
SELECT @@ROWCOUNT;

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[HospitalAdministrador]') AND [c].[name] = N'HospitalId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [HospitalAdministrador] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [HospitalAdministrador] ALTER COLUMN [HospitalId] nvarchar(450) NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[HospitalAdministrador]') AND [c].[name] = N'AdminId');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [HospitalAdministrador] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [HospitalAdministrador] ALTER COLUMN [AdminId] nvarchar(450) NULL;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] ON;
INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
VALUES (N'c2e2f8b7-bf31-4966-b805-943984d4114e', N'80cbd1a5-75d6-4edd-abf3-b2607d7c9fbb', N'SysAdmin', N'SysAdmin'),
(N'128808ae-065b-4f85-95e7-b3f61d7df5f2', N'edbc2fec-d350-480c-afc6-7e1ffd702cf8', N'PacsAdmin', N'PacsAdmin'),
(N'fcb092e5-e0d9-46e9-a36e-85844cc0a829', N'ebcf809d-e501-4412-80e7-98470bf680be', N'ClinicAdmin', N'ClinicAdmin'),
(N'481f42dc-a4b7-4693-9011-ac29b332891d', N'a66dd545-cb8a-4818-899c-15d931675124', N'Pacient', N'Pacient'),
(N'6ab79905-b757-4956-b573-5ae70f93fbec', N'c6698f74-26e0-49b6-ad16-27310ca4842a', N'Doctor', N'Doctor');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] OFF;
GO

CREATE INDEX [IX_HospitalEspecialidades_EspecialidadId] ON [HospitalEspecialidades] ([EspecialidadId]);
GO

CREATE INDEX [IX_HospitalDoctor_DoctorId] ON [HospitalDoctor] ([DoctorId]);
GO

CREATE INDEX [IX_HospitalAdministrador_AdminId] ON [HospitalAdministrador] ([AdminId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210522052847_noKeyEnMuchosAMuchos', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [HospitalConsulta] DROP CONSTRAINT [FK_HospitalConsulta_Consultas_ConsultaId];
GO

ALTER TABLE [HospitalConsulta] DROP CONSTRAINT [FK_HospitalConsulta_Hospitals_HospitalId];
GO

ALTER TABLE [HospitalDoctor] DROP CONSTRAINT [FK_HospitalDoctor_AspNetUsers_DoctorId];
GO

ALTER TABLE [HospitalDoctor] DROP CONSTRAINT [FK_HospitalDoctor_Hospitals_HospitalId];
GO

ALTER TABLE [HospitalEspecialidades] DROP CONSTRAINT [FK_HospitalEspecialidades_Hospitals_HospitalId];
GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'128808ae-065b-4f85-95e7-b3f61d7df5f2';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'481f42dc-a4b7-4693-9011-ac29b332891d';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'6ab79905-b757-4956-b573-5ae70f93fbec';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'c2e2f8b7-bf31-4966-b805-943984d4114e';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'fcb092e5-e0d9-46e9-a36e-85844cc0a829';
SELECT @@ROWCOUNT;

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[HospitalEspecialidades]') AND [c].[name] = N'HospitalId');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [HospitalEspecialidades] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [HospitalEspecialidades] ALTER COLUMN [HospitalId] nvarchar(450) NULL;
GO

ALTER TABLE [HospitalEspecialidades] ADD [Id] int NOT NULL IDENTITY;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[HospitalDoctor]') AND [c].[name] = N'HospitalId');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [HospitalDoctor] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [HospitalDoctor] ALTER COLUMN [HospitalId] nvarchar(450) NULL;
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[HospitalDoctor]') AND [c].[name] = N'DoctorId');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [HospitalDoctor] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [HospitalDoctor] ALTER COLUMN [DoctorId] nvarchar(450) NULL;
GO

ALTER TABLE [HospitalDoctor] ADD [Id] int NOT NULL IDENTITY;
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[HospitalConsulta]') AND [c].[name] = N'HospitalId');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [HospitalConsulta] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [HospitalConsulta] ALTER COLUMN [HospitalId] nvarchar(450) NULL;
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[HospitalConsulta]') AND [c].[name] = N'ConsultaId');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [HospitalConsulta] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [HospitalConsulta] ALTER COLUMN [ConsultaId] nvarchar(450) NULL;
GO

ALTER TABLE [HospitalConsulta] ADD [Id] int NOT NULL IDENTITY;
GO

ALTER TABLE [HospitalAdministrador] ADD [Id] int NOT NULL IDENTITY;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] ON;
INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
VALUES (N'532d329c-f1cb-4869-91bf-128e81cd2232', N'f8577383-339e-4071-9ebe-d73be469eb04', N'SysAdmin', N'SysAdmin'),
(N'7ed00ebd-5fcd-4e52-9c85-5c69f9392a51', N'1da0b9fa-6473-406d-a92e-726635ac7206', N'PacsAdmin', N'PacsAdmin'),
(N'd6e7af9d-ff43-41db-a1c8-e5e7fc1b3f5f', N'e8cb6d05-2cd6-48f0-92a7-6e27780f7bca', N'ClinicAdmin', N'ClinicAdmin'),
(N'60960e54-2543-4116-a466-7c7533815295', N'528f28d6-21aa-4d00-b8e4-32c05f9d7c4a', N'Pacient', N'Pacient'),
(N'0c55c00a-7779-4bdb-a913-83cb6691e6a4', N'184afb45-cf84-419f-808a-027511f613fd', N'Doctor', N'Doctor');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] OFF;
GO

ALTER TABLE [HospitalConsulta] ADD CONSTRAINT [FK_HospitalConsulta_Consultas_ConsultaId] FOREIGN KEY ([ConsultaId]) REFERENCES [Consultas] ([Id]) ON DELETE NO ACTION;
GO

ALTER TABLE [HospitalConsulta] ADD CONSTRAINT [FK_HospitalConsulta_Hospitals_HospitalId] FOREIGN KEY ([HospitalId]) REFERENCES [Hospitals] ([HospitalId]) ON DELETE NO ACTION;
GO

ALTER TABLE [HospitalDoctor] ADD CONSTRAINT [FK_HospitalDoctor_AspNetUsers_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION;
GO

ALTER TABLE [HospitalDoctor] ADD CONSTRAINT [FK_HospitalDoctor_Hospitals_HospitalId] FOREIGN KEY ([HospitalId]) REFERENCES [Hospitals] ([HospitalId]) ON DELETE NO ACTION;
GO

ALTER TABLE [HospitalEspecialidades] ADD CONSTRAINT [FK_HospitalEspecialidades_Hospitals_HospitalId] FOREIGN KEY ([HospitalId]) REFERENCES [Hospitals] ([HospitalId]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210522053425_llaveEnMuchosaMuchos', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'0c55c00a-7779-4bdb-a913-83cb6691e6a4';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'532d329c-f1cb-4869-91bf-128e81cd2232';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'60960e54-2543-4116-a466-7c7533815295';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'7ed00ebd-5fcd-4e52-9c85-5c69f9392a51';
SELECT @@ROWCOUNT;

GO

DELETE FROM [AspNetRoles]
WHERE [Id] = N'd6e7af9d-ff43-41db-a1c8-e5e7fc1b3f5f';
SELECT @@ROWCOUNT;

GO

ALTER TABLE [HospitalEspecialidades] ADD CONSTRAINT [PK_HospitalEspecialidades] PRIMARY KEY ([Id]);
GO

ALTER TABLE [HospitalDoctor] ADD CONSTRAINT [PK_HospitalDoctor] PRIMARY KEY ([Id]);
GO

ALTER TABLE [HospitalConsulta] ADD CONSTRAINT [PK_HospitalConsulta] PRIMARY KEY ([Id]);
GO

ALTER TABLE [HospitalAdministrador] ADD CONSTRAINT [PK_HospitalAdministrador] PRIMARY KEY ([Id]);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] ON;
INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
VALUES (N'46a5ef55-16bb-49e4-8405-f81d50162428', N'e6f19e20-2188-4f0f-912a-806100595c67', N'SysAdmin', N'SysAdmin'),
(N'b305c2c6-38fa-441e-b87c-b9ab3c264017', N'be9ee729-f450-4fc4-805b-87263812c945', N'PacsAdmin', N'PacsAdmin'),
(N'e251fd3c-b2b2-4840-b889-07ba9220d999', N'65da9d5f-cbd4-40b1-ab20-8c7cc3467e37', N'ClinicAdmin', N'ClinicAdmin'),
(N'd249d1c4-9dc7-40c3-8bf2-f5273d8d4d55', N'a29ab80c-bcd2-41ab-881d-63edba869127', N'Pacient', N'Pacient'),
(N'0fc35bb9-a849-4d59-a628-c377f2f1e3bd', N'2d67fe53-9e07-4106-b8e1-9177bd216aeb', N'Doctor', N'Doctor');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210522054338_seQuitanNoKey', N'5.0.5');
GO

COMMIT;
GO


