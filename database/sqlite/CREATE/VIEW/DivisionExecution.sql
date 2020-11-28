CREATE VIEW IF NOT EXISTS "DivisionExecution" AS 
SELECT RPIO, BFY, '8' AS BudgetLevel, FundCode, AhCode, OrgCode, REPLACE(AccountCode, 'X', ' ') AS AccountCode, ProgramProjectCode, ProgramProjectName, RcCode,
BocCode, BocName, FocCode, FocName, Commitments, OpenCommitments, Obligations, ULO, Expenditures
FROM PurchaseActivity
GROUP BY RPIO, BFY, FundCode, AhCode, OrgCode, AccountCode, BocCode, FocCode, RcCode