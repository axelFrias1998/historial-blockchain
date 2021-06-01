SELECT U.Nombre, U.Apellido, R.Name FROM [GestorMedicos].[dbo].[AspNetUsers] U
INNER JOIN [GestorMedicos].[dbo].[AspNetUserRoles] UR ON UR.UserId = U.Id
INNER JOIN [GestorMedicos].[dbo].[AspNetRoles] R ON R.Id = UR.RoleId

SELECT * FROM [GestorMedicos].[dbo].[CatalogoGrupoMedicamentos]

SELECT * FROM [GestorMedicos].[dbo].[ServicesCatalog]

SELECT * FROM [GestorMedicos].[dbo].[SpecialitiesCatalog]

--ADMINISTRADORES SIN HOSPITAL ASIGNADO
SELECT U.Id, U.Nombre, U.Apellido FROM [GestorMedicos].[dbo].AspNetUsers U
INNER JOIN [GestorMedicos].[dbo].AspNetUserRoles UR ON UR.UserId = U.Id
INNER JOIN [GestorMedicos].[dbo].AspNetRoles R ON R.Id = UR.RoleId
WHERE (U.Id NOT IN (SELECT AdminId FROM [GestorMedicos].[dbo].HospitalAdministrador)) AND (R.Name = 'ClinicAdmin' OR R.Name = 'PacsAdmin') 

SELECT U.Id, U.Nombre, U.Apellido FROM [GestorMedicos].[dbo].AspNetUsers U
INNER JOIN [GestorMedicos].[dbo].AspNetUserRoles UR ON UR.UserId = U.Id
INNER JOIN [GestorMedicos].[dbo].AspNetRoles R ON R.Id = UR.RoleId
WHERE (U.Id NOT IN (SELECT AdminId FROM [GestorMedicos].[dbo].HospitalAdministrador)) AND (R.Name = 'ClinicAdmin' OR R.Name = 'PacsAdmin') 

--ADMINISTRADORES CON HOSPITAL ASIGNADO
SELECT U.Id, U.Nombre, U.Apellido FROM [GestorMedicos].[dbo].AspNetUsers U
INNER JOIN [GestorMedicos].[dbo].AspNetUserRoles UR ON UR.UserId = U.Id
INNER JOIN [GestorMedicos].[dbo].AspNetRoles R ON R.Id = UR.RoleId
WHERE (U.Id IN (SELECT AdminId FROM [GestorMedicos].[dbo].HospitalAdministrador)) AND (R.Name = 'ClinicAdmin' OR R.Name = 'PacsAdmin') 

--Hospital Administradores
SELECT H.HospitalId, U.Id, U.Nombre, U.Apellido FROM [GestorMedicos].[dbo].AspNetUsers U
INNER JOIN [GestorMedicos].[dbo].HospitalAdministrador HA ON HA.AdminId = U.Id  
INNER JOIN [GestorMedicos].[dbo].Hospitals H ON H.HospitalId = HA.HospitalId