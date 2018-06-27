IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Addresses] (
    [IsDirty] bit NOT NULL,
    [AddressId] uniqueidentifier NOT NULL,
    [FullAddress] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY ([AddressId])
);

GO

CREATE TABLE [Clients] (
    [IsDirty] bit NOT NULL,
    [ClientId] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([ClientId])
);

GO

CREATE TABLE [Orders] (
    [IsDirty] bit NOT NULL,
    [OrderId] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderId])
);

GO

CREATE TABLE [ClientAddresses] (
    [IsDirty] bit NOT NULL,
    [ClientId] uniqueidentifier NOT NULL,
    [AddressId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_ClientAddresses] PRIMARY KEY ([ClientId], [AddressId]),
    CONSTRAINT [FK_ClientAddresses_Addresses_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [Addresses] ([AddressId]) ON DELETE CASCADE,
    CONSTRAINT [FK_ClientAddresses_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([ClientId]) ON DELETE CASCADE
);

GO

CREATE TABLE [OrderDetails] (
    [IsDirty] bit NOT NULL,
    [OrderDetailsId] uniqueidentifier NOT NULL,
    [Details] nvarchar(max) NULL,
    [OrderId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY ([OrderDetailsId]),
    CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([OrderId]) ON DELETE CASCADE
);

GO

CREATE TABLE [Products] (
    [IsDirty] bit NOT NULL,
    [ProductId] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [Price] int NOT NULL,
    [OrderId] uniqueidentifier NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([ProductId]),
    CONSTRAINT [FK_Products_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([OrderId]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_ClientAddresses_AddressId] ON [ClientAddresses] ([AddressId]);

GO

CREATE UNIQUE INDEX [IX_OrderDetails_OrderId] ON [OrderDetails] ([OrderId]);

GO

CREATE INDEX [IX_Products_OrderId] ON [Products] ([OrderId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180626130338_Init', N'2.1.1-rtm-30846');

GO

