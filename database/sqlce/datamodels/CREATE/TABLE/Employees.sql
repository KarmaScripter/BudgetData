CREATE TABLE Employees
(
	PersonnelId INTEGER NOT NULL UNIQUE CONSTRAINT PK_EnforcmentAndComplianceAssuranceDivisionAuthority PRIMARY KEY,
	RcCode TEXT(255) NULL,
	EpaNumber TEXT(255) NULL,
	LastName TEXT(255) NULL,
	FirstName TEXT(255) NULL,
    CONSTRAINT FK_Contracts
    FOREIGN KEY (PrcId) 
    REFERENCES Allocations
);

