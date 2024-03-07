USE [master]
GO

IF DB_ID('TodoList') IS NOT NULL
  set noexec on 

CREATE DATABASE [TodoList];
GO

USE [TodoList];
GO

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

CREATE TABLE [TodoItens] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [CreationDate] datetime2 NOT NULL,
    CONSTRAINT [PK_TodoItens] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240222223001_init', N'6.0.26');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [TodoItens] ADD [Task] nvarchar(max) NOT NULL DEFAULT N'';
GO

CREATE TABLE [TodoReports] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [TaskCount] int NOT NULL,
    CONSTRAINT [PK_TodoReports] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240222224931_report', N'6.0.26');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [TodoItens] ADD [Completed] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240222230823_completed', N'6.0.26');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [TodoReports] ADD [TaskUnfinished] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [TodoReports] ADD [Taskfinished] int NOT NULL DEFAULT 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240222231652_completed-report', N'6.0.26');
GO

COMMIT;
GO