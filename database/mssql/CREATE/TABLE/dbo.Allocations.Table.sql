USE [C:\USERS\DADDY\SOURCE\REPOS\BUDGETEXECUTION\NINJA\DATABASE\SQLSERVER\R6.MDF]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Allocations](
	[PrcId] [int] IDENTITY(1,1) NOT NULL,
	[BudgetLevel] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[RPIO] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[BFY] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[FundCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[AhCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[OrgCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[RcCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[AccountCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[BocCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[Amount] [float] NOT NULL DEFAULT 0.0,
	[ActivityCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[ActivityName] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[FundName] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[BocName] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[NpmName] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[Division] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[DivisionName] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[ProgramProjectCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[ProgramProjectName] [nvarchar](100) NOT NULL DEFAULT ('NS'),
	[ProgramAreaName] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[AhName] [nvarchar](50)  NOT NULL DEFAULT ('NS'),
	[OrgName] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[GoalName] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[ObjectiveName] [nvarchar](50) NOT NULL DEFAULT ('NS'),
 CONSTRAINT [PK_Allocations] PRIMARY KEY CLUSTERED 
(
	[PrcId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


