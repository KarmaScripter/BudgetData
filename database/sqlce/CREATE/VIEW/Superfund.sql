CREATE VIEW "Superfund" 
AS SELECT *
FROM 
    Allocations
WHERE Allocations.FundCode LIKE 'T%' AND
    Allocations.FundCode NOT LIKE 'TR%' AND
	Allocations.AhCode = '06' AND
    Allocations.Amount <> 0 AND  
    Allocations.BudgetLevel = '7'