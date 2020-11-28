SELECT rowid AS PrcId, 
	(SELECT BudgetLevels.Code 
        FROM BudgetLevels 
        WHERE BudgetLevels.Code = Allocations.BudgetLevel) AS BudgetLevel,
	(SELECT ResourcePlanningOffices.Code 
        FROM ResourcePlanningOffices 
        WHERE ResourcePlanningOffices.Code = Allocations.RPIO) AS RPIO,
	(SELECT  FiscalYears.BBFY 
        FROM FiscalYears 
        WHERE FiscalYears.BBFY = Allocations.BFY) AS BFY,
	(SELECT Funds.Code 
        FROM Funds 
        WHERE Funds.Code = Allocations.FundCode) AS FundCode, 
	(SELECT AllowanceHolders.Code  
        FROM AllowanceHolders 
        WHERE AllowanceHolders.Code = Allocations.AhCode) AS AhCode,
	(SELECT Organizations.Code 
        FROM Organizations 
        WHERE Organizations.Code = Allocations.OrgCode) AS OrgCode,
	(SELECT ResponsibilityCenters.Code 
        FROM ResponsibilityCenters 
        WHERE ResponsibilityCenters.Code = Allocations.RcCode) AS RcCode,
	(SELECT Accounts.Code
        FROM Accounts
		WHERE Accounts.Code = Allocations.AccountCode) AS AccountCode,	
	(SELECT BudgetObjectClass.Code 
        FROM BudgetObjectClass 
        WHERE BudgetObjectClass.Code = Allocations.BocCode) AS BocCode,
	Allocations.Amount,
	(SELECT Activity.Code
		FROM Activity
		WHERE Allocations.AccountCode IS NOT NULL AND
			Activity.Code = Allocations.ActivityCode) AS ActivityCode, 
	(SELECT Activity.Name
		FROM Activity
		WHERE Activity.Code = Allocations.ActivityCode) AS ActivityCodeName,
	(SELECT Funds.Name
		FROM Funds
		WHERE Funds.Code = Allocations.FundCode) AS FundName,
	(SELECT BudgetObjectClass.Name
		FROM BudgetObjectClass
		WHERE BudgetObjectClass.Code = Allocations.BocCode) AS BocName,
	(SELECT NationalPrograms.Name
		FROM NationalPrograms
		WHERE NationalPrograms.Code = Allocations.NpmCode) as NpmName,
	(SELECT Divisions.Caption
		FROM Divisions
		WHERE Divisions.Code = Allocations.RcCode) AS Division,
	(SELECT Divisions.Title
		FROM Divisions
		WHERE Divisions.Code = Allocations.RcCode) as DivisionName,
	(SELECT ProgramProjects.Code
		FROM ProgramProjects
		WHERE ProgramProjects.Code = Allocations.ProgramProjectCode) AS ProgramProjectCode,
	(SELECT ProgramProjects.Name
		FROM ProgramProjects
		WHERE ProgramProjects.Code = Allocations.ProgramProjectCode) AS ProgramProjectName,
	(SELECT ProgramAreas.Name
		FROM ProgramAreas
		WHERE ProgramAreas.Code = Allocations.ProgramAreaCode) as ProgramAreaName,
	(SELECT AllowanceHolders.Name
		FROM AllowanceHolders
		WHERE AllowanceHolders.Code = Allocations.AhCode) as AhName,
	(SELECT Organizations.Name
		FROM Organizations
		WHERE Organizations.Code = Allocations.OrgCode) as OrgName,
	(SELECT Goals.Name
		FROM Goals
		WHERE Goals.Code = Allocations.GoalCode) as GoalName, 
	(SELECT Objectives.Name
		FROM Objectives
		WHERE Objectives.Code = Allocations.ObjectiveCode) as ObjectiveName
FROM Allocations
ORDER BY BFY, FundCode, AhCode, OrgCode, AccountCode, BocCode, RcCode, BudgetLevel;