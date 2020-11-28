CREATE VIEW "DivisionAuthority" AS 
SELECT PrcId, BFY, BudgetLevel, FundCode, AhCode, OrgCode, 
CASE 
	WHEN AccountCode LIKE '%W%' THEN substr(AccountCode, 1, 6) ELSE AccountCode
END AccountCode, RcCode, BocCode, Amount, NpmCode, ProgramProjectCode, ProgramAreaCode, Division, DivisionName, 
	ActivityCode, NpmName, ProgramProjectName, ProgramAreaName, GoalCode, GoalName, ObjectiveCode, ObjectiveName 
FROM Allocations
WHERE BudgetLevel = '8' AND Amount > 0
GROUP BY BFY, FundCode, AhCode, AccountCode, OrgCode, BocCode, RcCode, BudgetLevel, NpmCode, 
	ProgramProjectCode, ProgramAreaCode, Division, DivisionName, ActivityCode, NpmName, 
	ProgramProjectName, ProgramAreaName, GoalCode, GoalName, ObjectiveCode, ObjectiveName