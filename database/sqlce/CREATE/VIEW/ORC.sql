CREATE VIEW "ORC" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06D' AND
    Allocations.BudgetLevel = '8'