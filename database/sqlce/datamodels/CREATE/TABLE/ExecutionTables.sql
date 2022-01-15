CREATE TABLE [ExecutionTables]
(
	[ExecutionTablesId] INT NOT NULL IDENTITY (1,1),
	[TableName] NVARCHAR(255) NULL,
	[Type] NVARCHAR(255) NULL,
    CONSTRAINT PK_ExecutionTables
    PRIMARY KEY (ExecutionTablesId) 
);

