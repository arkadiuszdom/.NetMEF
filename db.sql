use TPA
CREATE TABLE [dbo].[LOG] (
    [DATETM]     DATETIME2 (7) NULL,
    [LOGMESSAGE] VARCHAR (200) NULL
);

CREATE TABLE [dbo].[Model] ( 
    [ModelID] INT IDENTITY (1, 1) NOT NULL, 
    [Name] NVARCHAR (200) NULL, 
    CONSTRAINT [PK_dbo.Model] PRIMARY KEY CLUSTERED ([ModelID] ASC) 
); 

CREATE TABLE [dbo].[Namespace] ( 
    [NamespaceID] INT IDENTITY (1, 1) NOT NULL, 
    [Name] NVARCHAR (200) NULL, 
	[ModelID] INT NOT NULL,
    CONSTRAINT [PK_dbo.Namespace] PRIMARY KEY CLUSTERED ([NamespaceID] ASC) ,
	CONSTRAINT [FK_dbo.Namespace_dbo.Model_ModelID] FOREIGN KEY ([ModelID]) REFERENCES [dbo].[Model] ([ModelID]) ON DELETE CASCADE 
); 

CREATE TABLE [dbo].[Type] ( 
    [TypeID] INT IDENTITY (1, 1) NOT NULL, 
    [Name] NVARCHAR (200) NULL, 
	[NamespaceID] INT NOT NULL,
    CONSTRAINT [PK_dbo.Type] PRIMARY KEY CLUSTERED ([TypeID] ASC) ,
	CONSTRAINT [FK_dbo.Type_dbo.Namespace_NamespaceID] FOREIGN KEY ([NamespaceID]) REFERENCES [dbo].[Namespace] ([NamespaceID]) ON DELETE CASCADE 
); 

CREATE TABLE [dbo].[Constructor] ( 
    [ConstructorID] INT IDENTITY (1, 1) NOT NULL, 
    [Name] NVARCHAR (200) NULL, 
	[TypeID] INT NOT NULL,
    CONSTRAINT [PK_dbo.Constructor] PRIMARY KEY CLUSTERED ([ConstructorID] ASC) ,
	CONSTRAINT [FK_dbo.Constructor_dbo.Type_TypeID] FOREIGN KEY ([TypeID]) REFERENCES [dbo].[Type] ([TypeID]) ON DELETE CASCADE 
); 

CREATE TABLE [dbo].[Method] ( 
    [MethodID] INT IDENTITY (1, 1) NOT NULL, 
    [Name] NVARCHAR (200) NULL, 
	[TypeID] INT NOT NULL,
	[ReturnTypeID] INT NOT NULL,
    CONSTRAINT [PK_dbo.Method] PRIMARY KEY CLUSTERED ([MethodID] ASC) ,
	CONSTRAINT [FK_dbo.Method_dbo.Type_TypeID] FOREIGN KEY ([TypeID]) REFERENCES [dbo].[Type] ([TypeID]) ON DELETE CASCADE ,
	CONSTRAINT [FK_dbo.Method_dbo.Type_ReturnTypeID] FOREIGN KEY ([ReturnTypeID]) REFERENCES [dbo].[Type] ([TypeID]) ON DELETE NO ACTION 
); 

CREATE TABLE [dbo].[MethodParameter] ( 
    [MethodParameterID] INT IDENTITY (1, 1) NOT NULL, 
    [MethodID] INT  NOT NULL, 
    [Name] NVARCHAR (200) NULL, 
	[TypeID] INT NOT NULL,
    CONSTRAINT [PK_dbo.MethodParameter] PRIMARY KEY CLUSTERED ([MethodParameterID] ASC) ,
	CONSTRAINT [FK_dbo.MethodParameter_dbo.Type_TypeID] FOREIGN KEY ([TypeID]) REFERENCES [dbo].[Type] ([TypeID]),
	CONSTRAINT [FK_dbo.MethodParameter_dbo.Method_MethodID] FOREIGN KEY ([MethodID]) REFERENCES [dbo].[Method] ([MethodID]) 
); 

CREATE TABLE [dbo].[Property] ( 
    [PropertyID] INT IDENTITY (1, 1) NOT NULL, 
    [Name] NVARCHAR (200) NULL, 
	[TypeID] INT NOT NULL,
    CONSTRAINT [PK_dbo.Property] PRIMARY KEY CLUSTERED ([PropertyID] ASC) ,
	CONSTRAINT [FK_dbo.Property_dbo.Type_TypeID] FOREIGN KEY ([TypeID]) REFERENCES [dbo].[Type] ([TypeID]) ON DELETE CASCADE 
); 