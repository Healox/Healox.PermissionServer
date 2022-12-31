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

CREATE TABLE [IdentityRoles] (
    [Id] uniqueidentifier NOT NULL DEFAULT ((newid())),
    [Name] varchar(256) NOT NULL,
    [Description] varchar(max) NULL,
    [ConcurrencyStamp] rowversion NULL,
    CONSTRAINT [XPKIdentityRoles] PRIMARY KEY NONCLUSTERED ([Id])
);
GO

CREATE TABLE [Permissions] (
    [Id] uniqueidentifier NOT NULL DEFAULT ((newid())),
    [Name] varchar(256) NOT NULL,
    [Description] varchar(max) NULL,
    [ConcurrencyStamp] rowversion NULL,
    CONSTRAINT [XPKPermissions] PRIMARY KEY NONCLUSTERED ([Id])
);
GO

CREATE TABLE [Roles] (
    [Id] uniqueidentifier NOT NULL DEFAULT ((newid())),
    [Name] varchar(256) NOT NULL,
    [Description] varchar(max) NULL,
    [ParentRoleId] uniqueidentifier NOT NULL DEFAULT ((CONVERT([uniqueidentifier],'00000000-0000-0000-0000-000000000000'))),
    [ConcurrencyStamp] rowversion NULL,
    CONSTRAINT [XPKRoles] PRIMARY KEY NONCLUSTERED ([Id]),
    CONSTRAINT [Roles_Roles] FOREIGN KEY ([ParentRoleId]) REFERENCES [Roles] ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] uniqueidentifier NOT NULL,
    [Notes] varchar(max) NULL,
    [ConcurrencyStamp] rowversion NULL,
    CONSTRAINT [XPKUsers] PRIMARY KEY NONCLUSTERED ([Id])
);
GO

CREATE TABLE [RoleMaps] (
    [Id] uniqueidentifier NOT NULL DEFAULT ((newid())),
    [IdentityRoleId] uniqueidentifier NOT NULL,
    [RoleId] uniqueidentifier NOT NULL,
    [ConcurrencyStamp] rowversion NULL,
    CONSTRAINT [XPKRoleMaps] PRIMARY KEY NONCLUSTERED ([Id]),
    CONSTRAINT [IdentityRoles_RoleMaps] FOREIGN KEY ([IdentityRoleId]) REFERENCES [IdentityRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [Roles_RoleMaps] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id])
);
GO

CREATE TABLE [RolePermissions] (
    [Id] uniqueidentifier NOT NULL DEFAULT ((newid())),
    [RoleId] uniqueidentifier NOT NULL,
    [PermissionId] uniqueidentifier NOT NULL,
    [ConcurrencyStamp] rowversion NULL,
    CONSTRAINT [XPKRolePermissions] PRIMARY KEY NONCLUSTERED ([Id]),
    CONSTRAINT [Permissions_RolePermissions] FOREIGN KEY ([PermissionId]) REFERENCES [Permissions] ([Id]),
    CONSTRAINT [Roles_RolePermissions] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [UserRoles] (
    [Id] uniqueidentifier NOT NULL DEFAULT ((newid())),
    [UserId] uniqueidentifier NOT NULL,
    [RoleId] uniqueidentifier NOT NULL,
    [ConcurrencyStamp] rowversion NULL,
    CONSTRAINT [XPKUserRoles] PRIMARY KEY NONCLUSTERED ([Id]),
    CONSTRAINT [Roles_UserRoles] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]),
    CONSTRAINT [Users_UserRoles] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE CLUSTERED INDEX [XAKIdentityRoles_Name] ON [IdentityRoles] ([Name]);
GO

CREATE UNIQUE CLUSTERED INDEX [XAKPermissions_Name] ON [Permissions] ([Name]);
GO

CREATE INDEX [IX_RoleMaps_RoleId] ON [RoleMaps] ([RoleId]);
GO

CREATE UNIQUE INDEX [XAKRoleMaps_IdentityRoleId] ON [RoleMaps] ([IdentityRoleId]);
GO

CREATE UNIQUE INDEX [XAKRoleMaps_IdentityRoleId_RoleId] ON [RoleMaps] ([IdentityRoleId], [RoleId]);
GO

CREATE INDEX [IX_RolePermissions_PermissionId] ON [RolePermissions] ([PermissionId]);
GO

CREATE UNIQUE CLUSTERED INDEX [XAKRolePermissions_RoleId_PermissionId] ON [RolePermissions] ([RoleId], [PermissionId]);
GO

CREATE INDEX [IX_Roles_ParentRoleId] ON [Roles] ([ParentRoleId]);
GO

CREATE UNIQUE CLUSTERED INDEX [XAKRoles_Name] ON [Roles] ([Name]);
GO

CREATE INDEX [IX_UserRoles_RoleId] ON [UserRoles] ([RoleId]);
GO

CREATE UNIQUE CLUSTERED INDEX [XAKUserRoles_UserId_RoleId] ON [UserRoles] ([UserId], [RoleId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221231173518_PermissionServer', N'7.0.1');
GO

COMMIT;
GO

