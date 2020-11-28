CREATE VIEW IF NOT EXISTS "Balances" AS
SELECT Allocations.BFY AS BFY, 
    Allocations.RPIO AS RPIO,
    Allocations.AhCode AS AhCode,
	Allocations.FundName As FundName,
    Allocations.FundCode AS FundCode,
	Allocations.ProgramProjectName AS ProgramProjectName,
    Allocations.ProgramProjectCode AS ProgramProjectCode,
    Allocations.OrgCode AS OrgCode,
	Allocations.BocName AS BocName,
    Allocations.BocCode AS BocCode,
	Allocations.DivisionName As DivisionName,
    Allocations.RcCode AS RcCode,
    Allocations.Amount AS Authority,

    -- The case statement defines the Used field:
    -- if the sum of OpenCommitments and Obligation is null then it is assigned 0.0; 
    -- if the sum of OpenCommitments and Obligations is not null then it is assigned to the
    -- rounded sum of the Open Commitments and Obligations and filtering 
    -- the Outlays fields by pairing them with their corresponding Allocations fields

	CASE 
	WHEN
    (SELECT ROUND(Outlays.OpenCommitments + Outlays.Obligations)
		FROM Outlays
        WHERE Outlays.BFY = Allocations.BFY AND
            Outlays.AhCode = Allocations.AhCode AND
            Outlays.FundCode = Allocations.FundCode AND
            Outlays.ProgramProjectCode = Allocations.ProgramProjectCode AND
            Outlays.BocCode = Allocations.BocCode AND
            Outlays.RcCode = Allocations.RcCode ) IS NULL THEN 0.0
	WHEN NOT 
		(SELECT ROUND(Outlays.OpenCommitments + Outlays.Obligations)
			FROM Outlays
			WHERE Outlays.BFY = Allocations.BFY AND
				Outlays.AhCode = Allocations.AhCode AND
				Outlays.FundCode = Allocations.FundCode AND
				Outlays.ProgramProjectCode = Allocations.ProgramProjectCode AND
				Outlays.BocCode = Allocations.BocCode AND
				Outlays.RcCode = Allocations.RcCode ) IS NULL THEN 
			(SELECT ROUND(Outlays.OpenCommitments + Outlays.Obligations)
				FROM Outlays
				WHERE Outlays.BFY = Allocations.BFY AND
					Outlays.AhCode = Allocations.AhCode AND
					Outlays.FundCode = Allocations.FundCode AND
					Outlays.ProgramProjectCode = Allocations.ProgramProjectCode AND
					Outlays.BocCode = Allocations.BocCode AND
					Outlays.RcCode = Allocations.RcCode ) 
	END Used,
    
    -- The case statement defines the Available field:
    -- if the sum of OpenCommitments and Obligation is null, 
    -- then it is assigned the value of Allocations.Amount; 
    -- if the sum of OpenCommitments and Obligations is not null, 
    -- then it is assigned to the rounded sum of the Open Commitments and Obligations and filtering 
    -- the Outlays fields by pairing them with their corresponding Allocations fields

	CASE
		WHEN (SELECT ROUND(Outlays.OpenCommitments + Outlays.Obligations)
			FROM Outlays
			WHERE Outlays.BFY = Allocations.BFY AND
				Outlays.AhCode = Allocations.AhCode AND
				Outlays.FundCode = Allocations.FundCode AND
				Outlays.ProgramProjectCode = Allocations.ProgramProjectCode AND
				Outlays.BocCode = Allocations.BocCode AND
				Outlays.RcCode = Allocations.RcCode ) IS NULL THEN Allocations.Amount
		WHEN NOT (SELECT ROUND(Outlays.OpenCommitments + Outlays.Obligations)
			FROM Outlays
			WHERE Outlays.BFY = Allocations.BFY AND
				Outlays.AhCode = Allocations.AhCode AND
				Outlays.FundCode = Allocations.FundCode AND
				Outlays.ProgramProjectCode = Allocations.ProgramProjectCode AND
				Outlays.BocCode = Allocations.BocCode AND
				Outlays.RcCode = Allocations.RcCode ) IS NULL THEN
			(SELECT ROUND(Allocations.Amount - (Outlays.OpenCommitments + ABS(Outlays.Obligations)))
			FROM Outlays
			WHERE Outlays.BFY = Allocations.BFY AND
				Outlays.AhCode = Allocations.AhCode AND
				Outlays.FundCode = Allocations.FundCode AND
				Outlays.ProgramProjectCode = Allocations.ProgramProjectCode AND
				Outlays.BocCode = Allocations.BocCode AND
				Outlays.RcCode = Allocations.RcCode )  
	END Available
FROM Allocations
WHERE 
	Allocations.BudgetLevel = '8' AND
	BocCode IN ('21', '28', '36', '37', '38', '41') AND
	Allocations.Amount > 0
ORDER BY BFY DESC;