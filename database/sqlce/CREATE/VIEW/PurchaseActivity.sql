CREATE VIEW "PurchaseActivity" AS
SELECT RpioCode as RPIO, (SELECT '8') as BudgetLevel, BFY, FundCode, AhCode, OrgCode, REPLACE(AccountCode, 'X', ' ') AS AccountCode, NpmCode,
	DocumentControlNumber, PurchaseRequest, GrantNumber, TransactionNumber, BocCode, FocCode, FocName, SiteProjectCode, OriginalActionDate,
	
	-- Water Division  
	CASE
	WHEN OrgCode IN ('061K', '062K', '063K', '064K', '065K') THEN '06K'
	WHEN OrgCode LIKE '06_K%' THEN '06K'
	WHEN OrgCode LIKE '06K%' THEN '06K'
	WHEN FundCode LIKE 'E_%' AND
		 NpmCode = 'B' THEN '06K'
	WHEN AccountCode IN ('000B01', '000B03', '000B06', '000B06XP1', '000B08') THEN '06K'
	
	-- Air And Radiation Division 
	WHEN OrgCode LIKE '06J%' AND 
		 FundCode IN ('E1', 'E2', 'E3', 'E4') AND
		 NpmCode != 'E' THEN '06J'
	WHEN AccountCode IN ('000A04', '000A05', '000A04XPM', '000A17') THEN '06J'
	WHEN OrgCode LIKE '%06A%' THEN '06A'
	WHEN NpmCode = 'A' AND
		 FundCode LIKE 'E_%' THEN '06J'
	
	-- Land, Chemical, And Revitalization Division
	WHEN AccountCode IN ('000C09', '000C10', '000D11', '000E14', '000E12') AND
		 FundCode IN ('E1', 'E2', 'E3', 'E4') THEN '06B'
	WHEN NpmCode = 'E' AND 
		 FundCode IN ('E1', 'E2', 'E3', 'E4') THEN '06B'
	WHEN OrgCode LIKE '0600%' AND 
		 FundCode LIKE ('E%') THEN '06B'
		 
	-- External Affairs
	WHEN AccountCode IN ('06X', '06AX') THEN '06X'
	
	-- Working Captial FundCode
	WHEN BocCode = '38' THEN '06G'
		
	-- Superfund And Emergency Management
	WHEN OrgCode LIKE '06L%' THEN '06L'
	WHEN OrgCode LIKE '6A%' THEN '06L' 
	WHEN FundCode LIKE ('TR%') THEN '06L'
	WHEN AccountCode LIKE '%___EC7' AND 
		 FundCode = 'T' AND
		 BocCode NOT IN ('10', '17', '38') THEN '06L' ELSE OrgCode
	END RcCode, SUM(Commitments) AS Commitments, SUM(OpenCommitments) AS OpenCommitments, SUM(Obligations) AS Obligations, SUM(ULO) AS ULO, SUM(Expenditures) AS Expenditures
FROM Purchases
WHERE BudgetLevel = '8' AND 
	BocCode NOT IN ('10', '17') AND
	(Commitments > 0 OR OpenCommitments > 0 OR Obligations > 0 OR ULO > 0)
GROUP BY RPIO, BFY, FundCode, AhCode, AccountCode, OrgCode, BocCode, RcCode, BudgetLevel