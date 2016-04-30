
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/14/2015 20:49:28
-- Generated from EDMX file: D:\YandexDisk\!PROJECTS\BankMap\BankHelper\BankBaseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BankBase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BankExchanger]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CurrencyExchangers] DROP CONSTRAINT [FK_BankExchanger];
GO
IF OBJECT_ID(N'[dbo].[FK_BankBranchService]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Services] DROP CONSTRAINT [FK_BankBranchService];
GO
IF OBJECT_ID(N'[dbo].[FK_BankBranchOperator]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operators] DROP CONSTRAINT [FK_BankBranchOperator];
GO
IF OBJECT_ID(N'[dbo].[FK_BankExchangeRate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExchangeRates] DROP CONSTRAINT [FK_BankExchangeRate];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CurrencyExchangers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CurrencyExchangers];
GO
IF OBJECT_ID(N'[dbo].[Banks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Banks];
GO
IF OBJECT_ID(N'[dbo].[ExchangeRates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExchangeRates];
GO
IF OBJECT_ID(N'[dbo].[Services]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Services];
GO
IF OBJECT_ID(N'[dbo].[Operators]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Operators];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CurrencyExchangers'
CREATE TABLE [dbo].[CurrencyExchangers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Number] int  NULL,
    [Phone] nvarchar(max)  NULL,
    [Address] nvarchar(max)  NULL,
    [X] float  NOT NULL,
    [Y] float  NOT NULL,
    [OpenDate] datetime  NULL,
    [WorkTime] nvarchar(max)  NULL,
    [GMapId] nvarchar(max)  NULL,
    [Bank_Id] int  NOT NULL
);
GO

-- Creating table 'Banks'
CREATE TABLE [dbo].[Banks] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NULL,
    [Xmld] int  NOT NULL
);
GO

-- Creating table 'ExchangeRates'
CREATE TABLE [dbo].[ExchangeRates] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CurrencyName] nvarchar(max)  NOT NULL,
    [Sale] float  NOT NULL,
    [Buy] float  NOT NULL,
    [Date] datetime  NOT NULL,
    [Bank_Id] int  NOT NULL
);
GO

-- Creating table 'Services'
CREATE TABLE [dbo].[Services] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Decription] nvarchar(max)  NULL,
    [BankBranch_Id] int  NOT NULL
);
GO

-- Creating table 'Operators'
CREATE TABLE [dbo].[Operators] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [BankBranch_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CurrencyExchangers'
ALTER TABLE [dbo].[CurrencyExchangers]
ADD CONSTRAINT [PK_CurrencyExchangers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Banks'
ALTER TABLE [dbo].[Banks]
ADD CONSTRAINT [PK_Banks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExchangeRates'
ALTER TABLE [dbo].[ExchangeRates]
ADD CONSTRAINT [PK_ExchangeRates]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [PK_Services]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Operators'
ALTER TABLE [dbo].[Operators]
ADD CONSTRAINT [PK_Operators]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Bank_Id] in table 'CurrencyExchangers'
ALTER TABLE [dbo].[CurrencyExchangers]
ADD CONSTRAINT [FK_BankExchanger]
    FOREIGN KEY ([Bank_Id])
    REFERENCES [dbo].[Banks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BankExchanger'
CREATE INDEX [IX_FK_BankExchanger]
ON [dbo].[CurrencyExchangers]
    ([Bank_Id]);
GO

-- Creating foreign key on [BankBranch_Id] in table 'Services'
ALTER TABLE [dbo].[Services]
ADD CONSTRAINT [FK_BankBranchService]
    FOREIGN KEY ([BankBranch_Id])
    REFERENCES [dbo].[CurrencyExchangers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BankBranchService'
CREATE INDEX [IX_FK_BankBranchService]
ON [dbo].[Services]
    ([BankBranch_Id]);
GO

-- Creating foreign key on [BankBranch_Id] in table 'Operators'
ALTER TABLE [dbo].[Operators]
ADD CONSTRAINT [FK_BankBranchOperator]
    FOREIGN KEY ([BankBranch_Id])
    REFERENCES [dbo].[CurrencyExchangers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BankBranchOperator'
CREATE INDEX [IX_FK_BankBranchOperator]
ON [dbo].[Operators]
    ([BankBranch_Id]);
GO

-- Creating foreign key on [Bank_Id] in table 'ExchangeRates'
ALTER TABLE [dbo].[ExchangeRates]
ADD CONSTRAINT [FK_BankExchangeRate]
    FOREIGN KEY ([Bank_Id])
    REFERENCES [dbo].[Banks]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BankExchangeRate'
CREATE INDEX [IX_FK_BankExchangeRate]
ON [dbo].[ExchangeRates]
    ([Bank_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------