CREATE VIEW IF NOT EXISTS "WorkingCapitalFund" 
AS SELECT * 
FROM 
    Allocations 
WHERE 
    Allocations.BocCode = '38' AND 
    Allocations.Amount <> 0 AND
    Allocations.BudgetLevel = '7';