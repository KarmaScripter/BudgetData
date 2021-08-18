CREATE TABLE AirAndRadiationObligations
(
    AirAndRadiationObligationId INTEGER NOT NULL UNIQUE CONSTRAINT     
		PK_AirAndRadiationObligations PRIMARY KEY,
	PurchaseId INTEGER NOT NULL,
	RpioCode TEXT(255) NULL,
	BFY TEXT(255) NULL,
	RcCode TEXT(255) NULL,
	DivisionName TEXT(255) NULL,
	AhCode TEXT(255) NULL,
	AhName TEXT(255) NULL,
	FundCode TEXT(255) NULL,
	FundName TEXT(255) NULL,
	AccountCode TEXT(255) NULL,
	ActivityCode TEXT(255) NULL,
	BocCode TEXT(255) NULL,
	BocName TEXT(255) NULL,
	NpmCode TEXT(255) NULL,
	NpmName TEXT(255) NULL,
	OrgCode TEXT(255) NULL,
	ProgramProjectCode TEXT(255) NULL,
	ProgramProjectName TEXT(255) NULL,
	ProgramAreaCode TEXT(255) NULL,
	ProgramAreaName TEXT(255) NULL,
	DocumentControlNumbers TEXT(255) NULL,
	ReimbursableAgreementNumber TEXT(255) NULL,
	SiteProjectCode TEXT(255) NULL,
	DcnPrefix TEXT(255) NULL,
	DocType TEXT(255) NULL,
	FocCode TEXT(255) NULL,
	FocName TEXT(255) NULL,
	OriginalActionDate DATETIME NULL,
	LastActionDate DATETIME NULL,
	Commitments DOUBLE NOT NULL DEFAULT 0,
	OpenCommitments DOUBLE NOT NULL DEFAULT 0,
	Obligations DOUBLE NOT NULL DEFAULT 0,
	Deobligations DOUBLE NOT NULL DEFAULT 0,
	ULO DOUBLE NOT NULL DEFAULT 0,
	Expenditures DOUBLE NOT NULL DEFAULT 0,
	Used DOUBLE NOT NULL DEFAULT 0,
    	CONSTRAINT FK_AirAndRadiationDivisionObligations
    	FOREIGN KEY (PurchaseId) 
    	REFERENCES Purchases
);