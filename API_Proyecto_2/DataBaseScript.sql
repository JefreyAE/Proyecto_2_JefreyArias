CREATE DATABASE DBProyecto2;
USE DBProyecto2;

CREATE TABLE [Clients] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Code] int NOT NULL,
    [ClientPersonalId] int NOT NULL,
    [Birthday] datetime2 NOT NULL,
    CONSTRAINT [PK_Clients] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Dispatchers] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Code] int NOT NULL,
    CONSTRAINT [PK_Dispatchers] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [UserId] int NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Articles] (
    [Id] int NOT NULL IDENTITY,
    [TrackingId] nvarchar(max) NOT NULL,
    [AdmissionDate] datetime2 NOT NULL,
    [RecallDate] datetime2 NULL,
    [Price] float NOT NULL,
    [Weight] float NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [ClientId] int NOT NULL,
    [DispatcherId] int NOT NULL,
    [State] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Articles] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Articles_Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Clients] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Articles_Dispatchers_DispatcherId] FOREIGN KEY ([DispatcherId]) REFERENCES [Dispatchers] ([Id]) ON DELETE CASCADE
);
GO


CREATE INDEX [IX_Articles_ClientId] ON [Articles] ([ClientId]);
GO


CREATE INDEX [IX_Articles_DispatcherId] ON [Articles] ([DispatcherId]);
GO


