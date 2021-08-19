USE [C:\USERS\DADDY\SOURCE\REPOS\BUDGETEXECUTION\NINJA\DATABASE\SQLSERVER\R6.MDF]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Outlays](
	[OutlayId] [int] IDENTITY(1,1) NOT NULL,
	[BudgetLevel] [nvarchar](50)  NOT NULL DEFAULT ('NS'),
	[RpioCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[BFY] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[FundCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[AhCode] [nvarchar](50)  NOT NULL DEFAULT ('NS'),
	[OrgCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[RcCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[AccountCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[BocCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[Authority] [float] NOT NULL DEFAULT 0.0,
	[Budgeted] [float] NOT NULL DEFAULT 0.0,
	[Posted] [float] NOT NULL DEFAULT 0.0,
	[CarryIn] [float] NOT NULL DEFAULT 0.0,
	[CarryOut] [float] NOT NULL DEFAULT 0.0,
	[Commitments] [float] NOT NULL DEFAULT 0.0,
	[OpenCommitments] [float] NOT NULL DEFAULT 0.0,
	[Obligations] [float] NOT NULL DEFAULT 0.0,
	[ULO] [float] NOT NULL DEFAULT 0.0,
	[Balance] [float] NOT NULL DEFAULT 0.0,
	[NpmCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[ProgramProjectCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[ProgramAreaCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
 CONSTRAINT [PK_Outlays] PRIMARY KEY CLUSTERED 
(
	[OutlayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


