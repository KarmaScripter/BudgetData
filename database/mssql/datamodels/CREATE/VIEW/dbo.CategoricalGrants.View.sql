CREATE VIEW "CategoricalGrants" 
AS SELECT *
FROM 
    PRC
WHERE
	PRC.FundCode LIKE 'E1%' AND
    PRC.Amount <> 0 AND  
    PRC.BudgetLevel = '7'