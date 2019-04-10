
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/30/2019 21:44:09
-- Generated from EDMX file: C:\Users\Arek\Desktop\studia\TPA\svn\trunk\TPA_projekt\TPA_projekt\DBProject\TPA.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TPA];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_Constructor_dbo_Type_TypeID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Constructor] DROP CONSTRAINT [FK_dbo_Constructor_dbo_Type_TypeID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Method_dbo_Type_ReturnTypeID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Method] DROP CONSTRAINT [FK_dbo_Method_dbo_Type_ReturnTypeID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Method_dbo_Type_TypeID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Method] DROP CONSTRAINT [FK_dbo_Method_dbo_Type_TypeID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_MethodParameter_dbo_Method_MethodID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MethodParameter] DROP CONSTRAINT [FK_dbo_MethodParameter_dbo_Method_MethodID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_MethodParameter_dbo_Type_TypeID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MethodParameter] DROP CONSTRAINT [FK_dbo_MethodParameter_dbo_Type_TypeID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Namespace_dbo_Model_ModelID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Namespace] DROP CONSTRAINT [FK_dbo_Namespace_dbo_Model_ModelID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Property_dbo_Type_TypeID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Property] DROP CONSTRAINT [FK_dbo_Property_dbo_Type_TypeID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Type_dbo_Namespace_NamespaceID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Type] DROP CONSTRAINT [FK_dbo_Type_dbo_Namespace_NamespaceID];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Constructor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Constructor];
GO
IF OBJECT_ID(N'[dbo].[Method]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Method];
GO
IF OBJECT_ID(N'[dbo].[MethodParameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MethodParameter];
GO
IF OBJECT_ID(N'[dbo].[Model]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Model];
GO
IF OBJECT_ID(N'[dbo].[Namespace]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Namespace];
GO
IF OBJECT_ID(N'[dbo].[Property]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Property];
GO
IF OBJECT_ID(N'[dbo].[Type]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Type];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Constructor'
CREATE TABLE [dbo].[Constructor] (
    [ConstructorID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NULL,
    [TypeID] int  NOT NULL
);
GO

-- Creating table 'Method'
CREATE TABLE [dbo].[Method] (
    [MethodID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NULL,
    [TypeID] int  NOT NULL,
    [ReturnTypeID] int  NOT NULL
);
GO

-- Creating table 'MethodParameter'
CREATE TABLE [dbo].[MethodParameter] (
    [MethodParameterID] int IDENTITY(1,1) NOT NULL,
    [MethodID] int  NOT NULL,
    [Name] nvarchar(200)  NULL,
    [TypeID] int  NOT NULL
);
GO

-- Creating table 'Model'
CREATE TABLE [dbo].[Model] (
    [ModelID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NULL
);
GO

-- Creating table 'Namespace'
CREATE TABLE [dbo].[Namespace] (
    [NamespaceID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NULL,
    [ModelID] int  NOT NULL
);
GO

-- Creating table 'Property'
CREATE TABLE [dbo].[Property] (
    [PropertyID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NULL,
    [TypeID] int  NOT NULL
);
GO

-- Creating table 'Type'
CREATE TABLE [dbo].[Type] (
    [TypeID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NULL,
    [NamespaceID] int  NOT NULL
);
GO

-- Creating table 'LogSet'
CREATE TABLE [dbo].[LogSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Message] nvarchar(max)  NOT NULL,
    [Date] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ConstructorID] in table 'Constructor'
ALTER TABLE [dbo].[Constructor]
ADD CONSTRAINT [PK_Constructor]
    PRIMARY KEY CLUSTERED ([ConstructorID] ASC);
GO

-- Creating primary key on [MethodID] in table 'Method'
ALTER TABLE [dbo].[Method]
ADD CONSTRAINT [PK_Method]
    PRIMARY KEY CLUSTERED ([MethodID] ASC);
GO

-- Creating primary key on [MethodParameterID] in table 'MethodParameter'
ALTER TABLE [dbo].[MethodParameter]
ADD CONSTRAINT [PK_MethodParameter]
    PRIMARY KEY CLUSTERED ([MethodParameterID] ASC);
GO

-- Creating primary key on [ModelID] in table 'Model'
ALTER TABLE [dbo].[Model]
ADD CONSTRAINT [PK_Model]
    PRIMARY KEY CLUSTERED ([ModelID] ASC);
GO

-- Creating primary key on [NamespaceID] in table 'Namespace'
ALTER TABLE [dbo].[Namespace]
ADD CONSTRAINT [PK_Namespace]
    PRIMARY KEY CLUSTERED ([NamespaceID] ASC);
GO

-- Creating primary key on [PropertyID] in table 'Property'
ALTER TABLE [dbo].[Property]
ADD CONSTRAINT [PK_Property]
    PRIMARY KEY CLUSTERED ([PropertyID] ASC);
GO

-- Creating primary key on [TypeID] in table 'Type'
ALTER TABLE [dbo].[Type]
ADD CONSTRAINT [PK_Type]
    PRIMARY KEY CLUSTERED ([TypeID] ASC);
GO

-- Creating primary key on [Id] in table 'LogSet'
ALTER TABLE [dbo].[LogSet]
ADD CONSTRAINT [PK_LogSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TypeID] in table 'Constructor'
ALTER TABLE [dbo].[Constructor]
ADD CONSTRAINT [FK_dbo_Constructor_dbo_Type_TypeID]
    FOREIGN KEY ([TypeID])
    REFERENCES [dbo].[Type]
        ([TypeID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Constructor_dbo_Type_TypeID'
CREATE INDEX [IX_FK_dbo_Constructor_dbo_Type_TypeID]
ON [dbo].[Constructor]
    ([TypeID]);
GO

-- Creating foreign key on [ReturnTypeID] in table 'Method'
ALTER TABLE [dbo].[Method]
ADD CONSTRAINT [FK_dbo_Method_dbo_Type_ReturnTypeID]
    FOREIGN KEY ([ReturnTypeID])
    REFERENCES [dbo].[Type]
        ([TypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Method_dbo_Type_ReturnTypeID'
CREATE INDEX [IX_FK_dbo_Method_dbo_Type_ReturnTypeID]
ON [dbo].[Method]
    ([ReturnTypeID]);
GO

-- Creating foreign key on [TypeID] in table 'Method'
ALTER TABLE [dbo].[Method]
ADD CONSTRAINT [FK_dbo_Method_dbo_Type_TypeID]
    FOREIGN KEY ([TypeID])
    REFERENCES [dbo].[Type]
        ([TypeID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Method_dbo_Type_TypeID'
CREATE INDEX [IX_FK_dbo_Method_dbo_Type_TypeID]
ON [dbo].[Method]
    ([TypeID]);
GO

-- Creating foreign key on [MethodID] in table 'MethodParameter'
ALTER TABLE [dbo].[MethodParameter]
ADD CONSTRAINT [FK_dbo_MethodParameter_dbo_Method_MethodID]
    FOREIGN KEY ([MethodID])
    REFERENCES [dbo].[Method]
        ([MethodID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_MethodParameter_dbo_Method_MethodID'
CREATE INDEX [IX_FK_dbo_MethodParameter_dbo_Method_MethodID]
ON [dbo].[MethodParameter]
    ([MethodID]);
GO

-- Creating foreign key on [TypeID] in table 'MethodParameter'
ALTER TABLE [dbo].[MethodParameter]
ADD CONSTRAINT [FK_dbo_MethodParameter_dbo_Type_TypeID]
    FOREIGN KEY ([TypeID])
    REFERENCES [dbo].[Type]
        ([TypeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_MethodParameter_dbo_Type_TypeID'
CREATE INDEX [IX_FK_dbo_MethodParameter_dbo_Type_TypeID]
ON [dbo].[MethodParameter]
    ([TypeID]);
GO

-- Creating foreign key on [ModelID] in table 'Namespace'
ALTER TABLE [dbo].[Namespace]
ADD CONSTRAINT [FK_dbo_Namespace_dbo_Model_ModelID]
    FOREIGN KEY ([ModelID])
    REFERENCES [dbo].[Model]
        ([ModelID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Namespace_dbo_Model_ModelID'
CREATE INDEX [IX_FK_dbo_Namespace_dbo_Model_ModelID]
ON [dbo].[Namespace]
    ([ModelID]);
GO

-- Creating foreign key on [NamespaceID] in table 'Type'
ALTER TABLE [dbo].[Type]
ADD CONSTRAINT [FK_dbo_Type_dbo_Namespace_NamespaceID]
    FOREIGN KEY ([NamespaceID])
    REFERENCES [dbo].[Namespace]
        ([NamespaceID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Type_dbo_Namespace_NamespaceID'
CREATE INDEX [IX_FK_dbo_Type_dbo_Namespace_NamespaceID]
ON [dbo].[Type]
    ([NamespaceID]);
GO

-- Creating foreign key on [TypeID] in table 'Property'
ALTER TABLE [dbo].[Property]
ADD CONSTRAINT [FK_dbo_Property_dbo_Type_TypeID]
    FOREIGN KEY ([TypeID])
    REFERENCES [dbo].[Type]
        ([TypeID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Property_dbo_Type_TypeID'
CREATE INDEX [IX_FK_dbo_Property_dbo_Type_TypeID]
ON [dbo].[Property]
    ([TypeID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------