CREATE VIEW IF NOT EXISTS "StatusOfFunds" 
AS SELECT 
	OutlayId, BudgetLevel, BFY, FundCode, AhCode, OrgCode, 
    CASE
        WHEN FundCode LIKE 'E%' AND 
            NpmCode = 'A' THEN '06J'	
        WHEN FundCode LIKE 'E%' AND 
            NpmCode = 'B' THEN '06K'
        WHEN FundCode LIKE 'E%' AND 
            NpmCode IN ('D', 'C') THEN '06B'
        WHEN FundCode = 'T' AND 
            OrgCode LIKE '6A%' OR 
            AhCode LIKE '6A%' THEN '06L'
        WHEN FundCode LIKE 'TR%' THEN '06L'
        WHEN FundCode LIKE 'E%' AND 
            NpmCode = 'E' THEN '06M'
        WHEN FundCode LIKE 'E%' AND 
            NpmCode = 'L' THEN '06F'
		WHEN BudgetLevel = '7' AND 
			FundCode IN ('H', 'HR', 'HD', 'B', 'T', 'TD', 'TS3', 'F', 'FD', 'FR', 'FS3', 'ZL') THEN AhCode
		WHEN BudgetLevel = '8' AND 
		length(OrgCode) = 3 THEN OrgCode
    END 
	RcCode, AccountCode, BocCode, Authority, Budgeted, Posted, CarryIn, CarryOut, Commitments, OpenCommitments, Obligations, ULO, Balance 
FROM 
	Outlays 
WHERE 
	(Authority <> 0)
GROUP BY 
	BFY, AhCode, FundCode, AccountCode, BocCode, RcCode;
