SELECT *
FROM 
    Allocations
WHERE
	Allocations.FundCode LIKE 'E1%' AND
    Allocations.Amount <> 0 AND  
    Allocations.BudgetLevel = '7'