CREATE TABLE CarryoverEstimates
(
	CarryoverEstimateId INT NOT NULL IDENTITY (1,1),
    BudgetLevel NVARCHAR(255), 
	BFY NVARCHAR(255),
    AhCode NVARCHAR(255),
	FundCode NVARCHAR(255),
	FundName NVARCHAR(255),
    OrgCode NVARCHAR(255),
    AccountCode NVARCHAR(255),
    RcCode NVARCHAR(255),
    DivisionName NVARCHAR(255),
    BocCode NVARCHAR(255),
    BocName NVARCHAR(255),
	Balance REAL,
    OpenCommitment REAL,
    Estimate REAL
);
