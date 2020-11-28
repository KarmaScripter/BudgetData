CREATE VIEW IF NOT EXISTS "LustSupplemental" 
AS SELECT *
FROM 
    Allocations
WHERE Allocations.FundCode LIKE 'FS%'AND
    Allocations.Amount <> 0 AND  
    Allocations.BudgetLevel = '7';