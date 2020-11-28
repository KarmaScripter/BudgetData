CREATE VIEW IF NOT EXISTS "SiteTravel" 
AS SELECT *
FROM 
    Allocations
WHERE
    Allocations.BocCode = '28' AND
    Allocations.Amount <> 0 AND  
    Allocations.BudgetLevel = '7'