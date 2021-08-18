USE [DataModels]
GO

/****** Object:  Table [dbo].[BenefitCharges]    Script Date: 8/2/2021 7:39:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BenefitCharges](
	[EmployeeBenefitsId] [int] NOT NULL,
	[PeoplePlusId] [int] NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[EpaNumber] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[FirstName] [nvarchar](255) NULL,
	[ReportingCode] [nvarchar](255) NULL,
	[ReportingCodeName] [nvarchar](255) NULL,
	[HrOrgCode] [nvarchar](255) NULL,
	[WorkCode] [nvarchar](255) NULL,
	[PayPeriod] [nvarchar](255) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Hours] [float] NULL
) ON [PRIMARY]
GO


