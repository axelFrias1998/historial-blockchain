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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
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
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE TABLE [ServicesCatalog] (
        [Id] int NOT NULL IDENTITY,
        [Type] nvarchar(50) NULL,
        [IsPublic] bit NOT NULL,
        CONSTRAINT [PK_ServicesCatalog] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE TABLE [SpecialitiesCatalog] (
        [Id] int NOT NULL IDENTITY,
        [Type] nvarchar(max) NULL,
        CONSTRAINT [PK_SpecialitiesCatalog] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(450) NOT NULL,
        [ProviderKey] nvarchar(450) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(450) NOT NULL,
        [Name] nvarchar(450) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE TABLE [Consultas] (
        [Id] nvarchar(450) NOT NULL,
        [DateStamp] datetime2 NOT NULL,
        [PacienteId] nvarchar(450) NULL,
        [DoctorId] nvarchar(450) NULL,
        CONSTRAINT [PK_Consultas] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Consultas_AspNetUsers_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Consultas_AspNetUsers_PacienteId] FOREIGN KEY ([PacienteId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
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
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE TABLE [HospitalConsulta] (
        [ConsultaId] nvarchar(450) NOT NULL,
        [HospitalId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_HospitalConsulta] PRIMARY KEY ([ConsultaId], [HospitalId]),
        CONSTRAINT [FK_HospitalConsulta_Consultas_ConsultaId] FOREIGN KEY ([ConsultaId]) REFERENCES [Consultas] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_HospitalConsulta_Hospitals_HospitalId] FOREIGN KEY ([HospitalId]) REFERENCES [Hospitals] ([HospitalId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE TABLE [HospitalDoctor] (
        [DoctorId] nvarchar(450) NOT NULL,
        [HospitalId] nvarchar(450) NOT NULL,
        [EspecialidadId] int NOT NULL,
        CONSTRAINT [PK_HospitalDoctor] PRIMARY KEY ([DoctorId], [HospitalId]),
        CONSTRAINT [FK_HospitalDoctor_AspNetUsers_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_HospitalDoctor_Hospitals_HospitalId] FOREIGN KEY ([HospitalId]) REFERENCES [Hospitals] ([HospitalId]) ON DELETE CASCADE,
        CONSTRAINT [FK_HospitalDoctor_SpecialitiesCatalog_EspecialidadId] FOREIGN KEY ([EspecialidadId]) REFERENCES [SpecialitiesCatalog] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE TABLE [HospitalEspecialidad] (
        [EspecialidadId] int NOT NULL,
        [HospitalId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_HospitalEspecialidad] PRIMARY KEY ([EspecialidadId], [HospitalId]),
        CONSTRAINT [FK_HospitalEspecialidad_Hospitals_HospitalId] FOREIGN KEY ([HospitalId]) REFERENCES [Hospitals] ([HospitalId]) ON DELETE CASCADE,
        CONSTRAINT [FK_HospitalEspecialidad_SpecialitiesCatalog_EspecialidadId] FOREIGN KEY ([EspecialidadId]) REFERENCES [SpecialitiesCatalog] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (N''3a48973b-59ba-4770-a80d-e52206c36ddf'', N''21871d31-83de-45e7-9071-aabd13fad1ac'', N''SysAdmin'', N''SysAdmin''),
    (N''c834067f-cead-4915-9c17-0d9714102fdf'', N''3422586d-0f84-4864-b79c-0a1b9bd85324'', N''PacsAdmin'', N''PacsAdmin''),
    (N''2b26070f-49df-46f7-88b2-6d5945284dc2'', N''fed665c2-b13d-4de8-8c59-9cc8e9bd4f3f'', N''ClinicAdmin'', N''ClinicAdmin''),
    (N''e411d73d-ce17-4809-a982-38b8ae41e12e'', N''75cb6837-688d-4d0b-9927-bdaf85e0d089'', N''Pacient'', N''Pacient''),
    (N''76d14537-a2f9-43af-88de-085178566ff2'', N''4ce71a94-eaba-415e-87a1-e9eedacd9838'', N''Doctor'', N''Doctor'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsPublic', N'Type') AND [object_id] = OBJECT_ID(N'[ServicesCatalog]'))
        SET IDENTITY_INSERT [ServicesCatalog] ON;
    EXEC(N'INSERT INTO [ServicesCatalog] ([Id], [IsPublic], [Type])
    VALUES (1, CAST(1 AS bit), N''Hospital''),
    (2, CAST(0 AS bit), N''Hospital''),
    (3, CAST(1 AS bit), N''Clínica''),
    (4, CAST(0 AS bit), N''Clínica'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsPublic', N'Type') AND [object_id] = OBJECT_ID(N'[ServicesCatalog]'))
        SET IDENTITY_INSERT [ServicesCatalog] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Type') AND [object_id] = OBJECT_ID(N'[SpecialitiesCatalog]'))
        SET IDENTITY_INSERT [SpecialitiesCatalog] ON;
    EXEC(N'INSERT INTO [SpecialitiesCatalog] ([Id], [Type])
    VALUES (1, N''Pediatría''),
    (2, N''Ginecología''),
    (3, N''Geriatría''),
    (4, N''Odontología''),
    (5, N''General'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Type') AND [object_id] = OBJECT_ID(N'[SpecialitiesCatalog]'))
        SET IDENTITY_INSERT [SpecialitiesCatalog] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE INDEX [IX_Consultas_DoctorId] ON [Consultas] ([DoctorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE INDEX [IX_Consultas_PacienteId] ON [Consultas] ([PacienteId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE INDEX [IX_HospitalConsulta_HospitalId] ON [HospitalConsulta] ([HospitalId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE INDEX [IX_HospitalDoctor_EspecialidadId] ON [HospitalDoctor] ([EspecialidadId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE INDEX [IX_HospitalDoctor_HospitalId] ON [HospitalDoctor] ([HospitalId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE INDEX [IX_HospitalEspecialidad_HospitalId] ON [HospitalEspecialidad] ([HospitalId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE UNIQUE INDEX [IX_Hospitals_AdminId] ON [Hospitals] ([AdminId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    CREATE INDEX [IX_Hospitals_ServiceCatalogId] ON [Hospitals] ([ServiceCatalogId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515042139_catalogoEspecialidades')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210515042139_catalogoEspecialidades', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515053852_cambioConexion')
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = N''2b26070f-49df-46f7-88b2-6d5945284dc2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515053852_cambioConexion')
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = N''3a48973b-59ba-4770-a80d-e52206c36ddf'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515053852_cambioConexion')
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = N''76d14537-a2f9-43af-88de-085178566ff2'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515053852_cambioConexion')
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = N''c834067f-cead-4915-9c17-0d9714102fdf'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515053852_cambioConexion')
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = N''e411d73d-ce17-4809-a982-38b8ae41e12e'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515053852_cambioConexion')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (N''aa4e3329-742f-48fa-b651-da3fcbab3dfd'', N''79393d4f-346f-4ab2-84c2-975e82caa466'', N''SysAdmin'', N''SysAdmin''),
    (N''b2c7a13c-ceed-487e-9c23-12c5af98b250'', N''d56b66a9-b464-4f99-8a40-e43d0ba3094f'', N''PacsAdmin'', N''PacsAdmin''),
    (N''65f8f8de-c554-419f-a1cf-8a5170c31736'', N''94746652-aaa5-4629-8737-8ec629c13cee'', N''ClinicAdmin'', N''ClinicAdmin''),
    (N''f1265d40-9487-4dcc-bbbd-f73aff712c1b'', N''e9664b85-eb11-442e-b762-c356d693e7c8'', N''Pacient'', N''Pacient''),
    (N''cbbadc36-9c49-4dae-9382-5f9a698e0c15'', N''39da105b-7c3f-46c6-9777-699e5e19275c'', N''Doctor'', N''Doctor'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515053852_cambioConexion')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210515053852_cambioConexion', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515071543_cambioNombresServiceCatalog')
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = N''65f8f8de-c554-419f-a1cf-8a5170c31736'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515071543_cambioNombresServiceCatalog')
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = N''aa4e3329-742f-48fa-b651-da3fcbab3dfd'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515071543_cambioNombresServiceCatalog')
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = N''b2c7a13c-ceed-487e-9c23-12c5af98b250'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515071543_cambioNombresServiceCatalog')
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = N''cbbadc36-9c49-4dae-9382-5f9a698e0c15'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515071543_cambioNombresServiceCatalog')
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = N''f1265d40-9487-4dcc-bbbd-f73aff712c1b'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515071543_cambioNombresServiceCatalog')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (N''cccd40b3-4b72-4e88-a2fd-4f68eeb4c1ad'', N''29340f91-031c-4cd8-9a37-7cd3dc2463ed'', N''SysAdmin'', N''SysAdmin''),
    (N''dd0f0e3b-34a9-436c-9ab3-a18cdf88df5c'', N''87043657-95aa-4321-9df4-eee230e829b5'', N''PacsAdmin'', N''PacsAdmin''),
    (N''b1bc64da-7c47-4267-8314-e1b9d738bcd4'', N''68e39c5f-2173-4a6f-bd0e-0de0322f41d8'', N''ClinicAdmin'', N''ClinicAdmin''),
    (N''3313023a-0ba4-4289-bc5b-391923bfd40c'', N''fd170dcc-8734-4c4d-8e6a-0f5d2e32d152'', N''Pacient'', N''Pacient''),
    (N''6ba980cd-9f27-4ce5-af83-4c4028a22efa'', N''9443bd57-accf-4a60-b2e4-fcd95a407c61'', N''Doctor'', N''Doctor'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515071543_cambioNombresServiceCatalog')
BEGIN
    EXEC(N'UPDATE [ServicesCatalog] SET [Type] = N''Hospital público''
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515071543_cambioNombresServiceCatalog')
BEGIN
    EXEC(N'UPDATE [ServicesCatalog] SET [Type] = N''Hospital privado''
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515071543_cambioNombresServiceCatalog')
BEGIN
    EXEC(N'UPDATE [ServicesCatalog] SET [Type] = N''Clínica pública''
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515071543_cambioNombresServiceCatalog')
BEGIN
    EXEC(N'UPDATE [ServicesCatalog] SET [Type] = N''Clínica privada''
    WHERE [Id] = 4;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210515071543_cambioNombresServiceCatalog')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210515071543_cambioNombresServiceCatalog', N'5.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210516044322_pruebaMigracionesForzadas')
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = N''3313023a-0ba4-4289-bc5b-391923bfd40c'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210516044322_pruebaMigracionesForzadas')
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = N''6ba980cd-9f27-4ce5-af83-4c4028a22efa'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210516044322_pruebaMigracionesForzadas')
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = N''b1bc64da-7c47-4267-8314-e1b9d738bcd4'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210516044322_pruebaMigracionesForzadas')
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = N''cccd40b3-4b72-4e88-a2fd-4f68eeb4c1ad'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210516044322_pruebaMigracionesForzadas')
BEGIN
    EXEC(N'DELETE FROM [AspNetRoles]
    WHERE [Id] = N''dd0f0e3b-34a9-436c-9ab3-a18cdf88df5c'';
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210516044322_pruebaMigracionesForzadas')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] ON;
    EXEC(N'INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
    VALUES (N''d9d7a892-da98-4937-8500-77251882a5c7'', N''215381ce-39a6-4d7b-b8f0-bdf55ca2e684'', N''SysAdmin'', N''SysAdmin''),
    (N''03905782-71c8-4e18-81de-fda02e20636d'', N''6eb7a32b-8d97-4f36-b669-cdacd072c290'', N''PacsAdmin'', N''PacsAdmin''),
    (N''48e48a9d-7de1-469d-b0a1-46c71a805a9a'', N''3a1acb2f-8b79-4fe3-9165-27e9a09e76a0'', N''ClinicAdmin'', N''ClinicAdmin''),
    (N''517ce587-6a78-45cb-8468-50d616b06a93'', N''23a4e039-afb8-42d6-808e-4fef4ff9f1b0'', N''Pacient'', N''Pacient''),
    (N''0774e700-5569-4399-bcac-1408a8f36b07'', N''18d81c1b-2a47-48a5-a136-de2410a9395d'', N''Doctor'', N''Doctor'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
        SET IDENTITY_INSERT [AspNetRoles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210516044322_pruebaMigracionesForzadas')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Type') AND [object_id] = OBJECT_ID(N'[SpecialitiesCatalog]'))
        SET IDENTITY_INSERT [SpecialitiesCatalog] ON;
    EXEC(N'INSERT INTO [SpecialitiesCatalog] ([Id], [Type])
    VALUES (6, N''Prueba'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Type') AND [object_id] = OBJECT_ID(N'[SpecialitiesCatalog]'))
        SET IDENTITY_INSERT [SpecialitiesCatalog] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210516044322_pruebaMigracionesForzadas')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210516044322_pruebaMigracionesForzadas', N'5.0.5');
END;
GO

COMMIT;
GO

