CREATE TABLE [Deobligations](
	[DeobligationId] [int] NOT NULL IDENTITY(1,1),
	[RPIO] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[DocumentNumber] [nvarchar](255) NULL,
	[CalendarYear] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[Date] [datetime] NULL,
	[Amount] [float] NULL
);