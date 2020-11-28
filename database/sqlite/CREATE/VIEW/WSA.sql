CREATE VIE IF NOT EXISTS W "WSA" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06N' AND
    Allocations.Amount <> 0 AND
    Allocations.BudgetLevel = '8';