USE [C:\USERS\DADDY\SOURCE\REPOS\BUDGETEXECUTION\NINJA\DATABASE\SQLSERVER\R6.MDF]
GO
/****** Object:  Table [dbo].[Purchases]    Script Date: 2019-10-06 23:37:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchases](
	[PurchaseId] [int] IDENTITY(1,1) NOT NULL,
	[RPIO] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[FundCode] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[AhCode] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[OrgCode] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[RcCode] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[DocType] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[DCN] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[ODN] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[BocCode] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[FocCode] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[AccountCode] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[SiteProjectCode] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[System] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[PurchaseRequest] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[Expenditure] [float] NOT NULL DEFAULT 0.0,
	[Commitments] [float] NOT NULL DEFAULT 0.0,
	[Obligations] [float] NOT NULL DEFAULT 0.0,
	[OpenCommitments] [float] NOT NULL DEFAULT 0.0,
	[ULO] [float] NOT NULL DEFAULT 0.0,
 CONSTRAINT [PK_Purchases] PRIMARY KEY CLUSTERED 
(
	[PurchaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
