CREATE TABLE PayrollCostCodes
(
	PayrollCostCodesId INT NOT NULL IDENTITY (1,1),
    RpioCode NVARCHAR(255) NULL,
    RpioName NVARCHAR(255) NULL,
    AhCode NVARCHAR(255) NULL,
    BFY NVARCHAR(255) NULL,
	RcCode NVARCHAR(255) NULL,
    WorkCode NVARCHAR(255) NULL,
    WorkCodeName NVARCHAR(255) NULL,
    HrOrgCode NVARCHAR(255) NULL,
    HrOrgName NVARCHAR(255) NULL,
        CONSTRAINT PK_PayrollCostCodes
        PRIMARY KEY (PayrollCostCodesId)
);