CREATE VIEW IF NOT EXISTS "SpecialAccounts" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.FundCode LIKE 'TR%' AND
    Allocations.AhCode = '06' AND
    Allocations.Amount <> 0 AND 
    Allocations.BudgetLevel = '7'