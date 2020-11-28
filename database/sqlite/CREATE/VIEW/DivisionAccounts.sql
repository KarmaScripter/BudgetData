CREATE VIEW IF NOT EXISTS "DivisionAccounts" 
AS SELECT *
FROM 
    Allocations 
WHERE Allocations.BudgetLevel = '8' AND 
    Allocations.Amount <> 0;
