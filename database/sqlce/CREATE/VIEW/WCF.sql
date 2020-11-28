CREATE VIEW "WCF" 
AS SELECT * 
FROM 
    Allocations 
WHERE 
    Allocations.RcCode = '06G' 
AND 
    Allocations.Amount <> 0 
AND 
    Allocations.BudgetLevel = '8'