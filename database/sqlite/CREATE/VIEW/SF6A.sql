CREATE VIEW "SF6A" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.AhCode LIKE '6A%' AND
    Allocations.Amount <> 0 AND 
    Allocations.BudgetLevel = '7'