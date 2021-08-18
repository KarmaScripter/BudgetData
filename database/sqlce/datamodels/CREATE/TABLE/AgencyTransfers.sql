
CREATE TABLE [AgencyTransfers](
	[AgencyTransferId] [int] NOT NULL,
	[ReprogrammingNumber] [nvarchar](255) NULL,
	[ProcessedDate] [datetime] NULL,
	[RPIO] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[Amount] [money] NULL,
	[FundName] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[FromTo] [nvarchar](255) NULL,
	[SPIO] [nvarchar](255) NULL,
	[Purpose] [nvarchar](255) NULL,
	[ExtendedPurpose] [nvarchar](255) NULL
);