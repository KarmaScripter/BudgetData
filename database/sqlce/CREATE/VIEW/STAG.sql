CREATE VIEW "STAG" 
AS SELECT *
FROM 
    Allocations
WHERE
	Allocations.FundCode LIKE 'E%' AND
    Allocations.Amount <> 0 AND  
    Allocations.BudgetLevel = '7'