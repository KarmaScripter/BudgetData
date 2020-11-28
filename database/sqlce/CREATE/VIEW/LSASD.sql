CREATE VIEW IF NOT EXISTS "LSASD" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06H' AND
    Allocations.Amount <> 0 AND
    Allocations.BudgetLevel = '8';
