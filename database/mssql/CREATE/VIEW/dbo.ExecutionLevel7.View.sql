CREATE VIEW "ExecutionLevel7"
AS SELECT
    OutlayId,
    BudgetLevel,
    RpioCode,
    BFY,
    FundCode,
	CASE
	WHEN AhCode LIKE '6A%' THEN '6A'
	WHEN AhCode LIKE '0600%' THEN '06'
	ELSE AhCode
	END AhCode,
	CASE
	WHEN AhCode LIKE '0600%' THEN AhCode
	WHEN AhCode LIKE '6A%'  THEN AhCode
	ELSE OrgCode
    END OrgCode,
    AccountCode,
    CASE
	WHEN FundCode LIKE 'E%' AND
        NpmCode = 'A' THEN '06J'
	WHEN FundCode LIKE 'E%' AND
        NpmCode = 'C' THEN '06B'
	WHEN FundCode LIKE 'E%' AND
        ProgramProjectCode = '15' THEN '06F'
	WHEN FundCode LIKE 'E%' AND
        NpmCode IN ('C') THEN '06B'
	WHEN FundCode LIKE 'E%' AND
        NpmCode = 'E' THEN '06M'			
	WHEN FundCode LIKE 'E%' AND
        NpmCode = 'B' THEN '06K'
	WHEN FundCode LIKE 'E%' AND
        (NpmCode = 'D' AND AccountCode LIKE '%11') THEN '06B'
	WHEN FundCode LIKE 'E%' AND
        (NpmCode = 'D' AND ProgramProjectCode IN ('79', '24')) THEN '06L'
	WHEN FundCode = 'T' AND
        OrgCode LIKE '6A%' OR
        AhCode LIKE '6A%' THEN '06L'
	WHEN FundCode LIKE 'TR%' THEN '06L'
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
WHERE BudgetLevel = 7 AND
    BocCode NOT IN ('10', '17', '21', '28') AND
    (FundCode LIKE 'E%' OR
    FundCode LIKE 'TR%') AND
    Authority > 0
GROUP BY OutlayId, BFY, BudgetLevel, RpioCode, FundCode, AccountCode, ProgramProjectCode, ProgramAreaCode, BocCode, OrgCode, AhCode, NpmCode, RcCode, Authority, Budgeted, 
	Posted, CarryIn, CarryOut, Commitments, OpenCommitments, Obligations, ULO, Balance
HAVING RcCode IS NOT NULL