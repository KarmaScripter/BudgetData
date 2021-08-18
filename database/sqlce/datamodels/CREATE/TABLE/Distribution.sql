CREATE TABLE [Distribution](
	[DistributionId] [int] NOT NULL IDENTITY (1,1),
	[PrcId] [float] NULL,
	[BFY] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[AllocationRatio] [float] NULL,
	[Amount] [float] NULL
);

