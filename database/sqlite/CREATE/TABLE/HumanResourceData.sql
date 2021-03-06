CREATE TABLE IF NOT EXISTS "HumanResourceData" 
(
	"HumanResourceDataId"	INTEGER NOT NULL,
	"EmployeeId"	TEXT NOT NULL DEFAULT NS,
	"FirstName"	TEXT NOT NULL DEFAULT NS,
	"LastName"	TEXT NOT NULL DEFAULT NS,
	"OccupationalSeries"	TEXT NOT NULL DEFAULT NS,
	"JobTitle"	TEXT NOT NULL DEFAULT NS,
	"EmployeeStatus"	TEXT NOT NULL DEFAULT NS,
	"SupervisorId"	TEXT NOT NULL DEFAULT NS,
	"AppointmentType"	TEXT NOT NULL DEFAULT NS,
	"BargainUnit"	TEXT NOT NULL DEFAULT NS,
	"CurrentHROrganizationCode"	TEXT NOT NULL DEFAULT NS,
	"HumanResourceOrganizationName"	TEXT NOT NULL DEFAULT NS,
	"DutyStationStateCode"	TEXT NOT NULL DEFAULT NS,
	"DutyStationCode"	TEXT NOT NULL DEFAULT NS,
	"HireDate"	TEXT NOT NULL DEFAULT NS,
	"ServiceDate"	TEXT NOT NULL DEFAULT NS,
	"IncreaseDate"	TEXT NOT NULL DEFAULT NS,
	"GradeEntryDate"	TEXT NOT NULL DEFAULT NS,
	"StepEntryDate"	TEXT NOT NULL DEFAULT NS,
	"WigiDueDate"	TEXT NOT NULL DEFAULT NS,
	"YearsOfService"	TEXT NOT NULL DEFAULT NS,
	"LocalityAdjustment"	NUMERIC DEFAULT 0.0,
	"BaseRate"	NUMERIC DEFAULT 0.0,
	"BiweeklyRate"	NUMERIC DEFAULT 0.0,
	"Compensation"	NUMERIC DEFAULT 0.0,
	PRIMARY KEY("HumanResourceDataId" AUTOINCREMENT)
);