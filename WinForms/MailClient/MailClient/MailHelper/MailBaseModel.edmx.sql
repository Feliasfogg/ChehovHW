
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/17/2015 16:58:33
-- Generated from EDMX file: D:\YandexDisk\!PROJECTS\MailClient\MailHelper\MailBaseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MailBase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_GroupReceiver]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Receivers] DROP CONSTRAINT [FK_GroupReceiver];
GO
IF OBJECT_ID(N'[dbo].[FK_ReceiverEmail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Emails] DROP CONSTRAINT [FK_ReceiverEmail];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Receivers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Receivers];
GO
IF OBJECT_ID(N'[dbo].[Groups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Groups];
GO
IF OBJECT_ID(N'[dbo].[Emails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Emails];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Receivers'
CREATE TABLE [dbo].[Receivers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Group_Id] int  NOT NULL
);
GO

-- Creating table 'Groups'
CREATE TABLE [dbo].[Groups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [LeftKey] int  NOT NULL,
    [RightKey] int  NOT NULL,
    [Level] int  NOT NULL
);
GO

-- Creating table 'Emails'
CREATE TABLE [dbo].[Emails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Header] nvarchar(max)  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [SendingTime] datetime  NOT NULL,
    [Sended] bit  NOT NULL,
    [Receiver_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Receivers'
ALTER TABLE [dbo].[Receivers]
ADD CONSTRAINT [PK_Receivers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [PK_Groups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Emails'
ALTER TABLE [dbo].[Emails]
ADD CONSTRAINT [PK_Emails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Group_Id] in table 'Receivers'
ALTER TABLE [dbo].[Receivers]
ADD CONSTRAINT [FK_GroupReceiver]
    FOREIGN KEY ([Group_Id])
    REFERENCES [dbo].[Groups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupReceiver'
CREATE INDEX [IX_FK_GroupReceiver]
ON [dbo].[Receivers]
    ([Group_Id]);
GO

-- Creating foreign key on [Receiver_Id] in table 'Emails'
ALTER TABLE [dbo].[Emails]
ADD CONSTRAINT [FK_ReceiverEmail]
    FOREIGN KEY ([Receiver_Id])
    REFERENCES [dbo].[Receivers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReceiverEmail'
CREATE INDEX [IX_FK_ReceiverEmail]
ON [dbo].[Emails]
    ([Receiver_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------