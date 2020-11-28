SELECT 
    BudgetLevelId, BudgetLevel, RPIO, BFY, FundCode, FundName, NpmCode, NpmName, AhCode, AhName, RcCode, DivisionName, OrgCode, OrgName, Code,
    ProgramProjectCode, ProgramProjectName, ProgramAreaCode, ProgramAreaName, BocCode, BocName, FocCode, FocName, Authority, Budgeted, Posted, CarryIn,
    CarryOut, Commitments, OpenCommitments, Obligations, ULO, Balance 
FROM NoYearFunds 
WHERE RcCode NOT NULL 
UNION ALL 
SELECT 
    BudgetLevelId, BudgetLevel, RPIO, BFY, FundCode, FundName, NpmCode, NpmName, AhCode, AhName, RcCode, DivisionName, OrgCode, OrgName, Code,
    ProgramProjectCode, ProgramProjectName, ProgramAreaCode, ProgramAreaName, BocCode, BocName, FocCode, FocName, Authority, Budgeted, Posted, CarryIn,
    CarryOut, Commitments, OpenCommitments, Obligations, ULO, Balance 
FROM ExpiringFunds;