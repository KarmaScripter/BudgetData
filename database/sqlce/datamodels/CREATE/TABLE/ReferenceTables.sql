CREATE TABLE ReferenceTables
(
	ReferenceTableId INTEGER NOT NULL IDENTITY(1,1),
	TableName NVARCHAR(255) NULL,
	Type NVARCHAR(255) NULL,
		CONSTRAINT PK_ReferenceTables
		PRIMARY KEY (ReferenceTablesId)
);

