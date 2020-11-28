CREATE VIEW IF NOT EXISTS "CongressionalProjects" 
AS SELECT *
FROM 
    Allocations
WHERE
	Allocations.FundCode LIKE 'E4%' AND
    Allocations.Amount <> 0 AND  
    Allocations.BudgetLevel = '7';