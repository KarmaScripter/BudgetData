CREATE VIEW IF NOT EXISTS "NetTransfers"
AS SELECT 
	DocumentNumber, BFY, BudgetLevel, FundCode, AhCode, OrgCode, RcCode, AccountCode, BocCode, Amount, Net, ProcessedDate, Purpose
FROM 
	Reprogrammings
GROUP BY 
	ProcessedDate, DocumentNumber, FundCode, AhCode, OrgCode, RcCode, AccountCode, BocCode
ORDER BY 
	BFY DESC;