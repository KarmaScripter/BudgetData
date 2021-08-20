USE [Data]
GO
/****** Object:  Table [dbo].[AgencyTransfers]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AgencyTransfers](
	[AgencyTransferId] [int] NOT NULL,
	[ReprogrammingNumber] [nvarchar](255) NULL,
	[ProcessedDate] [datetime] NULL,
	[Line] [nvarchar](255) NULL,
	[Subline] [nvarchar](255) NULL,
	[RPIO] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[AhName] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[OrganizationName] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[Amount] [money] NULL,
	[FromTo] [nvarchar](255) NULL,
	[SPIO] [nvarchar](255) NULL,
	[Purpose] [nvarchar](max) NULL,
	[ExtendedPurpose] [nvarchar](max) NULL,
	[DocType] [nvarchar](255) NULL,
	[DocPrefix] [nvarchar](255) NULL,
	[NpmCode] [nvarchar](255) NULL,
	[ResourceType] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyAgencyTransfers] PRIMARY KEY CLUSTERED 
(
	[AgencyTransferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Allocations]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Allocations](
	[PrcId] [int] NOT NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[RPIO] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[Amount] [float] NOT NULL,
	[FundName] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[Division] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[ActivityCode] [nvarchar](255) NULL,
	[NpmName] [nvarchar](255) NULL,
	[NpmCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
	[GoalCode] [nvarchar](255) NULL,
	[GoalName] [nvarchar](255) NULL,
	[ObjectiveCode] [nvarchar](255) NULL,
	[ObjectiveName] [nvarchar](255) NULL,
	[AllocationRatio] [float] NULL,
	[ChangeDate] [datetime] NULL,
 CONSTRAINT [PrimaryKeyAllocations] PRIMARY KEY CLUSTERED 
(
	[PrcId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationTables]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationTables](
	[ApplicationTableId] [int] NOT NULL,
	[TableName] [nvarchar](255) NULL,
	[Model] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyApplicationTables] PRIMARY KEY CLUSTERED 
(
	[ApplicationTableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BackUp]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BackUp](
	[BackupAllocationId] [int] NOT NULL,
	[PrcId] [float] NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[RPIO] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[Amount] [float] NULL,
	[AllocationRatio] [float] NULL,
	[FundName] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[Division] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[ActivityCode] [nvarchar](255) NULL,
	[NpmName] [nvarchar](255) NULL,
	[NpmCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
	[GoalCode] [nvarchar](255) NULL,
	[GoalName] [nvarchar](255) NULL,
	[ObjectiveCode] [nvarchar](255) NULL,
	[ObjectiveName] [nvarchar](255) NULL,
	[ChangeDate] [datetime] NULL,
 CONSTRAINT [PrimaryKeyBackUp] PRIMARY KEY CLUSTERED 
(
	[BackupAllocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BenefitCharges]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BenefitCharges](
	[EmployeeBenefitsId] [int] NOT NULL,
	[PeoplePlusId] [int] NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[EpaNumber] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[FirstName] [nvarchar](255) NULL,
	[ReportingCode] [nvarchar](255) NULL,
	[ReportingCodeName] [nvarchar](255) NULL,
	[HrOrgCode] [nvarchar](255) NULL,
	[WorkCode] [nvarchar](255) NULL,
	[PayPeriod] [nvarchar](255) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Hours] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BudgetParameters]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudgetParameters](
	[BudgetParameterId] [int] NOT NULL,
	[AhCode] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyBudgetParameters] PRIMARY KEY CLUSTERED 
(
	[BudgetParameterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarryoverEstimates]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarryoverEstimates](
	[CarryoverEstimateId] [int] NOT NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[Amount] [float] NULL,
	[OpenCommitments] [float] NULL,
	[Estimate] [float] NULL,
 CONSTRAINT [PrimaryKeyCarryoverEstimates] PRIMARY KEY CLUSTERED 
(
	[CarryoverEstimateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarryoverSurvey]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarryoverSurvey](
	[CarryoverSurveyId] [int] NOT NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[Amount] [float] NULL,
 CONSTRAINT [PrimaryKeyCarryoverSurvey] PRIMARY KEY CLUSTERED 
(
	[CarryoverSurveyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Changes]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Changes](
	[ID] [int] NOT NULL,
	[TableName] [nvarchar](255) NULL,
	[FieldName] [nvarchar](255) NULL,
	[Action] [nvarchar](255) NULL,
	[OldValue] [nvarchar](255) NULL,
	[NewValue] [nvarchar](255) NULL,
	[TimeStamp] [datetime] NULL,
	[Message] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyChanges] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CongressionalTransfers]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongressionalTransfers](
	[CongressionalTransferId] [int] NOT NULL,
	[ReprogrammingNumber] [nvarchar](255) NULL,
	[ProcessedDate] [datetime] NULL,
	[Line] [nvarchar](255) NULL,
	[Subline] [nvarchar](255) NULL,
	[RPIO] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[AhName] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[OrganizationName] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[Amount] [float] NULL,
	[SPIO] [nvarchar](255) NULL,
	[Purpose] [nvarchar](max) NULL,
	[ExtendedPurpose] [nvarchar](max) NULL,
	[FromTo] [nvarchar](255) NULL,
	[DocType] [nvarchar](255) NULL,
	[DocPrefix] [nvarchar](255) NULL,
	[NpmCode] [nvarchar](255) NULL,
	[ResourceType] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyCongressionalTransfers] PRIMARY KEY CLUSTERED 
(
	[CongressionalTransferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ControlNumbers]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ControlNumbers](
	[ControlNumberId] [int] NOT NULL,
	[RPIO] [nvarchar](255) NULL,
	[RegionNumber] [float] NULL,
	[BFY] [nvarchar](255) NULL,
	[CalendarYear] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundNumber] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[DivisionNumber] [float] NULL,
	[DateIssued] [datetime] NULL,
	[Purpose] [nvarchar](max) NULL,
 CONSTRAINT [PrimaryKeyControlNumbers] PRIMARY KEY CLUSTERED 
(
	[ControlNumberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Deobligations]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deobligations](
	[DeobligationId] [int] NOT NULL,
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
	[Amount] [float] NULL,
 CONSTRAINT [PrimaryKeyDeobligations] PRIMARY KEY CLUSTERED 
(
	[DeobligationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Distribution]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distribution](
	[DistributionId] [int] NOT NULL,
	[PrcId] [float] NULL,
	[BFY] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[AllocationRatio] [float] NULL,
	[Amount] [float] NULL,
 CONSTRAINT [PrimaryKeyDistribution] PRIMARY KEY CLUSTERED 
(
	[DistributionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DivisionAuthority]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DivisionAuthority](
	[DivisionAuthorityId] [int] NOT NULL,
	[RescissionId] [int] NOT NULL,
	[PrcId] [int] NOT NULL,
	[RPIO] [nvarchar](255) NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ActivityCode] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[Allocation] [float] NULL,
	[Reduction] [float] NULL,
	[Amount] [float] NULL,
	[FundName] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[Division] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[NpmCode] [nvarchar](255) NULL,
	[NpmName] [nvarchar](255) NULL,
	[GoalCode] [nvarchar](255) NULL,
	[GoalName] [nvarchar](255) NULL,
	[ObjectiveCode] [nvarchar](255) NULL,
	[ObjectiveName] [nvarchar](255) NULL,
	[AllocationRatio] [float] NULL,
	[ChangeDate] [datetime] NULL,
 CONSTRAINT [PrimaryKeyDivisionAuthority] PRIMARY KEY CLUSTERED 
(
	[DivisionAuthorityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DivisionBudgets]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DivisionBudgets](
	[BudgetId] [int] NOT NULL,
	[BFY] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DivisionExecution]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DivisionExecution](
	[DivisionExecutionId] [int] NOT NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[RPIO] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ActivityCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[SiteProjectCode] [nvarchar](255) NULL,
	[Amount] [float] NULL,
	[OpenCommitments] [float] NULL,
	[CommitmentRatio] [float] NULL,
	[Obligations] [float] NULL,
	[ObligationRatio] [float] NULL,
	[Used] [float] NULL,
	[Utilization] [float] NULL,
	[Available] [money] NULL,
	[Availability] [float] NULL,
 CONSTRAINT [PrimaryKeyDivisionExecution] PRIMARY KEY CLUSTERED 
(
	[DivisionExecutionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DivisionPersonnel]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DivisionPersonnel](
	[PersonnelId] [int] NOT NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[EmployeeId] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[FirstName] [nvarchar](255) NULL,
	[JobTitle] [nvarchar](255) NULL,
	[Grade] [nvarchar](255) NULL,
	[Step] [nvarchar](255) NULL,
	[HireDate] [datetime] NULL,
	[LastIncrease] [datetime] NULL,
	[GradeEntry] [datetime] NULL,
	[StepEntry] [datetime] NULL,
	[WigiDueDate] [datetime] NULL,
	[Tenure] [float] NULL,
	[HrOrgName] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[PhoneNumber] [nvarchar](255) NULL,
	[Office] [nvarchar](255) NULL,
	[MailCode] [nvarchar](255) NULL,
	[SupervisorId] [nvarchar](255) NULL,
	[SupervisorFirstName] [nvarchar](255) NULL,
	[SupervisorLastName] [nvarchar](255) NULL,
	[Supervisor] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyDivisionPersonnel] PRIMARY KEY CLUSTERED 
(
	[PersonnelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DivisionTraining]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DivisionTraining](
	[DivisionTrainingId] [int] NOT NULL,
	[PrcId] [float] NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[RPIO] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[Amount] [decimal](18, 0) NULL,
	[FundName] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[Division] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[ActivityCode] [nvarchar](255) NULL,
	[NpmName] [nvarchar](255) NULL,
	[NpmCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
	[GoalCode] [nvarchar](255) NULL,
	[GoalName] [nvarchar](255) NULL,
	[ObjectiveCode] [nvarchar](255) NULL,
	[ObjectiveName] [nvarchar](255) NULL,
	[AllocationRatio] [float] NULL,
	[ChangeDate] [datetime] NULL,
 CONSTRAINT [PrimaryKeyDivisionTraining] PRIMARY KEY CLUSTERED 
(
	[DivisionTrainingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DivisionTravel]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DivisionTravel](
	[PrcId] [int] NOT NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[RPIO] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[Amount] [float] NULL,
	[FundName] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[Division] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[ActivityCode] [nvarchar](255) NULL,
	[NpmName] [nvarchar](255) NULL,
	[NpmCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
	[GoalCode] [nvarchar](255) NULL,
	[GoalName] [nvarchar](255) NULL,
	[ObjectiveCode] [nvarchar](255) NULL,
	[ObjectiveName] [nvarchar](255) NULL,
	[AllocationRatio] [float] NULL,
	[ChangeDate] [datetime] NULL,
 CONSTRAINT [PrimaryKeyDivisionTravel] PRIMARY KEY CLUSTERED 
(
	[PrcId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentControlNumbers]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentControlNumbers](
	[DocumentControlNumberId] [int] NOT NULL,
	[RcCode] [nvarchar](255) NULL,
	[DocumentControlNumber] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyDocumentControlNumbers] PRIMARY KEY CLUSTERED 
(
	[DocumentControlNumberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeData]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeData](
	[EmployeeDataId] [int] NOT NULL,
	[RpioCode] [nvarchar](255) NULL,
	[RpioName] [nvarchar](255) NULL,
	[ActionDate] [datetime] NULL,
	[HiringAuthority] [nvarchar](255) NULL,
	[SupervisorId] [nvarchar](255) NULL,
	[JobTitle] [nvarchar](255) NULL,
	[HrOrgCode] [nvarchar](255) NULL,
	[HrOrgName] [nvarchar](255) NULL,
	[EmployeeId] [nvarchar](255) NULL,
	[FirstName] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[RetirementPlan] [nvarchar](255) NULL,
	[ScheduledRetirementDate] [datetime] NULL,
	[HireDate] [datetime] NULL,
	[Grade] [nvarchar](255) NULL,
	[Step] [nvarchar](255) NULL,
	[GradeEntry] [datetime] NULL,
	[LastIncrease] [datetime] NULL,
	[StepEntry] [datetime] NULL,
	[WigiDue] [datetime] NULL,
	[EmployeeStatus] [nvarchar](255) NULL,
	[HoursEarnedYearToDate] [float] NULL,
	[CarryoverHours] [float] NULL,
	[HoursAdjustedYearToDate] [float] NULL,
	[HoursBalance] [float] NULL,
	[ProjectedAnnualHours] [float] NULL,
	[ProjectedNextPeriodHours] [float] NULL,
	[HoursTakenYearToDate] [float] NULL,
 CONSTRAINT [PrimaryKeyEmployeeData] PRIMARY KEY CLUSTERED 
(
	[EmployeeDataId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeLeave]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeLeave](
	[EmployeeLeaveId] [int] NOT NULL,
	[RcCode] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[FirstName] [nvarchar](255) NULL,
	[EpaNumber] [nvarchar](255) NULL,
	[HoursEarnedYearToDate] [float] NULL,
	[CarryoverHours] [float] NULL,
	[HoursAdjustedYearToDate] [float] NULL,
	[HoursBalance] [float] NULL,
	[ProjectedAnnualHours] [float] NULL,
	[ProjectedNextPeriodHours] [float] NULL,
	[HoursTakenYearToDate] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[PersonnelId] [int] NOT NULL,
	[RcCode] [nvarchar](255) NULL,
	[EpaNumber] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[FirstName] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyEmployees] PRIMARY KEY CLUSTERED 
(
	[PersonnelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExecutionTables]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExecutionTables](
	[ExecutionTableId] [int] NOT NULL,
	[TableName] [nvarchar](255) NULL,
	[Type] [nvarchar](max) NULL,
 CONSTRAINT [PrimaryKeyExecutionTables] PRIMARY KEY CLUSTERED 
(
	[ExecutionTableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExternalUpdates]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExternalUpdates](
	[ExternalUpdateId] [int] NOT NULL,
	[ExtId] [float] NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ActivityCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[Amount] [float] NULL,
 CONSTRAINT [PrimaryKeyExternalUpdates] PRIMARY KEY CLUSTERED 
(
	[ExternalUpdateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FullTimeEquivalents]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FullTimeEquivalents](
	[FullTimeEquivalentId] [int] NOT NULL,
	[PrcId] [int] NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[RPIO] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[Amount] [float] NULL,
	[FundName] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[Division] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[ActivityCode] [nvarchar](255) NULL,
	[NpmName] [nvarchar](255) NULL,
	[NpmCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
	[GoalCode] [nvarchar](255) NULL,
	[GoalName] [nvarchar](255) NULL,
	[ObjectiveCode] [nvarchar](255) NULL,
	[ObjectiveName] [nvarchar](255) NULL,
	[AllocationRatio] [float] NULL,
	[ChangeDate] [datetime] NULL,
 CONSTRAINT [PrimaryKeyFullTimeEquivalents] PRIMARY KEY CLUSTERED 
(
	[FullTimeEquivalentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HumanResourceOrganizations]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HumanResourceOrganizations](
	[HumanResourceOrganizationId] [int] NOT NULL,
	[Code] [nvarchar](255) NULL,
	[Name] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyHumanResourceOrganizations] PRIMARY KEY CLUSTERED 
(
	[HumanResourceOrganizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[ID] [int] NOT NULL,
	[FileName] [nvarchar](255) NULL,
	[FilePath] [nvarchar](255) NULL,
	[FileExtension] [nvarchar](255) NULL,
	[ImageFile] [image] NULL,
	[Attachments] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocatorData]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocatorData](
	[LocatorId] [int] NOT NULL,
	[LastName] [nvarchar](255) NULL,
	[FirstName] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[PhoneNumber] [nvarchar](255) NULL,
	[MailCode] [nvarchar](255) NULL,
	[Office] [nvarchar](255) NULL,
	[CellNumber] [nvarchar](255) NULL,
	[Status] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyLocatorData] PRIMARY KEY CLUSTERED 
(
	[LocatorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LowerReconcilliation]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LowerReconcilliation](
	[ReconcilliationId] [int] NOT NULL,
	[ExtId] [float] NULL,
	[PrcId] [int] NULL,
	[BFY] [nvarchar](255) NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[System] [money] NULL,
	[Budget] [money] NULL,
	[Delta] [money] NULL,
	[NET] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyLowerReconcilliation] PRIMARY KEY CLUSTERED 
(
	[ReconcilliationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperatingPlanUpdates]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperatingPlanUpdates](
	[OppUpdateId] [int] NOT NULL,
	[OppId] [float] NULL,
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
	[ObjectiveName] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PayPeriods]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayPeriods](
	[PayPeriodId] [int] NOT NULL,
	[Period] [nvarchar](255) NULL,
	[PayPeriod] [nvarchar](255) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
 CONSTRAINT [PrimaryKeyPayPeriods] PRIMARY KEY CLUSTERED 
(
	[PayPeriodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payroll]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payroll](
	[PayrollId] [int] NOT NULL,
	[PrcId] [int] NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[RPIO] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[Amount] [float] NULL,
	[FundName] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[Division] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[ActivityCode] [nvarchar](255) NULL,
	[NpmName] [nvarchar](255) NULL,
	[NpmCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
	[GoalCode] [nvarchar](255) NULL,
	[GoalName] [nvarchar](255) NULL,
	[ObjectiveCode] [nvarchar](255) NULL,
	[ObjectiveName] [nvarchar](255) NULL,
	[AllocationRatio] [float] NULL,
	[ChangeDate] [datetime] NULL,
 CONSTRAINT [PrimaryKeyPayroll] PRIMARY KEY CLUSTERED 
(
	[PayrollId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PayrollAccruals]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayrollAccruals](
	[PayrollAccrualId] [int] NOT NULL,
	[RPIO] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[EpaNumber] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[FirstName] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
	[WorkCode] [nvarchar](255) NULL,
	[HrOrgCode] [nvarchar](255) NULL,
	[PayPeriod] [nvarchar](255) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Amount] [float] NULL,
	[Hours] [float] NULL,
	[Benefits] [float] NULL,
	[OvertimePaid] [float] NULL,
	[OvertimeHours] [float] NULL,
 CONSTRAINT [PrimaryKeyPayrollAccruals] PRIMARY KEY CLUSTERED 
(
	[PayrollAccrualId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PayrollCostCodes]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayrollCostCodes](
	[PayrollCostCodeId] [int] NOT NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[HrOrgCode] [nvarchar](255) NULL,
	[HrOrgName] [nvarchar](255) NULL,
	[WorkCode] [nvarchar](255) NULL,
	[WorkCodeName] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyPayrollCostCodes] PRIMARY KEY CLUSTERED 
(
	[PayrollCostCodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PayrollHours]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayrollHours](
	[PayrollHoursId] [int] NOT NULL,
	[RpioCode] [nvarchar](255) NULL,
	[PayPeriod] [nvarchar](255) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[EpaNumber] [nvarchar](255) NULL,
	[FirstName] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[HrOrgCode] [nvarchar](255) NULL,
	[HrOrgName] [nvarchar](255) NULL,
	[ReportingCode] [nvarchar](255) NULL,
	[ReportingCodeName] [nvarchar](255) NULL,
	[WorkCode] [nvarchar](255) NULL,
	[Hours] [float] NULL,
 CONSTRAINT [PrimaryKeyPayrollHours] PRIMARY KEY CLUSTERED 
(
	[PayrollHoursId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PayrollObligations]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayrollObligations](
	[PayrollObligationId] [int] NOT NULL,
	[RPIO] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[FocCode] [nvarchar](255) NULL,
	[FocName] [nvarchar](255) NULL,
	[WorkCode] [nvarchar](255) NULL,
	[WorkCodeName] [nvarchar](255) NULL,
	[HrOrgCode] [nvarchar](255) NULL,
	[PayPeriod] [nvarchar](255) NULL,
	[Amount] [float] NULL,
	[Hours] [float] NULL,
	[CumulativeBenefits] [float] NULL,
	[AnnualBase] [float] NULL,
	[AnnualHours] [float] NULL,
	[AnnualOvertimePaid] [float] NULL,
	[AnnualOvertimeHours] [float] NULL,
	[AnnualOtherPaid] [float] NULL,
	[AnnualOtherHours] [float] NULL,
 CONSTRAINT [PrimaryKeyPayrollObligations] PRIMARY KEY CLUSTERED 
(
	[PayrollObligationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PeoplePlus]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeoplePlus](
	[PeoplePlusId] [int] NOT NULL,
	[RcCode] [nvarchar](255) NULL,
	[EpaNumber] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[FirstName] [nvarchar](255) NULL,
	[ReportingCode] [nvarchar](255) NULL,
	[ReportingCodeName] [nvarchar](255) NULL,
	[HrOrgCode] [nvarchar](255) NULL,
	[WorkCode] [nvarchar](255) NULL,
	[PayPeriod] [nvarchar](255) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Hours] [float] NULL,
 CONSTRAINT [PrimaryKeyPeoplePlus] PRIMARY KEY CLUSTERED 
(
	[PeoplePlusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgrammaticReserve]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgrammaticReserve](
	[ProgrammaticReserveId] [int] NOT NULL,
	[PrcId] [int] NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[RPIO] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ActivityCode] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[CurrentYear] [int] NULL,
	[Reduction] [int] NULL,
	[Ratio] [float] NULL,
	[Budget] [int] NULL,
	[PriorYear] [int] NULL,
	[FundName] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[NpmCode] [nvarchar](255) NULL,
	[NpmName] [nvarchar](255) NULL,
	[Division] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[Delta] [float] NULL,
 CONSTRAINT [PrimaryKeyProgrammaticReserve] PRIMARY KEY CLUSTERED 
(
	[ProgrammaticReserveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProgrammaticReservePriorYearUtilization]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProgrammaticReservePriorYearUtilization](
	[ProgrammaticReservePriorYearUtilizationId] [int] NOT NULL,
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
	[ULO] [money] NULL,
 CONSTRAINT [PrimaryKeyProgrammaticReservePriorYearUtilization] PRIMARY KEY CLUSTERED 
(
	[ProgrammaticReservePriorYearUtilizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseRequestNumbers]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseRequestNumbers](
	[PurchaseRequestId] [int] NOT NULL,
	[RcCode] [nvarchar](255) NULL,
	[PurchaseRequest] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyPurchaseRequestNumbers] PRIMARY KEY CLUSTERED 
(
	[PurchaseRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QueryDefinitions]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QueryDefinitions](
	[QueryDefinitionId] [int] NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Type] [nvarchar](max) NULL,
 CONSTRAINT [PrimaryKeyQueryDefinitions] PRIMARY KEY CLUSTERED 
(
	[QueryDefinitionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecoveryFundTransfers]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecoveryFundTransfers](
	[RecoveryId] [int] NOT NULL,
	[ReprogrammingNumber] [nvarchar](255) NULL,
	[ProcessedDate] [datetime] NULL,
	[Line] [nvarchar](255) NULL,
	[Subline] [nvarchar](255) NULL,
	[RPIO] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[AhName] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[OrganizationName] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[Amount] [float] NULL,
	[NpmCode] [nvarchar](255) NULL,
	[Purpose] [nvarchar](max) NULL,
	[ExtendedPurpose] [nvarchar](max) NULL,
	[FromTo] [nvarchar](255) NULL,
	[DocType] [nvarchar](255) NULL,
	[DocPrefix] [nvarchar](255) NULL,
	[SPIO] [nvarchar](255) NULL,
	[ResourceType] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyRecoveryFundTransfers] PRIMARY KEY CLUSTERED 
(
	[RecoveryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegionalAuthority]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegionalAuthority](
	[RescissionId] [int] NOT NULL,
	[PrcId] [int] NULL,
	[RPIO] [nvarchar](255) NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ActivityCode] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[Allocation] [money] NULL,
	[Reduction] [money] NULL,
	[Amount] [money] NULL,
	[FundName] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[Division] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[NpmCode] [nvarchar](255) NULL,
	[NpmName] [nvarchar](255) NULL,
	[GoalCode] [nvarchar](255) NULL,
	[GoalName] [nvarchar](255) NULL,
	[ObjectiveCode] [nvarchar](255) NULL,
	[ObjectiveName] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegionalTransfers]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegionalTransfers](
	[RegionalTransferId] [int] NOT NULL,
	[ReprogrammingNumber] [nvarchar](255) NULL,
	[ProcessedDate] [datetime] NULL,
	[Line] [nvarchar](255) NULL,
	[Subline] [nvarchar](255) NULL,
	[RPIO] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[AhName] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[OrganizationName] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
	[FromTo] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[Amount] [float] NULL,
	[DocPrefix] [nvarchar](255) NULL,
	[DocType] [nvarchar](255) NULL,
	[Purpose] [nvarchar](max) NULL,
	[ExtendedPurpose] [nvarchar](max) NULL,
	[SPIO] [nvarchar](255) NULL,
	[NpmCode] [nvarchar](255) NULL,
	[ResourceType] [nvarchar](255) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegionTravel]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegionTravel](
	[RegionTravelId] [int] NOT NULL,
	[PrcId] [int] NOT NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[RPIO] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[Amount] [float] NULL,
	[FundName] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[Division] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[ActivityCode] [nvarchar](255) NULL,
	[NpmName] [nvarchar](255) NULL,
	[NpmCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
	[GoalCode] [nvarchar](255) NULL,
	[GoalName] [nvarchar](255) NULL,
	[ObjectiveCode] [nvarchar](255) NULL,
	[ObjectiveName] [nvarchar](255) NULL,
	[AllocationRatio] [float] NULL,
	[ChangeDate] [datetime] NULL,
 CONSTRAINT [PrimaryKeyRegionTravel] PRIMARY KEY CLUSTERED 
(
	[RegionTravelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReimbursableAgreements]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReimbursableAgreements](
	[ReimbursableAgreementId] [int] NOT NULL,
	[RPIO] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[AgreementNumber] [nvarchar](255) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[RcCode] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[SiteProjectCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[VendorCode] [nvarchar](255) NULL,
	[VendorName] [nvarchar](255) NULL,
	[Amount] [money] NULL,
	[OpenCommitments] [money] NULL,
	[Obligations] [money] NULL,
	[ULO] [money] NULL,
	[Available] [money] NULL,
 CONSTRAINT [PrimaryKeyReimbursableAgreements] PRIMARY KEY CLUSTERED 
(
	[ReimbursableAgreementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReimbursableFunds]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReimbursableFunds](
	[ReimbursableFundId] [int] NOT NULL,
	[RPIO] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[DocumentControlNumber] [nvarchar](255) NULL,
	[AgreeementNumber] [nvarchar](255) NULL,
	[Amount] [money] NULL,
	[OpenCommitments] [money] NULL,
	[Obligations] [money] NULL,
	[ULO] [money] NULL,
	[Available] [money] NULL,
 CONSTRAINT [PrimaryKeyReimbursableFunds] PRIMARY KEY CLUSTERED 
(
	[ReimbursableFundId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReimbursableSurvey]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReimbursableSurvey](
	[ReimbursableSurveyId] [int] NOT NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[Amount] [float] NULL,
 CONSTRAINT [PrimaryKeyReimbursableSurvey] PRIMARY KEY CLUSTERED 
(
	[ReimbursableSurveyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportingCodes]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportingCodes](
	[ReportingCodeId] [int] NOT NULL,
	[ReportingCode] [nvarchar](255) NULL,
	[ReportingCodeName] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyReportingCodes] PRIMARY KEY CLUSTERED 
(
	[ReportingCodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reprogrammings]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reprogrammings](
	[ReprogrammingId] [int] NOT NULL,
	[ReprogrammingNumber] [nvarchar](255) NULL,
	[ProcessedDate] [datetime] NULL,
	[RPIO] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[Amount] [float] NULL,
	[SPIO] [nvarchar](255) NULL,
	[Purpose] [nvarchar](max) NULL,
	[ExtendedPurpose] [nvarchar](max) NULL,
	[FromTo] [nvarchar](255) NULL,
	[DocType] [nvarchar](255) NULL,
	[DocPrefix] [nvarchar](255) NULL,
	[NpmCode] [nvarchar](255) NULL,
	[Line] [nvarchar](255) NULL,
	[Subline] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyReprogrammings] PRIMARY KEY CLUSTERED 
(
	[ReprogrammingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rescission]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rescission](
	[RescissionId] [int] NOT NULL,
	[PrcId] [int] NULL,
	[RPIO] [nvarchar](255) NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ActivityCode] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[Allocation] [int] NULL,
	[Reduction] [int] NULL,
	[Amount] [int] NULL,
	[FundName] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[Division] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[NpmCode] [nvarchar](255) NULL,
	[NpmName] [nvarchar](255) NULL,
	[GoalCode] [nvarchar](255) NULL,
	[GoalName] [nvarchar](255) NULL,
	[ObjectiveCode] [nvarchar](255) NULL,
	[ObjectiveName] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyRescission] PRIMARY KEY CLUSTERED 
(
	[RescissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SiteProjectCodes]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteProjectCodes](
	[SiteProjectCodeId] [int] NOT NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[SiteProjectCode] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SiteSpending]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteSpending](
	[SiteSpendingId] [int] NOT NULL,
	[BFY] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[OrgName] [nvarchar](255) NULL,
	[FocCode] [nvarchar](255) NULL,
	[FocName] [nvarchar](255) NULL,
	[SiteProjectCode] [nvarchar](255) NULL,
	[SiteProjectName] [nvarchar](255) NULL,
	[SSID] [nvarchar](255) NULL,
	[SiteActionCode] [nvarchar](255) NULL,
	[SiteOperableUnit] [nvarchar](255) NULL,
	[EpaSiteId] [nvarchar](255) NULL,
	[City] [nvarchar](255) NULL,
	[State] [nvarchar](255) NULL,
	[VendorCode] [nvarchar](255) NULL,
	[VendorName] [nvarchar](255) NULL,
	[DocumentType] [nvarchar](255) NULL,
	[DocumentControlNumber] [nvarchar](255) NULL,
	[Requested] [float] NULL,
	[Closed] [float] NULL,
	[Outstanding] [float] NULL,
	[Reversed] [float] NULL,
	[Refunded] [float] NULL,
 CONSTRAINT [PrimaryKeySiteSpending] PRIMARY KEY CLUSTERED 
(
	[SiteSpendingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sources]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sources](
	[SourceId] [int] NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Location] [nvarchar](255) NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PrimaryKeySources] PRIMARY KEY CLUSTERED 
(
	[SourceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusOfFunds]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusOfFunds](
	[StatusOfFundsId] [int] NOT NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[AhName] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[LowerName] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[OrgName] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[Amount] [float] NULL,
	[OpenCommitments] [float] NULL,
	[ULO] [float] NULL,
	[Total Expense Accruals] [float] NULL,
	[Expenditures] [float] NULL,
	[Obligations] [float] NULL,
	[Used] [float] NULL,
	[Available] [float] NULL,
	[NpmCode] [nvarchar](255) NULL,
	[NpmName] [nvarchar](255) NULL,
	[NpmTitle] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyStatusOfFunds] PRIMARY KEY CLUSTERED 
(
	[StatusOfFundsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplemental]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplemental](
	[SupplementalId] [float] NOT NULL,
	[Type] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[Amount] [float] NULL,
	[Time] [float] NULL,
 CONSTRAINT [PrimaryKeySupplemental] PRIMARY KEY CLUSTERED 
(
	[SupplementalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemUpdates]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemUpdates](
	[SystemUpdateId] [int] NOT NULL,
	[ExtId] [int] NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[Amount] [float] NULL,
 CONSTRAINT [PrimaryKeySystemUpdates] PRIMARY KEY CLUSTERED 
(
	[SystemUpdateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transfers]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transfers](
	[TransferId] [int] NOT NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[DocPrefix] [nvarchar](255) NULL,
	[DocType] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[RpioCode] [nvarchar](255) NULL,
	[RpioName] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[ReprogrammingNumber] [nvarchar](255) NULL,
	[ControlNumber] [nvarchar](255) NULL,
	[ProcessedDate] [datetime] NULL,
	[Quarter] [nvarchar](255) NULL,
	[Line] [nvarchar](255) NULL,
	[Subline] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[AhName] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[OrganizationName] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[FromTo] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[NpmCode] [nvarchar](255) NULL,
	[Amount] [float] NULL,
	[Purpose] [nvarchar](max) NULL,
	[ExtendedPurpose] [nvarchar](max) NULL,
	[ResourceType] [nvarchar](255) NULL,
 CONSTRAINT [PrimaryKeyTransfers] PRIMARY KEY CLUSTERED 
(
	[TransferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TravelObligations]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TravelObligations](
	[TravelObligationId] [int] NOT NULL,
	[RpioCode] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[AhName] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[OrgName] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[RcName] [nvarchar](255) NULL,
	[FocCode] [nvarchar](255) NULL,
	[FocName] [nvarchar](255) NULL,
	[FirstName] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[DepartureDate] [datetime] NULL,
	[ReturnDate] [datetime] NULL,
	[DocType] [nvarchar](255) NULL,
	[DCN] [nvarchar](255) NULL,
	[Obligations] [float] NULL,
	[ULO] [float] NULL,
	[Expenditures] [float] NULL,
	[NpmCode] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UpperReconcilliation]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UpperReconcilliation](
	[ReconcilliationId] [int] NOT NULL,
	[ExtId] [int] NULL,
	[PrcId] [int] NULL,
	[BFY] [nvarchar](255) NULL,
	[BudgetLevel] [nvarchar](255) NULL,
	[AhCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[OrgCode] [nvarchar](255) NULL,
	[AccountCode] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[ProgramProjectCode] [nvarchar](255) NULL,
	[ProgramProjectName] [nvarchar](255) NULL,
	[System] [money] NULL,
	[Budget] [money] NULL,
	[Delta] [money] NULL,
	[NET] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkCodes]    Script Date: 8/20/2021 6:35:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkCodes](
	[WorkCodeId] [int] NOT NULL,
	[RcCode] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[WorkCode] [nvarchar](255) NULL,
	[WorkCodeName] [nvarchar](255) NULL
) ON [PRIMARY]
GO
