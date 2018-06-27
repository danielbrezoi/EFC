IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
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

