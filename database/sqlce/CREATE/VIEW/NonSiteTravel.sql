CREATE VIEW IF NOT EXISTS "NonSiteTravel" 
AS SELECT *
FROM 
    Allocations
WHERE
    Allocations.BocCode = '21' AND
    Allocations.Amount <> 0 AND  
    Allocations.BudgetLevel = '7';