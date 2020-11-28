CREATE VIEW "MSD"
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06C' AND
    Allocations.BudgetLevel = '8'