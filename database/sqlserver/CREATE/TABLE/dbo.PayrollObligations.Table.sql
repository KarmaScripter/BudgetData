USE [C:\USERS\DADDY\SOURCE\REPOS\BUDGETEXECUTION\NINJA\DATABASE\SQLSERVER\R6.MDF]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PayrollObligations](
	[PayrollObligationsId] [int] IDENTITY(1,1) NOT NULL,
	[RpioCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[BFY] [nvarchar](50)  NOT NULL DEFAULT ('NS'),
	[FundCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[AhCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[OrgCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[RcCode] [nvarchar](50)  NOT NULL DEFAULT ('NS'),
	[AccountCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[ProgramProjectCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[Amount] [float] NOT NULL DEFAULT 0.0,
	[Hours] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[CumulativeBenefits] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[AnnualOvertimePaid] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[AnnualOvertimeHours] [nvarchar](50)  NOT NULL DEFAULT ('NS'),
	[AnnualBasePaid] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[AnnualBaseHours] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[AnnualOtherHours] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[AnnualOtherPaid] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[AllocationPercentage] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[PayPeriod] [nvarchar](100) NOT NULL DEFAULT ('NS'),
	[FocCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[FocName] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[WorkCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[WorkCodeName] [nvarchar](100) NOT NULL DEFAULT ('NS'),
	[HumanResourceOrganizationCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
 CONSTRAINT [PK_PayrollObligations] PRIMARY KEY CLUSTERED 
(
	[PayrollObligationsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


