CREATE VIEW IF NOT EXISTS "Earmarks" 
AS SELECT *
FROM 
    Allocations
WHERE
	Allocations.FundCode LIKE 'E5%' AND
    Allocations.Amount <> 0 AND  
    Allocations.BudgetLevel = '7';