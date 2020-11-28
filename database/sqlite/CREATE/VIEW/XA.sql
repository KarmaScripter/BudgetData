CREATE VIEW IF NOT EXISTS "XA" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06X' AND
    Allocations.BudgetLevel = '8' AND
    Allocations.Amount <> 0;