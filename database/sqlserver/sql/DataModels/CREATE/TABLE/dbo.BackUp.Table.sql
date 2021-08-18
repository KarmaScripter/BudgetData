USE [DataModels]
GO
/****** Object:  Table [dbo].[BackUp]    Script Date: 7/17/2021 9:04:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BackUp](
	[BackupAllocationId] [int] NOT NULL,
	[PrcId] [float] NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[RPIO] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[Amount] [float] NULL,
	[AllocationRatio] [float] NULL,
	[FundName] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[Division] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[ActivityCode] [nvarchar](255) NULL,
	[NpmName] [nvarchar](255) NULL,
	[NpmCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
	[GoalCode] [nvarchar](255) NULL,
	[GoalName] [nvarchar](255) NULL,
	[ObjectiveCode] [nvarchar](255) NULL,
	[ObjectiveName] [nvarchar](255) NULL,
	[ChangeDate] [datetime] NULL,
 CONSTRAINT [PK_BackUp] PRIMARY KEY CLUSTERED 
(
	[BackupAllocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
