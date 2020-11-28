CREATE VIEW "RegionExecution" AS
SELECT BFY, BudgetLevel, FundCode, AhCode, OrgCode, AccountCode, 
	CASE 
	-- Responsibility Center Configuration
	WHEN AhCode == '6A%' THEN '06'
	WHEN AhCode != '6A' THEN '06'
	END RcCode, 
	BocCode, SUM(Commitments) AS Commitments, SUM(OpenCommitments) AS OpenCommitments, SUM(Obligations) AS Obligations, SUM(ULO) AS ULO 
FROM Outlays
WHERE BudgetLevel = '7' AND 
	(Commitments > 0 OR OpenCommitments > 0 OR Obligations > 0 OR ULO > 0)
GROUP BY BFY, FundCode, AhCode, AccountCode, OrgCode, BocCode, RcCode, BudgetLevel;