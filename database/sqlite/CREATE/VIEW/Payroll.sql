CREATE VIEW IF NOT EXISTS "Payroll" 
AS SELECT *
FROM 
    Allocations
WHERE
    Allocations.BocCode = '10' AND
    Allocations.Amount <> 0 AND  
    Allocations.BudgetLevel = '7';