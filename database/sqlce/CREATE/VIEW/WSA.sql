CREATE VIEW "WSA" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06N' AND
    Allocations.BudgetLevel = '8'