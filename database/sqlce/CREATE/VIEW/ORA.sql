CREATE VIEW "ORA" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06A' AND
    Allocations.BudgetLevel = '8'