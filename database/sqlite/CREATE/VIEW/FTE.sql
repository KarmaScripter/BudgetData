CREATE VIEW IF NOT EXISTS "FTE" 
AS SELECT *
FROM Allocations 
WHERE Allocations.BudgetLevel = '7' AND 
	Allocations.Amount <> 0 AND
	Allocations.BocCode = '17';
