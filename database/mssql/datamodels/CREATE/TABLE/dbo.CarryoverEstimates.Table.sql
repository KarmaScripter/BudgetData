USE [DataModels]
GO

/****** Object:  Table [dbo].[CarryoverEstimates]    Script Date: 7/26/2021 6:52:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CarryoverEstimates](
	[CarryoverEstimateId] [int] NOT NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[Amount] [float] NULL,
	[OpenCommitments] [float] NULL,
	[Estimate] [float] NULL,
 CONSTRAINT [PK_CarryoverEstimates] PRIMARY KEY CLUSTERED 
(
	[CarryoverEstimateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




