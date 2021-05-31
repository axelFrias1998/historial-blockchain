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

CREATE TABLE [CatalogoGrupoMedicamentos] (
    [Id] int NOT NULL IDENTITY,
    [Type] nvarchar(max) NULL,
    CONSTRAINT [PK_CatalogoGrupoMedicamentos] PRIMARY KEY ([Id])
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
    [ConsultaId] nvarchar(450) NOT NULL,
    [DateStamp] datetime2 NOT NULL,
    [PacienteId] nvarchar(450) NULL,
    [DoctorId] nvarchar(450) NULL,
    CONSTRAINT [PK_Consultas] PRIMARY KEY ([ConsultaId]),
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
    [IsEnable] bit NOT NULL,
    CONSTRAINT [PK_Hospitals] PRIMARY KEY ([HospitalId]),
    CONSTRAINT [FK_Hospitals_ServicesCatalog_ServiceCatalogId] FOREIGN KEY ([ServiceCatalogId]) REFERENCES [ServicesCatalog] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [HospitalAdministrador] (
    [Id] int NOT NULL IDENTITY,
    [AdminId] nvarchar(450) NULL,
    [HospitalId] nvarchar(450) NULL,
    CONSTRAINT [PK_HospitalAdministrador] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_HospitalAdministrador_AspNetUsers_AdminId] FOREIGN KEY ([AdminId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_HospitalAdministrador_Hospitals_HospitalId] FOREIGN KEY ([HospitalId]) REFERENCES [Hospitals] ([HospitalId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [HospitalConsulta] (
    [Id] int NOT NULL IDENTITY,
    [ConsultaId] nvarchar(450) NULL,
    [HospitalId] nvarchar(450) NULL,
    CONSTRAINT [PK_HospitalConsulta] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_HospitalConsulta_Consultas_ConsultaId] FOREIGN KEY ([ConsultaId]) REFERENCES [Consultas] ([ConsultaId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_HospitalConsulta_Hospitals_HospitalId] FOREIGN KEY ([HospitalId]) REFERENCES [Hospitals] ([HospitalId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [HospitalDoctor] (
    [HospitalDoctorId] int NOT NULL IDENTITY,
    [DoctorId] nvarchar(450) NULL,
    [HospitalId] nvarchar(450) NULL,
    [EspecialidadId] int NOT NULL,
    CONSTRAINT [PK_HospitalDoctor] PRIMARY KEY ([HospitalDoctorId]),
    CONSTRAINT [FK_HospitalDoctor_AspNetUsers_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_HospitalDoctor_Hospitals_HospitalId] FOREIGN KEY ([HospitalId]) REFERENCES [Hospitals] ([HospitalId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_HospitalDoctor_SpecialitiesCatalog_EspecialidadId] FOREIGN KEY ([EspecialidadId]) REFERENCES [SpecialitiesCatalog] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [HospitalEspecialidades] (
    [Id] int NOT NULL IDENTITY,
    [EspecialidadId] int NOT NULL,
    [HospitalId] nvarchar(450) NULL,
    CONSTRAINT [PK_HospitalEspecialidades] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_HospitalEspecialidades_Hospitals_HospitalId] FOREIGN KEY ([HospitalId]) REFERENCES [Hospitals] ([HospitalId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_HospitalEspecialidades_SpecialitiesCatalog_EspecialidadId] FOREIGN KEY ([EspecialidadId]) REFERENCES [SpecialitiesCatalog] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [HospitalMedicamentos] (
    [Id] int NOT NULL IDENTITY,
    [Descripcion] nvarchar(max) NULL,
    [Indicaciones] nvarchar(max) NULL,
    [ViaAdministracion] nvarchar(max) NULL,
    [GrupoMedicamentosId] int NOT NULL,
    [HospitalId] nvarchar(450) NULL,
    CONSTRAINT [PK_HospitalMedicamentos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_HospitalMedicamentos_CatalogoGrupoMedicamentos_GrupoMedicamentosId] FOREIGN KEY ([GrupoMedicamentosId]) REFERENCES [CatalogoGrupoMedicamentos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_HospitalMedicamentos_Hospitals_HospitalId] FOREIGN KEY ([HospitalId]) REFERENCES [Hospitals] ([HospitalId]) ON DELETE NO ACTION
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] ON;
INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
VALUES (N'99a76f72-a219-4891-80f5-d6c84d33c696', N'e7b5253d-07d4-4f95-a62e-3dee21a8aecd', N'SysAdmin', N'SysAdmin'),
(N'd2f6a949-dc3f-453d-aa1f-79b5de5b0b74', N'9e024bbe-aa75-4549-85cd-f7b396908151', N'PacsAdmin', N'PacsAdmin'),
(N'c4a2a296-ff57-4522-88ac-73d2238b1d28', N'1c8675b1-8868-4f2a-90ad-964799b6ad94', N'ClinicAdmin', N'ClinicAdmin'),
(N'259cbe94-6fbd-417d-9732-a71c29b6219c', N'26a56d56-2c1a-4429-bcb4-21e53c87b86a', N'Pacient', N'Pacient'),
(N'3ac9e38b-f26e-4ff1-b110-76cd0891c5b5', N'233b6a5d-8afe-413e-a6e5-a13a25a57523', N'Doctor', N'Doctor');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Type') AND [object_id] = OBJECT_ID(N'[CatalogoGrupoMedicamentos]'))
    SET IDENTITY_INSERT [CatalogoGrupoMedicamentos] ON;
INSERT INTO [CatalogoGrupoMedicamentos] ([Id], [Type])
VALUES (8, N'Gastroenterología'),
(7, N'Enfermedades Inmunoalérgicas'),
(5, N'Endocrinología y metabolismo'),
(6, N'Enfermedades Infecciosas y Parasitarias'),
(3, N'Cardiología'),
(2, N'Anestesia'),
(1, N'Analgesia'),
(4, N'Dermatología');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Type') AND [object_id] = OBJECT_ID(N'[CatalogoGrupoMedicamentos]'))
    SET IDENTITY_INSERT [CatalogoGrupoMedicamentos] OFF;
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
VALUES (4, N'Odontología'),
(1, N'Pediatría'),
(2, N'Ginecología'),
(3, N'Geriatría'),
(5, N'General');
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

CREATE INDEX [IX_HospitalAdministrador_AdminId] ON [HospitalAdministrador] ([AdminId]);
GO

CREATE INDEX [IX_HospitalAdministrador_HospitalId] ON [HospitalAdministrador] ([HospitalId]);
GO

CREATE INDEX [IX_HospitalConsulta_ConsultaId] ON [HospitalConsulta] ([ConsultaId]);
GO

CREATE INDEX [IX_HospitalConsulta_HospitalId] ON [HospitalConsulta] ([HospitalId]);
GO

CREATE INDEX [IX_HospitalDoctor_DoctorId] ON [HospitalDoctor] ([DoctorId]);
GO

CREATE INDEX [IX_HospitalDoctor_EspecialidadId] ON [HospitalDoctor] ([EspecialidadId]);
GO

CREATE INDEX [IX_HospitalDoctor_HospitalId] ON [HospitalDoctor] ([HospitalId]);
GO

CREATE INDEX [IX_HospitalEspecialidades_EspecialidadId] ON [HospitalEspecialidades] ([EspecialidadId]);
GO

CREATE INDEX [IX_HospitalEspecialidades_HospitalId] ON [HospitalEspecialidades] ([HospitalId]);
GO

CREATE INDEX [IX_HospitalMedicamentos_GrupoMedicamentosId] ON [HospitalMedicamentos] ([GrupoMedicamentosId]);
GO

CREATE INDEX [IX_HospitalMedicamentos_HospitalId] ON [HospitalMedicamentos] ([HospitalId]);
GO

CREATE INDEX [IX_Hospitals_ServiceCatalogId] ON [Hospitals] ([ServiceCatalogId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210531064016_hospitalMedicamentos', N'5.0.5');
GO

COMMIT;
GO


