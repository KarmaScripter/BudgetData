CREATE VIEW "ARD" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06J' AND
    Allocations.BudgetLevel = '8'