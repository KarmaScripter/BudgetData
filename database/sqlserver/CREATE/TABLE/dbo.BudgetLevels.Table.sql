USE [C:\USERS\DADDY\SOURCE\REPOS\BUDGETEXECUTION\NINJA\DATABASE\SQLSERVER\R6.MDF]
GO
/****** Object:  Table [dbo].[BudgetLevels]    Script Date: 2019-10-06 23:37:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudgetLevels](
	[BudgetLevelId] [int] IDENTITY(1,1) NOT NULL,
	[BudgetLevel] [nvarchar](255) NOT NULL,
	[RPIO] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[NpmCode] [nvarchar](255) NULL,
	[NpmName] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[AhName] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[OrgName] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[Code] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[FocCode] [nvarchar](255) NULL,
	[FocName] [nvarchar](255) NULL,
	[Authority] [float] NULL,
	[Budgeted] [float] NULL,
	[Posted] [float] NULL,
	[CarryIn] [float] NULL,
	[CarryOut] [float] NULL,
	[Commitments] [float] NULL,
	[OpenCommitments] [float] NULL,
	[Obligations] [float] NULL,
	[ULO] [float] NULL,
	[Balance] [float] NULL,
 CONSTRAINT [PK_BudgetLevels] PRIMARY KEY CLUSTERED 
(
	[BudgetLevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BudgetLevels] ADD  CONSTRAINT [DF_BudgetLevels_Authority]  DEFAULT ((0)) FOR [Authority]
GO
ALTER TABLE [dbo].[BudgetLevels] ADD  CONSTRAINT [DF_BudgetLevels_Budgeted]  DEFAULT ((0)) FOR [Budgeted]
GO
ALTER TABLE [dbo].[BudgetLevels] ADD  CONSTRAINT [DF_BudgetLevels_Posted]  DEFAULT ((0)) FOR [Posted]
GO
ALTER TABLE [dbo].[BudgetLevels] ADD  CONSTRAINT [DF_BudgetLevels_CarryIn]  DEFAULT ((0)) FOR [CarryIn]
GO
ALTER TABLE [dbo].[BudgetLevels] ADD  CONSTRAINT [DF_BudgetLevels_CarryOut]  DEFAULT ((0)) FOR [CarryOut]
GO
ALTER TABLE [dbo].[BudgetLevels] ADD  CONSTRAINT [DF_BudgetLevels_Commitments]  DEFAULT ((0)) FOR [Commitments]
GO
ALTER TABLE [dbo].[BudgetLevels] ADD  CONSTRAINT [DF_BudgetLevels_OpenCommitments]  DEFAULT ((0)) FOR [OpenCommitments]
GO
ALTER TABLE [dbo].[BudgetLevels] ADD  CONSTRAINT [DF_BudgetLevels_Obligations]  DEFAULT ((0)) FOR [Obligations]
GO
ALTER TABLE [dbo].[BudgetLevels] ADD  CONSTRAINT [DF_BudgetLevels_ULO]  DEFAULT ((0)) FOR [ULO]
GO
ALTER TABLE [dbo].[BudgetLevels] ADD  CONSTRAINT [DF_BudgetLevels_Balance]  DEFAULT ((0)) FOR [Balance]
GO
