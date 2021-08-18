CREATE TABLE [LandChemicalAndRevitalizationObligations]
(
	[LandChemicalAndRevitalizationObligationId] [int] NOT NULL,
	[PurchaseId] [int] NOT NULL,
	[RpioCode] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[AhName] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ActivityCode] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[NpmCode] [nvarchar](255) NULL,
	[NpmName] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
	[DocumentControlNumbers] [nvarchar](255) NULL,
	[ReimbursableAgreementNumber] [nvarchar](255) NULL,
	[SiteProjectCode] [nvarchar](255) NULL,
	[DcnPrefix] [nvarchar](255) NULL,
	[DocType] [nvarchar](255) NULL,
	[FocCode] [nvarchar](255) NULL,
	[FocName] [nvarchar](255) NULL,
	[OriginalActionDate] [datetime] NULL,
	[Commitments] [float] NULL,
	[OpenCommitments] [float] NULL,
	[Obligations] [float] NULL,
	[Deobligations] [float] NULL,
	[ULO] [float] NULL,
	[Expenditures] [float] NULL,
	[Used] [float] NULL
);
