CREATE VIEW "Expenditures" AS
SELECT PurchaseId as ExpenditureId, BFY, (Select 8) as BudgetLevel, RpioCode, AhCode, FundCode, OrgCode, REPLACE(AccountCode, 'X', ' ') AS ActivityCode, NpmCode, ActivityCode, 
	
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
	END RcCode, BocCode, SUM(Commitments) as Amount, FocCode, UPPER(FocName) as FocName, OriginalActionDate, DocumentControlNumber
FROM Purchases
WHERE Expenditures != 0
GROUP BY BFY, BudgetLevel, RpioCode, AhCode, FundCode, OrgCode, AccountCode, ActivityCode, BocCode, RcCode