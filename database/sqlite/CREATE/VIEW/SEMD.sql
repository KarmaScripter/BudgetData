CREATE VIEW IF NOT EXISTS "SEMD" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06L' AND
    Allocations.Amount <> 0 AND 
    Allocations.BudgetLevel = '8'