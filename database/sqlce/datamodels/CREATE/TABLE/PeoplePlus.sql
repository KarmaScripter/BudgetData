CREATE TABLE [PeoplePlus](
	[PeoplePlusId] [int] NOT NULL UNIQUE IDENTITY(1,1),
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[EpaNumber] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[FirstName] [nvarchar](255) NULL,
	[ReportingCode] [nvarchar](255) NULL,
	[ReportingCodeName] [nvarchar](255) NULL,
	[WorkCode] [nvarchar](255) NULL,
	[Hours] [float] NULL
);

