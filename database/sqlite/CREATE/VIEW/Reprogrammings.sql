CREATE VIEW IF NOT EXISTS "Reprogrammings" 
AS SELECT TransferId, BudgetLevel, DocumentNumber, AhCode, OrgCode, RcCode, FundCode, BFY, AccountCode, FromTo, 
	CASE 
		WHEN FromTo = 'TO' THEN 'INCREASE' 
		WHEN FromTo = 'FROM' THEN 'DECREASE'
	END Net, BocCode, 
	CASE 
		WHEN FromTo = 'TO' THEN Amount
		WHEN FromTo = 'FROM' THEN Amount * -1
	END Amount, 
ProcessedDate, Purpose
FROM Transfers 
GROUP BY DocumentNumber, ProcessedDate, AccountCode, BocCode, FromTo