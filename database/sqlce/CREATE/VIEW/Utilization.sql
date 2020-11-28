CREATE VIEW IF NOT EXISTS "Utilization" AS
SELECT
    OutlayId,
    BudgetLevel,
    RPIO,
    BFY,
    FundCode,
    AhCode,
    OrgCode,
    RcCode,
    AccountCode,
    BocCode,
    Authority,
    Obligations,
	Balance,
	round(((Obligations/Authority)*100), 2) AS Rate,
    NpmCode,
    ProgramProjectCode,
    ProgramAreaCode
FROM
    ExecutionLevel7
WHERE 
    RcCode IS NOT NULL AND
	BocCode <> '10'
UNION ALL
SELECT
    OutlayId,
    BudgetLevel,
    RPIO,
    BFY,
    FundCode,
    AhCode,
    OrgCode,
    RcCode,
    AccountCode,
    BocCode,
    Authority,
    Obligations,
	Balance,
	round(((Obligations/Authority)*100), 2) AS Rate,
    NpmCode,
    ProgramProjectCode,
    ProgramAreaCode
FROM ExecutionLevel8
ORDER BY BFY, RcCode, FundCode, BocCode;

