CREATE VIEW "DrinkingWaterStateRevolvingFund" 
AS SELECT *
FROM 
    Allocations
WHERE
	Allocations.FundCode LIKE 'E3%' AND
    Allocations.Amount <> 0 AND  
    Allocations.BudgetLevel = '7'