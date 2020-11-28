CREATE VIEW IF NOT EXISTS "Commitments" AS
SELECT PurchaseId as CommitmentId, BFY, (Select 8) as BudgetLevel, RpioCode, AhCode, FundCode, OrgCode, REPLACE(AccountCode, 'X', ' ') AS AccountCode, ProgramProjectCode, ProgramProjectName, OriginalActionDate, DocumentControlNumber, BocCode, BocName, FocCode, UPPER(FocName) as FocName, 
	CASE
	-- Working Captial FundCode
	WHEN BocCode = '38' THEN '06G'
	
	-- Missison Support Division
	WHEN OrgCode LIKE '06C%' THEN '06C'
	
	-- Office of the Regional Administrator
	WHEN OrgCode LIKE '06A%' THEN '06A'
	
	-- Office of the Regional Counsel
	WHEN OrgCode LIKE '06D%' THEN '06D'
	
	-- Environmental Justice
	WHEN OrgCode LIKE '06F%' THEN '06F'
	
	-- Workforce Support AccountCode
	WHEN OrgCode LIKE '06N%' THEN '06N'

	-- Enforcement And Compliance Assurance 
	WHEN OrgCode LIKE '06M%' THEN '06M'
	
	-- Water Division  	
	WHEN OrgCode IN ('061K', '062K', '063K', '064K', '065K') THEN '06K'	
	WHEN OrgCode LIKE '06K%' THEN '06K'
	WHEN OrgCode LIKE '06_K%' THEN '06K'
	WHEN OrgCode LIKE '06K%' THEN '06K'
	WHEN FundCode LIKE 'E_%' AND
		 NpmCode = 'B' THEN '06K'
	WHEN AccountCode IN ('000B01', '000B03', '000B06', '000B06XP1', '000B08') THEN '06K'
	WHEN AccountCode IN ('___M20%', '000M20') AND
		 OrgCode NOT LIKE '06B_' THEN '06K'
	
	-- Air And Radiation Division 
	WHEN OrgCode LIKE '06J%' THEN '06J'
	WHEN OrgCode LIKE '06J%' AND 
		 FundCode IN ('E1', 'E2', 'E3', 'E4') AND
		 NpmCode != 'E' THEN '06J'
	WHEN AccountCode IN ('000A04', '000A05', '000A04XPM', '000A17') THEN '06J'
	WHEN OrgCode LIKE '%06A%' THEN '06A'
	WHEN NpmCode = 'A' AND
		 FundCode LIKE 'E_%' THEN '06J'
	
	-- Land, Chemical, And Revitalization Division
	WHEN OrgCode LIKE '06B%' THEN '06B'
	WHEN AccountCode IN ('000C09', '000C10', '000D11', '000E14', '000E12') AND
		 FundCode IN ('E1', 'E2', 'E3', 'E4') THEN '06B'
	WHEN NpmCode = 'E' AND 
		 FundCode IN ('E1', 'E2', 'E3', 'E4') THEN '06B'
	WHEN OrgCode LIKE '0600%' AND 
		 FundCode LIKE ('E%') THEN '06B'
		 
	-- External Affairs
	WHEN OrgCode LIKE '06X%' THEN '06X'
	
	-- Laboratory Services And Applied Sciences
	WHEN OrgCode LIKE '06H%' THEN '06H'
	WHEN AccountCode LIKE '%W2' THEN '06H'
	WHEN AccountCode LIKE '%RL' THEN '06H'
		
	-- Superfund And Emergency Management
	WHEN OrgCode LIKE '06L%' THEN '06L'
	WHEN OrgCode LIKE '6A%' THEN '06L' 
	WHEN FundCode LIKE ('TR%') THEN '06L'
	WHEN AccountCode LIKE '%___EC7' AND 
		 FundCode = 'T' AND
		 BocCode NOT IN ('10', '17', '38') THEN '06L' ELSE substr(OrgCode, 0, 3)
	END RcCode, SUM(Commitments) AS Amount 
FROM Purchases
GROUP BY BFY, BudgetLevel, RpioCode, AhCode, FundCode, AccountCode, OrgCode, BocCode, FocCode, RcCode
HAVING Amount <> 0;