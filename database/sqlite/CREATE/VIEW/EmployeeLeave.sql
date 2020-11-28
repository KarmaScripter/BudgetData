CREATE VIEW IF NOT EXISTS 'EmployeeLeave' 
AS SELECT EmployeeNumber, FirstName, LastName,  YearToDateEarned, 
	YearToDateUsed, MaxLeaveCarryover, MaxCarryoverExcess, UseOrLose, ProjectedPayPeriod, ProjectedAnnual, AvailableHours
FROM LeaveProjections
GROUP BY EmployeeNumber, YearToDateEarned, YearToDateUsed,
	MaxLeaveCarryover, MaxCarryoverExcess, UseOrLose, ProjectedPayPeriod, ProjectedAnnual, AvailableHours