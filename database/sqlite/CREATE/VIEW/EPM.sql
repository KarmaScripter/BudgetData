CREATE VIEW IF NOT EXISTS "EPM" 
AS SELECT *
FROM 
    Allocations
WHERE Allocations.FundCode LIKE 'B%' AND
    Allocations.Amount <> 0 AND  
    Allocations.BudgetLevel = '7';