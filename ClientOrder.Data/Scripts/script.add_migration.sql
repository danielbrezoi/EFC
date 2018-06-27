﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180626152952_init')
BEGIN
    CREATE TABLE [Address] (
        [IsDirty] bit NOT NULL,
        [AddressId] uniqueidentifier NOT NULL,
        [FullAddress] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Address] PRIMARY KEY ([AddressId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180626152952_init')
BEGIN
    CREATE TABLE [Clients] (
        [IsDirty] bit NOT NULL,
        [ClientId] uniqueidentifier NOT NULL,
        [FirstName] nvarchar(max) NULL,
        [LastName] nvarchar(max) NULL,
        CONSTRAINT [PK_Clients] PRIMARY KEY ([ClientId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180626152952_init')
BEGIN
    CREATE TABLE [ClientAddress] (
        [IsDirty] bit NOT NULL,
        [ClientId] uniqueidentifier NOT NULL,
        [AddressId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_ClientAddress] PRIMARY KEY ([ClientId], [AddressId]),
        CONSTRAINT [FK_ClientAddress_Address_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [Address] ([AddressId]) ON DELETE CASCADE,
        CONSTRAINT [FK_ClientAddress_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([ClientId]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180626152952_init')
BEGIN
    CREATE INDEX [IX_ClientAddress_AddressId] ON [ClientAddress] ([AddressId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180626152952_init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180626152952_init', N'2.1.1-rtm-30846');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180626154256_add_field')
BEGIN
    ALTER TABLE [Clients] ADD [MiddleName] nvarchar(max) NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180626154256_add_field')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180626154256_add_field', N'2.1.1-rtm-30846');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180626154418_add_field_req')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Clients]') AND [c].[name] = N'MiddleName');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Clients] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Clients] ALTER COLUMN [MiddleName] nvarchar(max) NOT NULL;
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180626154418_add_field_req')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180626154418_add_field_req', N'2.1.1-rtm-30846');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180626161326_empty')
BEGIN
    CREATE PROCEDURE [dbo].[GetClients]
                         @FirstName varchar(50)
                         AS
                         BEGIN
                             SET NOCOUNT ON;
                             select * from Clients where FirstName like @FirstName +'%'
                         END
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180626161326_empty')
BEGIN
    CREATE PROCEDURE CreateClient
                                    @FirstName Varchar(50),
                                    @LastName Varchar(50)
                                AS
                                BEGIN
                                    SET NOCOUNT ON;
                                    Insert into Clients(
                                           [FirstName]
                                           ,[LastName]
                                           )
                                 Values (@FirstName, @LastName)
                                END
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180626161326_empty')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180626161326_empty', N'2.1.1-rtm-30846');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180626161608_empty_2')
BEGIN
    CREATE PROCEDURE CreateClient
                                    @FirstName Varchar(50),
                                    @LastName Varchar(50),
                                    @MiddleName Varchar(50)

                                AS
                                BEGIN
                                    SET NOCOUNT ON;
                                    Insert into Clients(
                                           [FirstName]
                                           ,[LastName]
                                           ,[MiddleName]
                                           )
                                 Values (@FirstName, @LastName, @MiddleName)
                                END
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180626161608_empty_2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180626161608_empty_2', N'2.1.1-rtm-30846');
END;

GO

