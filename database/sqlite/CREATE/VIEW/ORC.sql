CREATE VIEW IF NOT EXISTS "ORC" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06D' AND
    Allocations.Amount <> 0 AND
    Allocations.BudgetLevel = '8'