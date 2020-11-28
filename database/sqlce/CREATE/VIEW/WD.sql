CREATE VIEW IF NOT EXISTS "WD" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06K' AND
    Allocations.BudgetLevel = '8';

