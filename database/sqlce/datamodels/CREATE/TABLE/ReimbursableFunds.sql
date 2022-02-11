CREATE TABLE [ReimbursableFunds]
(
	[ReimbursableFundsId] [int] NOT NULL IDENTITY(1,1),
	[RpioCode] NVARCHAR(255) NULL,
	[RpioName] NVARCHAR(255) NULL,
	[BFY] NVARCHAR(255) NULL,
	[FundCode] NVARCHAR(255) NULL,
	[AccountCode] NVARCHAR(255) NULL,
	[RcCode] NVARCHAR(255) NULL,
	[DivisionName] NVARCHAR(255) NULL,
	[BocCode] NVARCHAR(255) NULL,
	[DocumentControlNumber] NVARCHAR(255) NULL,
	[AgreeementNumber] NVARCHAR(255) NULL,
	[Amount] [money] NULL,
	[OpenCommitments] [money] NULL,
	[Obligations] [money] NULL,
	[ULO] [money] NULL,
	[Available] [money] NULL,
		CONSTRAINT PK_ReimbursableFunds 
		PRIMARY KEY (ReimbursableFundsId)
);

