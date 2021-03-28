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

CREATE TABLE [titulo] (
    [Id] int NOT NULL IDENTITY,
    [QuantidadeParcelas] int NOT NULL,
    [ValorAtualizado] decimal(18,2) NOT NULL,
    [numero] bigint NOT NULL,
    [nome] VARCHAR(80) NOT NULL,
    [cpf] CHAR(11) NOT NULL,
    [juros] decimal(18,2) NOT NULL,
    [multa] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_titulo] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [parcela] (
    [Id] int NOT NULL IDENTITY,
    [TituloId] int NOT NULL,
    [numero] int NOT NULL,
    [vencimento] datetime2 NOT NULL DEFAULT (GETDATE()),
    [valor] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_parcela] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_parcela_titulo_TituloId] FOREIGN KEY ([TituloId]) REFERENCES [titulo] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_parcela_TituloId] ON [parcela] ([TituloId]);
GO

CREATE INDEX [idx_titulo_cpf] ON [titulo] ([cpf]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210328144821_DesafioBack', N'5.0.4');
GO

COMMIT;
GO

