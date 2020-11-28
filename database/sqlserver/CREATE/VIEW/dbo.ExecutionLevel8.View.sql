CREATE VIEW "ExecutionLevel8" AS
SELECT
    OutlayId,
    BudgetLevel,
    RpioCode,
    BFY,
    FundCode,
	CASE 
	WHEN AhCode LIKE '6A%' THEN '6A'
	ELSE AhCode
	END AhCode,
    OrgCode,
    AccountCode,
	CASE
	WHEN RcCode LIKE '6A%' AND
		FundCode LIKE 'T%' THEN '06L'
	WHEN len(RcCode) = 3 AND 
		RcCode NOT LIKE '6A%' THEN RcCode
	ELSE RcCode
	END RcCode, 
    BocCode,
    Authority,
	Budgeted,
	Posted,
	CarryIn,
	CarryOut,
	Commitments,
	OpenCommitments,
    Obligations,
	ULO,
    Balance,
    NpmCode,
    ProgramProjectCode,
    ProgramAreaCode
FROM
    Outlays
WHERE 
    BudgetLevel = '8' AND
    FundCode IN ('B', 'T', 'F', 'H', 'ZL') AND
    BocCode != '17' AND
    Authority > 0
GROUP BY 
	OutlayId, BFY, BudgetLevel, RpioCode, FundCode, AccountCode, ProgramProjectCode, ProgramAreaCode, BocCode, OrgCode, AhCode, NpmCode, RcCode, Authority, Budgeted, 
	Posted, CarryIn, CarryOut, Commitments, OpenCommitments, Obligations, ULO, Balance