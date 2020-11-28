SELECT ID, BFY, Fund, FundName, AH, AhName, Org, OrgName, NpmCode, NPM, 
	case 
	when Org LIKE "6A%" then "06L"
	when Org = "06A" then Org
	when Org = "06J" then Org
	when Org = "06C" then Org
	when Org = "06M" then Org
	when Org = "06D" then Org
	when Org = "06F" then Org
	when Org = "06G" then Org
	when Org = "06R" then Org
	when Org = "06K" then Org
	when Org = "06L" then Org
	when Org LIKE "06LA%" then "06L"
	when Org = "06X" then Org
	when Org = "06N" then Org	
	when Org LIKE "06_K%" then "06K"
	when Org LIKE "06K0X%" then "06K"
	when Org LIKE "06K%" then "06K"
	when Org LIKE "065K" then "06K"
	when Org LIKE "06J%" then "06J"
	when Org LIKE "0600%" then "06L"
	when Org LIKE "06_Z" AND ProgramProjectCode in ("14", "11", "04", "05", "08", "09", "10") then "06J"
	when Org LIKE "06_Z" AND ProgramProjectCode in ("01", "03", "06", "07") then "06K"
	end RC,
	DivisionName, Code, ProgramProjectCode, ProgramProjectName, BOC, BocName, FOC, FocName, DCN, DocType, ProcessedDate, OpenCommitments, ULO, Obligations	
FROM ProgramObligations
WHERE BOC IN ("36", "37", "38", "41")
ORDER BY ID;