CREATE VIEW "Grants" 
AS SELECT * 
FROM 
    Allocations 
WHERE 
    Allocations.BocCode = '41' AND 
    Allocations.Amount <> 0 AND 
    Allocations.BudgetLevel = '7'