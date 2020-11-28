CREATE VIEW IF NOT EXISTS "ORA" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06A' AND
    Allocations.Amount <> 0 AND
    Allocations.BudgetLevel = '8';