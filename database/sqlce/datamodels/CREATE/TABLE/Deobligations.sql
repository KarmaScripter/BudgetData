CREATE TABLE [Deobligations]
(
	[DeobligationsId] INT NOT NULL IDENTITY (1,1),
	[RPIO] NVARCHAR(255) NULL,
	[BFY] NVARCHAR(255) NULL,
	[FundCode] NVARCHAR(255) NULL,
	[DocumentNumber] NVARCHAR(255) NULL,
	[CalendarYear] NVARCHAR(255) NULL,
	[OrgCode] NVARCHAR(255) NULL,
	[ProgramProjectCode] NVARCHAR(255) NULL,
	[AccountCode] NVARCHAR(255) NULL,
	[BocCode] NVARCHAR(255) NULL,
	[Date] DATETIME NULL,
	[Amount] [float] NULL,
    CONSTRAINT PK_Deobligations
    PRIMARY KEY (DeobligationsId) 
);