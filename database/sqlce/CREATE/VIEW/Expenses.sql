CREATE VIEW IF NOT EXISTS "Expenses" 
AS SELECT * 
FROM 
    Allocations 
WHERE 
    Allocations.BocCode = '36' AND 
    Allocations.Amount <> 0 AND 
    Allocations.BudgetLevel = '7';