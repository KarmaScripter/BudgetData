USE [References]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[AccountCodeId] [int] NOT NULL,
	[Code] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
	[GoalCode] [nvarchar](max) NULL,
	[ObjectiveCode] [nvarchar](max) NULL,
	[NpmCode] [nvarchar](max) NULL,
 CONSTRAINT [PrimaryKeyAccounts] PRIMARY KEY CLUSTERED 
(
	[AccountCodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Activity]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activity](
	[ActivityId] [float] NOT NULL,
	[Code] [nvarchar](255) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Title] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyActivity] PRIMARY KEY CLUSTERED 
(
	[ActivityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AllowanceHolders]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllowanceHolders](
	[AllowanceHolderId] [int] NOT NULL,
	[Code] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyAllowanceHolders] PRIMARY KEY CLUSTERED 
(
	[AllowanceHolderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appropriations]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appropriations](
	[AppropriationId] [int] NOT NULL,
	[BFY] [nvarchar](255) NOT NULL,
	[Title] [nvarchar](255) NULL,
	[PublicLaw] [nvarchar](255) NULL,
	[EnactedDate] [datetime] NULL,
 CONSTRAINT [PrimaryKeyAppropriations] PRIMARY KEY CLUSTERED 
(
	[AppropriationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BudgetObjectClasses]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudgetObjectClasses](
	[BudgetObjectClassId] [int] NOT NULL,
	[Code] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyBudgetObjectClasses] PRIMARY KEY CLUSTERED 
(
	[BudgetObjectClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CPIC]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CPIC](
	[CpicId] [int] NOT NULL,
	[Code] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyCPIC] PRIMARY KEY CLUSTERED 
(
	[CpicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Divisions]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Divisions](
	[DivisionId] [float] NOT NULL,
	[Code] [nvarchar](255) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Caption] [nvarchar](255) NULL,
	[Title] [nvarchar](255) NULL,
	[FCO] [nvarchar](255) NULL,
	[Icon] [nvarchar](max) NULL,
	[Logo] [nvarchar](max) NULL,
 CONSTRAINT [PrimaryKeyDivisions] PRIMARY KEY CLUSTERED 
(
	[DivisionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documents](
	[DocumentId] [float] NOT NULL,
	[Code] [nvarchar](255) NULL,
	[Category] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
	[System] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyDocuments] PRIMARY KEY CLUSTERED 
(
	[DocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FinanceObjectClasses]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FinanceObjectClasses](
	[FinanceObjectClassId] [int] NOT NULL,
	[Code] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyFinanceObjectClasses] PRIMARY KEY CLUSTERED 
(
	[FinanceObjectClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FiscalYears]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FiscalYears](
	[FiscalYearId] [int] NOT NULL,
	[BFY] [nvarchar](255) NOT NULL,
	[EFY] [nvarchar](255) NULL,
	[FirstYear] [nvarchar](255) NULL,
	[LastYear] [nvarchar](255) NULL,
	[ExpiringYear] [nvarchar](255) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Availability] [nvarchar](255) NULL,
	[Columbus] [datetime] NULL,
	[Thanksgiving] [datetime] NULL,
	[Christmas] [datetime] NULL,
	[NewYears] [datetime] NULL,
	[MartinLutherKing] [datetime] NULL,
	[Presidents] [datetime] NULL,
	[Memorial] [datetime] NULL,
	[Veterans] [datetime] NULL,
	[Labor] [datetime] NULL,
	[WorkDays] [float] NULL,
	[WeekDays] [float] NULL,
	[WeekEnds] [float] NULL,
 CONSTRAINT [PrimaryKeyFiscalYears] PRIMARY KEY CLUSTERED 
(
	[FiscalYearId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Funds]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funds](
	[FundId] [int] NOT NULL,
	[Code] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
	[Title] [nvarchar](255) NULL,
	[TreasurySymbol] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyFunds] PRIMARY KEY CLUSTERED 
(
	[FundId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Goals]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Goals](
	[GoalId] [int] NOT NULL,
	[Code] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
	[Title] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyGoals] PRIMARY KEY CLUSTERED 
(
	[GoalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GsPayScale]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GsPayScale](
	[GsPayScaleId] [int] NOT NULL,
	[LOCNAME] [nvarchar](255) NULL,
	[GRADE] [float] NULL,
	[ANNUAL1] [float] NULL,
	[HOURLY1] [nvarchar](255) NULL,
	[OVERTIME1] [nvarchar](255) NULL,
	[ANNUAL2] [float] NULL,
	[HOURLY2] [nvarchar](255) NULL,
	[OVERTIME2] [nvarchar](255) NULL,
	[ANNUAL3] [float] NULL,
	[HOURLY3] [nvarchar](255) NULL,
	[OVERTIME3] [nvarchar](255) NULL,
	[ANNUAL4] [float] NULL,
	[HOURLY4] [nvarchar](255) NULL,
	[OVERTIME4] [nvarchar](255) NULL,
	[ANNUAL5] [float] NULL,
	[HOURLY5] [nvarchar](255) NULL,
	[OVERTIME5] [nvarchar](255) NULL,
	[ANNUAL6] [float] NULL,
	[HOURLY6] [nvarchar](255) NULL,
	[OVERTIME6] [nvarchar](255) NULL,
	[ANNUAL7] [float] NULL,
	[HOURLY7] [nvarchar](255) NULL,
	[OVERTIME7] [nvarchar](255) NULL,
	[ANNUAL8] [float] NULL,
	[HOURLY8] [nvarchar](255) NULL,
	[OVERTIME8] [nvarchar](255) NULL,
	[ANNUAL9] [float] NULL,
	[HOURLY9] [nvarchar](255) NULL,
	[OVERTIME9] [nvarchar](255) NULL,
	[ANNUAL10] [float] NULL,
	[HOURLY10] [nvarchar](255) NULL,
	[OVERTIME10] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyGsPayScale] PRIMARY KEY CLUSTERED 
(
	[GsPayScaleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Holidays]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Holidays](
	[HolidayId] [int] NOT NULL,
	[ColumbusDay] [datetime] NULL,
	[ThanksgivingDay] [datetime] NULL,
	[ChristmasDay] [datetime] NULL,
	[NewYearsDay] [datetime] NULL,
	[MartinLutherKingDay] [datetime] NULL,
	[PresidentsDay] [datetime] NULL,
	[MemorialDay] [datetime] NULL,
	[VeteransDay] [datetime] NULL,
	[LaborDay] [datetime] NULL,
 CONSTRAINT [PrimaryKeyHolidays] PRIMARY KEY CLUSTERED 
(
	[HolidayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageId] [int] NOT NULL,
	[Message] [nvarchar](255) NULL,
	[Type] [nvarchar](255) NULL,
	[Form] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyMessages] PRIMARY KEY CLUSTERED 
(
	[MessageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NationalPrograms]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NationalPrograms](
	[NationalProgramId] [float] NOT NULL,
	[Code] [nvarchar](255) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[RpioCode] [nvarchar](255) NULL,
	[Title] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyNationalPrograms] PRIMARY KEY CLUSTERED 
(
	[NationalProgramId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Objectives]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Objectives](
	[ObjectiveId] [float] NOT NULL,
	[Code] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
	[Title] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyObjectives] PRIMARY KEY CLUSTERED 
(
	[ObjectiveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperatingPlan]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperatingPlan](
	[OppId] [int] NOT NULL,
	[RPIO] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[Amount] [float] NULL,
	[NpmCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[NpmName] [nvarchar](255) NULL,
	[AhName] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[OrgName] [nvarchar](255) NULL,
	[ActivityCode] [nvarchar](255) NULL,
	[ActivityName] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
	[GoalCode] [nvarchar](255) NULL,
	[GoalName] [nvarchar](255) NULL,
	[ObjectiveCode] [nvarchar](255) NULL,
	[ObjectiveName] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyOperatingPlan] PRIMARY KEY CLUSTERED 
(
	[OppId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organizations]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organizations](
	[OrganizationId] [int] NOT NULL,
	[Code] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyOrganizations] PRIMARY KEY CLUSTERED 
(
	[OrganizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgramAreas]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramAreas](
	[ProgramAreaId] [int] NOT NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyProgramAreas] PRIMARY KEY CLUSTERED 
(
	[ProgramAreaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgramDescriptions]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramDescriptions](
	[ProgramProjectId] [int] NOT NULL,
	[ProgramProjectCode] [nvarchar](255) NOT NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[ProgramProjectTitle] [nvarchar](255) NULL,
	[Laws] [nvarchar](max) NULL,
	[Narrative] [nvarchar](max) NULL,
	[Definition] [nvarchar](max) NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyProgramDescriptions] PRIMARY KEY CLUSTERED 
(
	[ProgramProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgramProjects]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgramProjects](
	[ProgramProjectId] [int] NOT NULL,
	[Code] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyProgramProjects] PRIMARY KEY CLUSTERED 
(
	[ProgramProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectId] [int] NOT NULL,
	[Code] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyProjects] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReferenceTables]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReferenceTables](
	[ReferenceTableId] [int] NOT NULL,
	[TableName] [nvarchar](255) NULL,
	[Type] [nvarchar](max) NULL,
 CONSTRAINT [PrimaryKeyReferenceTables] PRIMARY KEY CLUSTERED 
(
	[ReferenceTableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResourcePlanningOffices]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResourcePlanningOffices](
	[RpioId] [int] NOT NULL,
	[Code] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyResourcePlanningOffices] PRIMARY KEY CLUSTERED 
(
	[RpioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResponsibilityCenters]    Script Date: 8/20/2021 6:36:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResponsibilityCenters](
	[ResponsibilityCenterId] [int] NOT NULL,
	[Code] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
	[Title] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyResponsibilityCenters] PRIMARY KEY CLUSTERED 
(
	[ResponsibilityCenterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
