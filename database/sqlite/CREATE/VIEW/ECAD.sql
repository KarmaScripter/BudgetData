CREATE VIEW "ECAD" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06M' AND
    Allocations.BudgetLevel = '8'