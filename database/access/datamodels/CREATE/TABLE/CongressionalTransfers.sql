CREATE TABLE CongressionalTransfers
(
	CongressionalTransferId INTEGER NOT NULL UNIQUE CONSTRAINT PK_CongressionalTransfers PRIMARY KEY,
	ReprogrammingNumber TEXT(255) NULL,
	ProcessedDate DATETIME NULL,
	RPIO TEXT(255) NULL,
	AhCode TEXT(255) NULL,
	BFY TEXT(255) NULL,
	FundCode TEXT(255) NULL,
	AccountCode TEXT(255) NULL,
	OrgCode TEXT(255) NULL,
	BocCode TEXT(255) NULL,
	RcCode TEXT(255) NULL,
	Amount NUMBER NULL,
	FundName TEXT(255) NULL,
	ProgramProjectCode TEXT(255) NULL,
	ProgramProjectName TEXT(255) NULL,
	BocName TEXT(255) NULL,
	SPIO TEXT(255) NULL,
	CONSTRAINT FK_CongressionalTransfers
	FOREIGN KEY (TransferId) REFERENCES Transfers
);
