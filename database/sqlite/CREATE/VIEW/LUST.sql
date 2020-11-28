CREATE VIEW "LUST" 
AS SELECT *
FROM 
    Allocations
WHERE Allocations.FundCode LIKE 'F%' AND
    Allocations.FundCode NOT LIKE 'FS%' AND
    Allocations.Amount <> 0 AND  
    Allocations.BudgetLevel = '7'