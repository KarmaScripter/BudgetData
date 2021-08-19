CREATE TABLE [dbo].[PayrollHours](
	[PayrollHoursId] [int] IDENTITY(1,1) NOT NULL,
	[RpioCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[PayPeriod] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[StartDate] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[EndDate] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[EmployeeNumber] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[EmployeeFirstName] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[EmployeeLastName] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[Date] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[HumanResourceOrganizationCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[HumanResourceOrganizationName] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[ReportingCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[ReportingCodeName] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[WorkCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[Hours] [float] NOT NULL DEFAULT 0.0,
 CONSTRAINT [PK_PayrollHours] PRIMARY KEY CLUSTERED 
(
	[PayrollHoursId] ASC
);


