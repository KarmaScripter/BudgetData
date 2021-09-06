CREATE VIEW "CleanWaterStateRevolvingFund" 
AS SELECT *
FROM 
    PRC
WHERE
	PRC.FundCode LIKE 'E2%' AND
    PRC.Amount <> 0 AND 
    PRC.BudgetLevel = '7'