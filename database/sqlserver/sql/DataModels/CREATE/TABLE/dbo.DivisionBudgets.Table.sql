USE [DataModels]
GO
/****** Object:  Table [dbo].[DivisionBudgets]    Script Date: 7/17/2021 9:04:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DivisionBudgets](
	[BudgetId] [int] NOT NULL,
	[BFY] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL
) ON [PRIMARY]
GO
