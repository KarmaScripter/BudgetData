CREATE TABLE AllowanceHolders
(
	AllowanceHolderId INTEGER NOT NULL UNIQUE CONSTRAINT PK_AllowanceHolders PRIMARY KEY AUTOINCREMENT,
	Code TEXT(255) NOT NULL,
	Name TEXT(255) NULL
);
