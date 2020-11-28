UPDATE Outlays
SET
	RPIO = '06'
WHERE
	RPIO = '6';
--
UPDATE Outlays
SET
	AhCode = '06'
WHERE
	AhCode = '6';
--
UPDATE Outlays
SET
	OrgCode = '06'
WHERE
	OrgCode = '6';
--
UPDATE Outlays
SET
	RcCode = '06'
WHERE
	RcCode = '6';
--
UPDATE Outlays
SET
	ProgramProjectCode = '01'
WHERE
	ProgramProjectCode = '1';
--
UPDATE Outlays
SET
	ProgramProjectCode = '02'
WHERE
	ProgramProjectCode = '2';
--
UPDATE Outlays
SET
	ProgramProjectCode = '03'
WHERE
	ProgramProjectCode = '3';
--
UPDATE Outlays
SET
	ProgramProjectCode = '04'
WHERE
	ProgramProjectCode = '4';
--
UPDATE Outlays
SET
	ProgramProjectCode = '05'
WHERE
	ProgramProjectCode = '5';
--
UPDATE Outlays
SET
	ProgramProjectCode = '06'
WHERE
	ProgramProjectCode = '6';
--
UPDATE Outlays
SET
	ProgramProjectCode = '07'
WHERE
	ProgramProjectCode = '7';
--
UPDATE Outlays
SET
	ProgramProjectCode = '08'
WHERE
	ProgramProjectCode = '8';
--
UPDATE Outlays
SET
	ProgramProjectCode = '09'
WHERE
	ProgramProjectCode = '9';
--
UPDATE Outlays
SET
	Authority = 0
WHERE
	Authority IS NULL;
--
UPDATE Outlays
SET
	Commitments = 0
WHERE
	Commitments IS NULL;
--
UPDATE Outlays
SET
	Obligations = 0
WHERE
	Obligations IS NULL;
--
UPDATE Outlays
SET
	OpenCommitments = 0
WHERE
	OpenCommitments IS NULL;
--
UPDATE Outlays
SET
	ULO = 0
WHERE
	ULO IS NULL;
--