CREATE VIEW "Utilization" AS
SELECT
    OutlayId,
    BudgetLevel,
    RpioCode,
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
    RpioCode,
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
    ExecutionLevel8