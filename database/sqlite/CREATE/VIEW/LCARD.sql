CREATE VIEW IF NOT EXISTS "LCARD" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06B' AND
    Allocations.Amount <> 0 AND 
    Allocations.BudgetLevel = '8';
