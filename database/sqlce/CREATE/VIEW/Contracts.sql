CREATE VIEW IF NOT EXISTS "Contracts" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.BocCode = '37' AND 
    Allocations.Amount <> 0 AND 
    Allocations.BudgetLevel = '7'