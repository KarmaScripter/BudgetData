CREATE VIEW IF NOT EXISTS "CleanWaterStateRevolvingFund" 
AS SELECT *
FROM 
    Allocations
WHERE
	Allocations.FundCode LIKE 'E2%' AND
    Allocations.Amount <> 0 AND 
    Allocations.BudgetLevel = '7'