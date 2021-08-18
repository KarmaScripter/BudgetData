CREATE TABLE [PayrollHours]
(
   [PayrollHoursId] INT NOT NULL IDENTITY (1,1),
   [RpioCode] NVARCHAR(255) DEFAULT ('NS'),
   [PayPeriod] NVARCHAR(255) DEFAULT ('NS'),
   [StartDate] NVARCHAR(255) DEFAULT ('NS'),
   [EndDate] NVARCHAR(255) DEFAULT ('NS'),
   [EmployeeNumber] NVARCHAR(255) DEFAULT ('NS'),
   [EmployeeFirstName] NVARCHAR(255) DEFAULT ('NS'),
   [EmployeeLastName] NVARCHAR(255) DEFAULT ('NS'),
   [Date] NVARCHAR(255) DEFAULT ('NS'),
   [HumanResourceOrganizationCode] NVARCHAR(255) DEFAULT ('NS'),
   [HumanResourceOrganizationName] NVARCHAR(255) DEFAULT ('NS'),
   [ReportingCode] NVARCHAR(255) DEFAULT ('NS'),
   [ReportingCodeName] NVARCHAR(255) DEFAULT ('NS'),
   [WorkCode] NVARCHAR(255) DEFAULT ('NS'),
   [Hours] FLOAT DEFAULT ('0.0')
);
