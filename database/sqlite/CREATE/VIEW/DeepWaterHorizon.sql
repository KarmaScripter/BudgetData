CREATE VIEW IF NOT EXISTS "DeepWaterHorizon" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.FundCode = 'ZL' AND
    Allocations.Amount <> 0 AND 
    Allocations.BudgetLevel = '7';
