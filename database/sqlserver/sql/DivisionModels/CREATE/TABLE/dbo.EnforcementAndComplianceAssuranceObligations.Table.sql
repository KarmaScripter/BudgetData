USE [DivisionModels]
GO
/****** Object:  Table [dbo].[EnforcementAndComplianceAssuranceObligations]    Script Date: 7/17/2021 9:05:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnforcementAndComplianceAssuranceObligations](
	[EnforcementAndComplianceAssuranceObligationId] [uniqueidentifier] NOT NULL,
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
	[LastActionDate] [datetime] NULL,
	[Commitments] [float] NOT NULL,
	[OpenCommitments] [float] NOT NULL,
	[Obligations] [float] NOT NULL,
	[Deobligations] [float] NOT NULL,
	[ULO] [float] NOT NULL,
	[Expenditures] [float] NOT NULL,
	[Used] [float] NOT NULL,
 CONSTRAINT [PK_EnforcementAndComplianceAssuranceObligations] PRIMARY KEY CLUSTERED 
(
	[EnforcementAndComplianceAssuranceObligationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
