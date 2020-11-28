CREATE VIEW IF NOT EXISTS "Outlays" 
AS SELECT RPIO, BFY, FundCode, AhCode, OrgCode, DocumentControlNumber, SiteProjectCode, AccountCode, ProgramProjectCode, ProgramProjectName, RcCode, BocCode, BocName, FocCode, FocName, OriginalActionDate, 
	SUM(Commitments) AS Commitments, SUM(OpenCommitments) AS OpenCommitments, SUM(Obligations) AS Obligations, SUM(ULO) AS ULO, SUM(Expenditures) AS Expenditures
FROM PurchaseActivity
GROUP BY RPIO, BFY, FundCode, AhCode, OrgCode, DocumentControlNumber, SiteProjectCode, AccountCode, ProgramProjectCode, RcCode, BocCode, FocCode, OriginalActionDate
HAVING NOT (OpenCommitments = 0 AND Commitments = 0 AND Obligations = 0 AND Expenditures = 0 AND ULO = 0);