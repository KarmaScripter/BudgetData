CREATE TABLE [ProgrammaticReservePriorYearUtilization](
	[ProgrammaticReservePriorYearUtilizationId] [int] NOT NULL UNIQUE IDENTITY(1,1),
	[OrgCode] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[CurrentYear] [money] NULL,
	[Reduction] [money] NULL,
	[Budget] [money] NULL,
	[PriorYear] [money] NULL,
	[OpenCommitments] [money] NULL,
	[ULO] [money] NULL
);

