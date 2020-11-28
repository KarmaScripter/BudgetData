CREATE VIEW  IF NOT EXISTS "ARD" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06J' AND
	Allocations.Amount <> 0 AND
    Allocations.BudgetLevel = '8';