CREATE VIEW "BudgetLevels" AS
SELECT OutlayId, BudgetLevel, BFY, FundCode, AhCode, OrgCode, 
    CASE
		WHEN BocCode IN ('10', '17') THEN '06'
        WHEN FundCode LIKE 'E%' AND 
            NpmCode = 'A' THEN '06J'	
        WHEN FundCode LIKE 'E%' AND 
            NpmCode = 'B' THEN '06K'
        WHEN FundCode LIKE 'E%' AND 
            NpmCode = 'C' THEN '06B'
        WHEN FundCode LIKE 'E%' AND 
            ProgramProjectCode = '11' THEN '06B'
        WHEN FundCode LIKE 'E%' AND 
            ProgramProjectCode IN ('24', '79') THEN '06L'
        WHEN FundCode = 'T' AND 
            OrgCode LIKE '6A%' OR 
            AhCode LIKE '6A%' THEN '06L'
		WHEN FundCode LIKE 'ZL%' THEN '06K'
        WHEN FundCode LIKE 'TR%' THEN '06L'
        WHEN FundCode LIKE 'E%' AND 
            NpmCode = 'E' THEN '06M'
        WHEN FundCode LIKE 'E%' AND 
            NpmCode = 'L' THEN '06F'
		WHEN BudgetLevel = '7' AND
			FundCode = 'B' THEN '06'
		WHEN BudgetLevel = '7' AND
			FundCode = 'T' AND
			AhCode = '06' THEN '06'
		WHEN BudgetLevel = '8' AND
			FundCode IN ('B', 'T', 'H', 'F') AND
			len(RcCode) = 3 THEN RcCode
    END RcCode, 
    AccountCode, BocCode, Authority, Budgeted, Posted, CarryIn, CarryOut, Commitments, OpenCommitments, Obligations, ULO, Balance 
FROM Outlays 
WHERE 
	Authority <> 0 AND
	BocCode <> '10'
GROUP BY OutlayId, BFY, BudgetLevel, FundCode, AccountCode, ProgramProjectCode, BocCode, OrgCode, AhCode, NpmCode, RcCode, Authority, Budgeted, 
	Posted, CarryIn, CarryOut, Commitments, OpenCommitments, Obligations, ULO, Balance