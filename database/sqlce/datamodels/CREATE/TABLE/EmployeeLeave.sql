CREATE TABLE EmployeeLeave
(
	EmployeeLeaveId INTEGER NOT NULL UNIQUE IDENTITY(1,1),
	LastName NVARCHAR(255) NULL,
	FirstName NVARCHAR(255) NULL,
	EmployeeId NVARCHAR(255) NULL,
	HoursEarnedYearToDate FLOAT NULL,
	CarryoverHours FLOAT NULL,
	HoursAdjustedYearToDate FLOAT NULL,
	HoursBalance FLOAT NULL,
	ProjectedAnnualHours FLOAT NULL,
	ProjectedNextPeriodHours FLOAT NULL,
	HoursTakenYearToDate FLOAT NULL
);

