CREATE TABLE [ApplicationTables]
(
	[ApplicationTablesId] INT NOT NULL IDENTITY (1,1),
	[TableName] NVARCHAR(255) NULL,
	[Model] NVARCHAR(255) NULL,
    CONSTRAINT PK_ApplicationTables
    PRIMARY KEY (ApplicationTablesId) 
);

