CREATE VIEW IF NOT EXISTS "SuperfundSupplemental" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.FundCode = 'TS3' AND
    Allocations.Amount <> 0 AND 
    Allocations.BudgetLevel = '7'