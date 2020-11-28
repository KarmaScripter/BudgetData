CREATE VIEW IF NOT EXISTS "WD" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06K' AND
    Allocations.Amount <> 0 AND
    Allocations.BudgetLevel = '8';

