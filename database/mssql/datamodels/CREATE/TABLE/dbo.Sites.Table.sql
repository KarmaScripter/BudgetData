USE [C:\USERS\DADDY\SOURCE\REPOS\BUDGETEXECUTION\NINJA\DATABASE\SQLSERVER\R6.MDF]
GO

/****** Object:  Table [dbo].[Sites]    Script Date: 2020-01-20 07:39:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Sites](
	[SiteId] [int] IDENTITY(1,1) NOT NULL,
	[RpioCode] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[BFY] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[FundCode] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[AhCode] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[AccountCode] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[OrgCode] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[OrgName] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[RcCode] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[ActivityCode] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[ProgramProjectCode] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[BocCode] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[FocCode] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[DCN] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[EpaSiteId] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[SiteName] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[SiteProjectCode] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[SiteProjectName] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[City] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[District] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[County] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[StateCode] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[StateName] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[StreetAddressLine1] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[StreetAddressLine2] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[ZipCode] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[OriginalActionDate] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[LastActionDate] [nvarchar](max) NOT NULL DEFAULT 'NS',
	[Commitments] [float] NOT NULL DEFAULT 0.0,
	[OpenCommitments] [float] NOT NULL DEFAULT 0.0,
	[Obligations] [float] NOT NULL DEFAULT 0.0,
	[ULO] [float] NOT NULL DEFAULT 0.0,
	[Deobligations] [float] NOT NULL DEFAULT 0.0,
	[Expenditures] [float] NOT NULL DEFAULT 0.0,
 CONSTRAINT [PK_Sites] PRIMARY KEY CLUSTERED 
(
	[SiteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


