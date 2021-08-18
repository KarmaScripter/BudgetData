CREATE TABLE [AgencyTransfers]
(
   [AgencyTransferId] INT NOT NULL,
   [ReprogrammingNumber] NVARCHAR(255),
   [ProcessedDate] DATETIME,
   [RPIO] NVARCHAR(255),
   [AhCode] NVARCHAR(255),
   [BFY] NVARCHAR(255),
   [FundCode] NVARCHAR(255),
   [AccountCode] NVARCHAR(255),
   [OrgCode] NVARCHAR(255),
   [BocCode] NVARCHAR(255),
   [RcCode] NVARCHAR(255),
   [Amount] MONEY,
   [FundName] NVARCHAR(255),
   [ProgramProjectCode] NVARCHAR(255),
   [ProgramProjectName] NVARCHAR(255),
   [BocName] NVARCHAR(255),
   [FromTo] NVARCHAR(255),
   [SPIO] NVARCHAR(255),
   [Purpose] NVARCHAR(255),
   [ExtendedPurpose] NVARCHAR(255)
);

CREATE TABLE [Allocations]
(
   [PrcId] INT NOT NULL IDENTITY (1,1),
   [BudgetLevel] NVARCHAR(50) NOT NULL DEFAULT ('NS'),
   [RPIO] NVARCHAR(50) NOT NULL DEFAULT ('NS'),
   [BFY] NVARCHAR(50) NOT NULL DEFAULT ('NS'),
   [FundCode] NVARCHAR(50) NOT NULL DEFAULT ('NS'),
   [AhCode] NVARCHAR(50) NOT NULL DEFAULT ('NS'),
   [OrgCode] NVARCHAR(50) NOT NULL DEFAULT ('NS'),
   [RcCode] NVARCHAR(50) NOT NULL DEFAULT ('NS'),
   [AccountCode] NVARCHAR(50) NOT NULL DEFAULT ('NS'),
   [BocCode] NVARCHAR(50) NOT NULL DEFAULT ('NS'),
   [Amount] FLOAT NOT NULL DEFAULT 0.0,
   [ActivityCode] NVARCHAR(50) NOT NULL DEFAULT ('NS'),
   [ActivityName] NVARCHAR(50) NOT NULL DEFAULT ('NS'),
   [FundName] NVARCHAR(50) NOT NULL DEFAULT ('NS'),
   [BocName] NVARCHAR(50) NOT NULL DEFAULT ('NS'),
   [NpmName] NVARCHAR(50) NOT NULL DEFAULT ('NS'),
   [Division] NVARCHAR(50) NOT NULL DEFAULT ('NS'),
   [DivisionName] NVARCHAR(50) NOT NULL DEFAULT ('NS'),
   [ProgramProjectCode] NVARCHAR(50) NOT NULL DEFAULT ('NS'),
   [ProgramProjectName] NVARCHAR(100) NOT NULL DEFAULT ('NS'),
   [ProgramAreaName] NVARCHAR(50) NOT NULL DEFAULT ('NS'),
   [AhName] NVARCHAR(50) NOT NULL DEFAULT ('NS'),
   [OrgName] NVARCHAR(50) NOT NULL DEFAULT ('NS'),
   [GoalName] NVARCHAR(50) NOT NULL DEFAULT ('NS'),
   [ObjectiveName] NVARCHAR(50) NOT NULL DEFAULT ('NS')
);

CREATE TABLE [ApplicationTables]
(
   [ApplicationTableId] INT NOT NULL,
   [TableName] NVARCHAR(255),
   [Model] NVARCHAR(255)
);

CREATE TABLE [BackUp]
(
   [BackupAllocationId] INT NOT NULL,
   [PrcId] FLOAT,
   [BudgetLevel] NVARCHAR(255),
   [RPIO] NVARCHAR(255),
   [BFY] NVARCHAR(255),
   [FundCode] NVARCHAR(255),
   [AhCode] NVARCHAR(255),
   [OrgCode] NVARCHAR(255),
   [RcCode] NVARCHAR(255),
   [AccountCode] NVARCHAR(255),
   [BocCode] NVARCHAR(255),
   [Amount] FLOAT,
   [AllocationRatio] FLOAT,
   [FundName] NVARCHAR(255),
   [BocName] NVARCHAR(255),
   [Division] NVARCHAR(255),
   [DivisionName] NVARCHAR(255),
   [ActivityCode] NVARCHAR(255),
   [NpmName] NVARCHAR(255),
   [NpmCode] NVARCHAR(255),
   [ProgramProjectCode] NVARCHAR(255),
   [ProgramProjectName] NVARCHAR(255),
   [ProgramAreaCode] NVARCHAR(255),
   [ProgramAreaName] NVARCHAR(255),
   [GoalCode] NVARCHAR(255),
   [GoalName] NVARCHAR(255),
   [ObjectiveCode] NVARCHAR(255),
   [ObjectiveName] NVARCHAR(255),
   [ChangeDate] DATETIME
);

CREATE TABLE [BudgetParameters]
(
   [BudgetParameterId] INT NOT NULL,
   [AhCode] NVARCHAR(255),
   [BFY] NVARCHAR(255),
   [RcCode] NVARCHAR(255),
   [FundCode] NVARCHAR(255)
);

CREATE TABLE [Changes]
(
   [ID] INT NOT NULL,
   [TableName] NVARCHAR(255),
   [FieldName] NVARCHAR(255),
   [Action] NVARCHAR(255),
   [OldValue] NVARCHAR(255),
   [NewValue] NVARCHAR(255),
   [TimeStamp] DATETIME,
   [Message] NVARCHAR(255)
);

CREATE TABLE [CongressionalTransfers]
(
   [CongressionalTransferId] INT NOT NULL,
   [ReprogrammingNumber] NVARCHAR(255),
   [ProcessedDate] DATETIME,
   [RPIO] NVARCHAR(255),
   [AhCode] NVARCHAR(255),
   [BFY] NVARCHAR(255),
   [FundCode] NVARCHAR(255),
   [AccountCode] NVARCHAR(255),
   [OrgCode] NVARCHAR(255),
   [BocCode] NVARCHAR(255),
   [RcCode] NVARCHAR(255),
   [Amount] MONEY,
   [FundName] NVARCHAR(255),
   [ProgramProjectCode] NVARCHAR(255),
   [ProgramProjectName] NVARCHAR(255),
   [BocName] NVARCHAR(255),
   [SPIO] NVARCHAR(255),
   [Purpose] NVARCHAR(255),
   [ExtendedPurpose] NVARCHAR(255)
);

CREATE TABLE [ControlNumbers]
(
   [ControlNumberId] INT NOT NULL IDENTITY (1,1),
   [BFY] NVARCHAR(255) NOT NULL DEFAULT (2019),
   [RPIO] NVARCHAR(255) NOT NULL DEFAULT (06),
   [AhCode] NVARCHAR(255) DEFAULT (06),
   [RegionControlNumber] BIGINT,
   [FundCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [FundControlNumber] BIGINT,
   [RcCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [DivisionName] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [DivisionControlNumber] BIGINT,
   [DateIssued] NVARCHAR(255) NOT NULL DEFAULT ('NS')
);

CREATE TABLE [Deobligations]
(
   [DeobligationId] INT NOT NULL IDENTITY (1,1),
   [RPIO] NVARCHAR(255),
   [BFY] NVARCHAR(255),
   [FundCode] NVARCHAR(255),
   [DocumentNumber] NVARCHAR(255),
   [CalendarYear] NVARCHAR(255),
   [OrgCode] NVARCHAR(255),
   [ProgramProjectCode] NVARCHAR(255),
   [AccountCode] NVARCHAR(255),
   [BocCode] NVARCHAR(255),
   [Date] DATETIME,
   [Amount] FLOAT
);

CREATE TABLE [Distribution]
(
   [DistributionId] INT NOT NULL IDENTITY (1,1),
   [PrcId] FLOAT,
   [BFY] NVARCHAR(255),
   [AhCode] NVARCHAR(255),
   [FundCode] NVARCHAR(255),
   [FundName] NVARCHAR(255),
   [OrgCode] NVARCHAR(255),
   [AccountCode] NVARCHAR(255),
   [ProgramProjectCode] NVARCHAR(255),
   [ProgramProjectName] NVARCHAR(255),
   [BocCode] NVARCHAR(255),
   [BocName] NVARCHAR(255),
   [BudgetLevel] NVARCHAR(255),
   [RcCode] NVARCHAR(255),
   [AllocationRatio] FLOAT,
   [Amount] FLOAT
);

CREATE TABLE [DivisionAuthority]
(
   [DivisionAuthorityId] INT NOT NULL IDENTITY (1,1),
   [RescissionId] INT NOT NULL,
   [PrcId] INT NOT NULL,
   [RPIO] NVARCHAR(255),
   [BudgetLevel] NVARCHAR(255),
   [AhCode] NVARCHAR(255),
   [BFY] NVARCHAR(255),
   [FundCode] NVARCHAR(255),
   [OrgCode] NVARCHAR(255),
   [AccountCode] NVARCHAR(255),
   [ActivityCode] NVARCHAR(255),
   [BocCode] NVARCHAR(255),
   [RcCode] NVARCHAR(255),
   [Allocation] FLOAT,
   [Reduction] FLOAT,
   [Amount] FLOAT,
   [FundName] NVARCHAR(255),
   [BocName] NVARCHAR(255),
   [Division] NVARCHAR(255),
   [DivisionName] NVARCHAR(255),
   [ProgramProjectCode] NVARCHAR(255),
   [ProgramProjectName] NVARCHAR(255),
   [NpmCode] NVARCHAR(255),
   [NpmName] NVARCHAR(255),
   [GoalCode] NVARCHAR(255),
   [GoalName] NVARCHAR(255),
   [ObjectiveCode] NVARCHAR(255),
   [ObjectiveName] NVARCHAR(255),
   [AllocationRatio] FLOAT,
   [ChangeDate] DATETIME
);

CREATE TABLE [DivisionExecution]
(
   [DivisionExecutionId] INT NOT NULL IDENTITY (1,1),
   [BudgetLevel] NVARCHAR(255),
   [RPIO] NVARCHAR(255),
   [BFY] NVARCHAR(255),
   [AhCode] NVARCHAR(255),
   [FundCode] NVARCHAR(255),
   [RcCode] NVARCHAR(255),
   [DivisionName] NVARCHAR(255),
   [FundName] NVARCHAR(255),
   [OrgCode] NVARCHAR(255),
   [AccountCode] NVARCHAR(255),
   [ActivityCode] NVARCHAR(255),
   [ProgramProjectCode] NVARCHAR(255),
   [ProgramProjectName] NVARCHAR(255),
   [BocCode] NVARCHAR(255),
   [BocName] NVARCHAR(255),
   [SiteProjectCode] NVARCHAR(255),
   [Amount] FLOAT,
   [OpenCommitments] FLOAT,
   [CommitmentRatio] FLOAT,
   [Obligations] FLOAT,
   [ObligationRatio] FLOAT,
   [Used] FLOAT,
   [Utilization] FLOAT,
   [Available] MONEY,
   [Availability] FLOAT
);

CREATE TABLE [DivisionPersonnel]
(
   [PersonnelId] INT NOT NULL IDENTITY (1,1),
   [RcCode] NVARCHAR(255),
   [EmployeeId] NVARCHAR(255),
   [LastName] NVARCHAR(255),
   [FirstName] NVARCHAR(255),
   [JobTitle] NVARCHAR(255),
   [Grade] NVARCHAR(255),
   [Step] NVARCHAR(255),
   [HireDate] DATETIME,
   [Tenure] FLOAT,
   [HrOrgName] NVARCHAR(255),
   [Email] NVARCHAR(255),
   [PhoneNumber] NVARCHAR(255),
   [Office] NVARCHAR(255),
   [MailCode] NVARCHAR(255)
);

CREATE TABLE [DivisionTraining]
(
   [DivisionTrainingId] INT NOT NULL IDENTITY (1,1),
   [PrcId] FLOAT,
   [BudgetLevel] NVARCHAR(255),
   [RPIO] NVARCHAR(255),
   [BFY] NVARCHAR(255),
   [AhCode] NVARCHAR(255),
   [FundCode] NVARCHAR(255),
   [OrgCode] NVARCHAR(255),
   [AccountCode] NVARCHAR(255),
   [BocCode] NVARCHAR(255),
   [RcCode] NVARCHAR(255),
   [Amount] DECIMAL(18,0),
   [FundName] NVARCHAR(255),
   [BocName] NVARCHAR(255),
   [Division] NVARCHAR(255),
   [DivisionName] NVARCHAR(255),
   [ActivityCode] NVARCHAR(255),
   [NpmName] NVARCHAR(255),
   [NpmCode] NVARCHAR(255),
   [ProgramProjectCode] NVARCHAR(255),
   [ProgramProjectName] NVARCHAR(255),
   [ProgramAreaCode] NVARCHAR(255),
   [ProgramAreaName] NVARCHAR(255),
   [GoalCode] NVARCHAR(255),
   [GoalName] NVARCHAR(255),
   [ObjectiveCode] NVARCHAR(255),
   [ObjectiveName] NVARCHAR(255),
   [AllocationRatio] FLOAT,
   [ChangeDate] DATETIME
);

CREATE TABLE [EmployeeData]
(
   [EmployeeDataId] INT NOT NULL IDENTITY (1,1),
   [RpioCode] NVARCHAR(255),
   [RpioName] NVARCHAR(255),
   [ActionDate] DATETIME,
   [HiringAuthority] NVARCHAR(255),
   [SupervisorId] NVARCHAR(255),
   [JobTitle] NVARCHAR(255),
   [HrOrgCode] NVARCHAR(255),
   [HrOrgName] NVARCHAR(255),
   [EmployeeId] NVARCHAR(255),
   [FirstName] NVARCHAR(255),
   [LastName] NVARCHAR(255),
   [RetirementPlan] NVARCHAR(255),
   [ScheduledRetirementDate] DATETIME,
   [HireDate] DATETIME,
   [Grade] NVARCHAR(255),
   [Step] NVARCHAR(255),
   [GradeEntry] DATETIME,
   [LastIncrease] DATETIME,
   [StepEntry] DATETIME,
   [WigiDueDate] DATETIME,
   [EmployeeStatus] NVARCHAR(255),
   [HoursEarnedYearToDate] FLOAT,
   [CarryoverHours] FLOAT,
   [HoursAdjustedYearToDate] FLOAT,
   [HoursBalance] FLOAT,
   [ProjectedAnnualHours] FLOAT,
   [ProjectedNextPeriodHours] FLOAT,
   [HoursTakenYearToDate] FLOAT
);

CREATE TABLE [EmployeeLeave]
(
   [EmployeeLeaveId] INT NOT NULL IDENTITY (1,1),
   [LastName] NVARCHAR(255),
   [FirstName] NVARCHAR(255),
   [EmployeeId] NVARCHAR(255),
   [HoursEarnedYearToDate] FLOAT,
   [CarryoverHours] FLOAT,
   [HoursAdjustedYearToDate] FLOAT,
   [HoursBalance] FLOAT,
   [ProjectedAnnualHours] FLOAT,
   [ProjectedNextPeriodHours] FLOAT,
   [HoursTakenYearToDate] FLOAT
);

CREATE TABLE [ExecutionTables]
(
   [ExecutionTableId] INT NOT NULL IDENTITY (1,1),
   [TableName] NVARCHAR(255),
   [Type] NVARCHAR(255)
);

CREATE TABLE [ExternalUpdates]
(
   [ExternalUpdateId] INT NOT NULL IDENTITY (1,1),
   [PrcId] FLOAT,
   [BudgetLevel] NVARCHAR(255),
   [RPIO] NVARCHAR(255),
   [BFY] NVARCHAR(255),
   [FundCode] NVARCHAR(255),
   [AhCode] NVARCHAR(255),
   [OrgCode] NVARCHAR(255),
   [RcCode] NVARCHAR(255),
   [AccountCode] NVARCHAR(255),
   [BocCode] NVARCHAR(255),
   [Amount] FLOAT,
   [FundName] NVARCHAR(255),
   [BocName] NVARCHAR(255),
   [Division] NVARCHAR(255),
   [DivisionName] NVARCHAR(255),
   [ActivityCode] NVARCHAR(255),
   [NpmName] NVARCHAR(255),
   [NpmCode] NVARCHAR(255),
   [ProgramProjectCode] NVARCHAR(255),
   [ProgramProjectName] NVARCHAR(255),
   [ProgramAreaCode] NVARCHAR(255),
   [ProgramAreaName] NVARCHAR(255),
   [GoalCode] NVARCHAR(255),
   [GoalName] NVARCHAR(255),
   [ObjectiveCode] NVARCHAR(255),
   [ObjectiveName] NVARCHAR(255)
);

CREATE TABLE [FullTimeEquivalents]
(
   [FullTimeEquivalentId] INT NOT NULL IDENTITY (1,1),
   [PrcId] INT NOT NULL,
   [BudgetLevel] NVARCHAR(255),
   [RPIO] NVARCHAR(255),
   [BFY] NVARCHAR(255),
   [FundCode] NVARCHAR(255),
   [AhCode] NVARCHAR(255),
   [OrgCode] NVARCHAR(255),
   [RcCode] NVARCHAR(255),
   [AccountCode] NVARCHAR(255),
   [BocCode] NVARCHAR(255),
   [Amount] FLOAT,
   [FundName] NVARCHAR(255),
   [BocName] NVARCHAR(255),
   [Division] NVARCHAR(255),
   [DivisionName] NVARCHAR(255),
   [ActivityCode] NVARCHAR(255),
   [NpmCode] NVARCHAR(255),
   [NpmName] NVARCHAR(255),
   [ProgramProjectCode] NVARCHAR(255),
   [ProgramProjectName] NVARCHAR(255),
   [ProgramAreaCode] NVARCHAR(255),
   [ProgramAreaName] NVARCHAR(255),
   [GoalCode] NVARCHAR(255),
   [GoalName] NVARCHAR(255),
   [ObjectiveCode] NVARCHAR(255),
   [ObjectiveName] NVARCHAR(255),
   [AllocationRatio] FLOAT,
   [ChangeDate] DATETIME
);

CREATE TABLE [HumanResourceOrganizations]
(
   [HumanResourceOrganizationId] BIGINT,
   [RcCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [HumanResourceOrganizationCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [HumanResourceOrganizationName] NVARCHAR(255) NOT NULL DEFAULT ('NS')
);

CREATE TABLE [LocatorData]
(
   [LocatorId] INT NOT NULL IDENTITY (1,1),
   [LastName] NVARCHAR(255),
   [FirstName] NVARCHAR(255),
   [Email] NVARCHAR(255),
   [PhoneNumber] NVARCHAR(255),
   [MailCode] NVARCHAR(255),
   [Office] NVARCHAR(255),
   [CellNumber] NVARCHAR(255),
   [Status] NVARCHAR(255)
);

CREATE TABLE [OperatingPlan]
(
   [OppId] INT NOT NULL IDENTITY (1,1),
   [RPIO] NVARCHAR(255),
   [BFY] NVARCHAR(255),
   [BudgetLevel] NVARCHAR(255),
   [AhCode] NVARCHAR(255),
   [FundCode] NVARCHAR(255),
   [OrgCode] NVARCHAR(255),
   [AccountCode] NVARCHAR(255),
   [BocCode] NVARCHAR(255),
   [BocName] NVARCHAR(255),
   [RcCode] NVARCHAR(255),
   [Amount] FLOAT,
   [NpmCode] NVARCHAR(255),
   [ProgramProjectCode] NVARCHAR(255),
   [ProgramAreaCode] NVARCHAR(255),
   [NpmName] NVARCHAR(255),
   [AhName] NVARCHAR(255),
   [FundName] NVARCHAR(255),
   [OrgName] NVARCHAR(255),
   [ActivityCode] NVARCHAR(255),
   [ActivityName] NVARCHAR(255),
   [DivisionName] NVARCHAR(255),
   [ProgramProjectName] NVARCHAR(255),
   [ProgramAreaName] NVARCHAR(255),
   [GoalCode] NVARCHAR(255),
   [GoalName] NVARCHAR(255),
   [ObjectiveCode] NVARCHAR(255),
   [ObjectiveName] NVARCHAR(255)
);

CREATE TABLE [PayPeriods]
(
   [PayPeriodId] INT NOT NULL IDENTITY (1,1),
   [Period] NVARCHAR(255) NOT NULL,
   [PayPeriod] NVARCHAR(255),
   [StartDate] DATETIME,
   [EndDate] DATETIME
);

CREATE TABLE [Payroll]
(
   [PayrollId] INT NOT NULL IDENTITY (1,1),
   [PrcId] INT NOT NULL,
   [BudgetLevel] NVARCHAR(255),
   [RPIO] NVARCHAR(255),
   [BFY] NVARCHAR(255),
   [FundCode] NVARCHAR(255),
   [AhCode] NVARCHAR(255),
   [OrgCode] NVARCHAR(255),
   [RcCode] NVARCHAR(255),
   [AccountCode] NVARCHAR(255),
   [BocCode] NVARCHAR(255),
   [Amount] FLOAT,
   [FundName] NVARCHAR(255),
   [BocName] NVARCHAR(255),
   [Division] NVARCHAR(255),
   [DivisionName] NVARCHAR(255),
   [ActivityCode] NVARCHAR(255),
   [NpmCode] NVARCHAR(255),
   [NpmName] NVARCHAR(255),
   [ProgramProjectCode] NVARCHAR(255),
   [ProgramProjectName] NVARCHAR(255),
   [ProgramAreaCode] NVARCHAR(255),
   [ProgramAreaName] NVARCHAR(255),
   [GoalCode] NVARCHAR(255),
   [GoalName] NVARCHAR(255),
   [ObjectiveCode] NVARCHAR(255),
   [ObjectiveName] NVARCHAR(255),
   [AllocationRatio] FLOAT,
   [ChangeDate] DATETIME
);

CREATE TABLE [PayrollHours]
(
   [PayrollHoursId] INT NOT NULL IDENTITY (1,1),
   [RpioCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [PayPeriod] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [StartDate] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [EndDate] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [EmployeeNumber] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [EmployeeFirstName] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [EmployeeLastName] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [Date] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [HumanResourceOrganizationCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [HumanResourceOrganizationName] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [ReportingCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [ReportingCodeName] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [WorkCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [Hours] FLOAT DEFAULT ('0.0')
);

CREATE TABLE [PayrollObligations]
(
   [PayrollObligationsId] INT NOT NULL IDENTITY (1,1),
   [RpioCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [BFY] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [FundCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [AhCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [OrgCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [RcCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [AccountCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [ProgramProjectCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [Amount] FLOAT DEFAULT ('0.0'),
   [Hours] FLOAT DEFAULT ('0.0'),
   [CumulativeBenefits] FLOAT DEFAULT ('0.0'),
   [AnnualOvertimePaid] FLOAT DEFAULT ('0.0'),
   [AnnualOvertimeHours] FLOAT DEFAULT ('0.0'),
   [AnnualBasePaid] FLOAT DEFAULT ('0.0'),
   [AnnualBaseHours] FLOAT DEFAULT ('0.0'),
   [AnnualOtherHours] FLOAT DEFAULT ('0.0'),
   [AnnualOtherPaid] FLOAT DEFAULT ('0.0'),
   [AllocationPercentage] FLOAT DEFAULT ('0.0'),
   [PayPeriod] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [FocCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [FocName] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [WorkCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [WorkCodeName] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [HumanResourceOrganizationCode] NVARCHAR(255) DEFAULT ('NS')
);

CREATE TABLE [PeoplePlus]
(
   [PeoplePlusId] INT NOT NULL IDENTITY (1,1),
   [RcCode] NVARCHAR(255),
   [DivisionName] NVARCHAR(255),
   [EpaNumber] NVARCHAR(255),
   [LastName] NVARCHAR(255),
   [FirstName] NVARCHAR(255),
   [ReportingCode] NVARCHAR(255),
   [ReportingCodeName] NVARCHAR(255),
   [WorkCode] NVARCHAR(255),
   [Hours] FLOAT
);

CREATE TABLE [ProgrammaticReserve]
(
   [ProgrammaticReserveId] INT NOT NULL IDENTITY (1,1),
   [PrcId] INT,
   [BudgetLevel] NVARCHAR(255),
   [RPIO] NVARCHAR(255),
   [AhCode] NVARCHAR(255),
   [BFY] NVARCHAR(255),
   [FundCode] NVARCHAR(255),
   [OrgCode] NVARCHAR(255),
   [AccountCode] NVARCHAR(255),
   [ActivityCode] NVARCHAR(255),
   [BocCode] NVARCHAR(255),
   [RcCode] NVARCHAR(255),
   [CurrentYear] INT,
   [Reduction] INT,
   [Ratio] FLOAT,
   [Budget] INT,
   [PriorYear] INT,
   [FundName] NVARCHAR(255),
   [ProgramProjectCode] NVARCHAR(255),
   [ProgramProjectName] NVARCHAR(255),
   [BocName] NVARCHAR(255),
   [NpmCode] NVARCHAR(255),
   [NpmName] NVARCHAR(255),
   [Division] NVARCHAR(255),
   [DivisionName] NVARCHAR(255),
   [Delta] FLOAT
);

CREATE TABLE [ProgrammaticReservePriorYearUtilization]
(
   [ProgrammaticReservePriorYearUtilizationId] INT NOT NULL IDENTITY (1,1),
   [OrgCode] NVARCHAR(255),
   [BFY] NVARCHAR(255),
   [RcCode] NVARCHAR(255),
   [DivisionName] NVARCHAR(255),
   [FundCode] NVARCHAR(255),
   [FundName] NVARCHAR(255),
   [AccountCode] NVARCHAR(255),
   [ProgramProjectName] NVARCHAR(255),
   [BocCode] NVARCHAR(255),
   [BocName] NVARCHAR(255),
   [CurrentYear] MONEY,
   [Reduction] MONEY,
   [Budget] MONEY,
   [PriorYear] MONEY,
   [OpenCommitments] MONEY,
   [ULO] MONEY
);

CREATE TABLE [Purchases]
(
   [PurchaseId] INT NOT NULL IDENTITY (1,1),
   [BFY] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [RpioCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [FocName] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [AhCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [RcCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [FundCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [BocCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [DCN] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [DocumentType] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [DocumentPrefix] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [FocCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [OriginalActionDate] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [GrantNumber] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [NpmCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [ObligatingDocumentNumber] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [OrgCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [AccountCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [ActivityCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [ReimbursableAgreementNumber] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [SiteProjectCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [System] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [TransactionNumber] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [PurchaseRequest] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [Commitments] FLOAT DEFAULT ('0.0'),
   [OpenCommitments] FLOAT DEFAULT ('0.0'),
   [Obligations] FLOAT DEFAULT ('0.0'),
   [ULO] FLOAT DEFAULT ('0.0'),
   [Deobligations] FLOAT DEFAULT ('0.0'),
   [Expenditures] FLOAT DEFAULT ('0.0')
);

CREATE TABLE [QueryDefinitions]
(
   [QueryDefinitionId] INT NOT NULL IDENTITY (1,1),
   [Name] NVARCHAR(255),
   [Type] NVARCHAR(255)
);

CREATE TABLE [RecoveryFundTransfers]
(
   [RecoveryId] INT NOT NULL IDENTITY (1,1),
   [ReprogrammingNumber] NVARCHAR(255),
   [ProcessedDate] DATETIME,
   [RPIO] NVARCHAR(255),
   [AhCode] NVARCHAR(255),
   [BFY] NVARCHAR(255),
   [FundCode] NVARCHAR(255),
   [AccountCode] NVARCHAR(255),
   [OrgCode] NVARCHAR(255),
   [BocCode] NVARCHAR(255),
   [RcCode] NVARCHAR(255),
   [Amount] MONEY,
   [FundName] NVARCHAR(255),
   [ProgramProjectName] NVARCHAR(255),
   [BocName] NVARCHAR(255),
   [NpmCode] NVARCHAR(255),
   [NpmName] NVARCHAR(255),
   [Purpose] NVARCHAR(255),
   [ExtendedPurpose] NVARCHAR(255)
);

CREATE TABLE [ReferenceTables]
(
   [ReferenceTableId] INT NOT NULL IDENTITY (1,1),
   [TableName] NVARCHAR(255),
   [Type] NVARCHAR(255)
);

CREATE TABLE [Rescission]
(
   [RescissionId] INT NOT NULL IDENTITY (1,1),
   [PrcId] INT,
   [RPIO] NVARCHAR(255),
   [BudgetLevel] NVARCHAR(255),
   [AhCode] NVARCHAR(255),
   [BFY] NVARCHAR(255),
   [FundCode] NVARCHAR(255),
   [OrgCode] NVARCHAR(255),
   [AccountCode] NVARCHAR(255),
   [ActivityCode] NVARCHAR(255),
   [BocCode] NVARCHAR(255),
   [RcCode] NVARCHAR(255),
   [Allocation] INT,
   [Reduction] INT,
   [Amount] INT,
   [FundName] NVARCHAR(255),
   [BocName] NVARCHAR(255),
   [Division] NVARCHAR(255),
   [DivisionName] NVARCHAR(255),
   [ProgramProjectCode] NVARCHAR(255),
   [ProgramProjectName] NVARCHAR(255),
   [NpmCode] NVARCHAR(255),
   [NpmName] NVARCHAR(255),
   [GoalCode] NVARCHAR(255),
   [GoalName] NVARCHAR(255),
   [ObjectiveCode] NVARCHAR(255),
   [ObjectiveName] NVARCHAR(255)
);

CREATE TABLE [Sites]
(
   [SiteId] INT NOT NULL IDENTITY (1,1),
   [RpioCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [BFY] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [FundCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [AhCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [AccountCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [OrgCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [OrgName] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [RcCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [ActivityCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [ProgramProjectCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [BocCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [FocCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [DCN] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [EpaSiteId] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [SiteName] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [SiteProjectCode] NVARCHAR(50) DEFAULT ('NS'),
   [SiteProjectName] NVARCHAR(50) DEFAULT ('NS'),
   [City] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [District] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [County] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [StateCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [StateName] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [StreetAddressLine1] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [StreetAddressLine2] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [ZipCode] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [OriginalActionDate] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [LastActionDate] NVARCHAR(255) NOT NULL DEFAULT ('NS'),
   [Commitments] FLOAT DEFAULT ('0.0'),
   [OpenCommitments] FLOAT DEFAULT ('0.0'),
   [Obligations] FLOAT DEFAULT ('0.0'),
   [ULO] FLOAT DEFAULT ('0.0'),
   [Deobligations] FLOAT DEFAULT ('0.0'),
   [Expenditures] FLOAT DEFAULT ('0.0')
);

CREATE TABLE [StatusOfFunds]
(
   [StatusOfFundsId] INT NOT NULL,
   [BudgetLevel] NVARCHAR(255),
   [BFY] NVARCHAR(255),
   [AhCode] NVARCHAR(255),
   [AhName] NVARCHAR(255),
   [ProgramAreaName] NVARCHAR(255),
   [ProgramProjectCode] NVARCHAR(255),
   [ProgramProjectName] NVARCHAR(255),
   [AccountCode] NVARCHAR(255),
   [LowerName] NVARCHAR(255),
   [RcCode] NVARCHAR(255),
   [RcName] NVARCHAR(255),
   [DivisionName] NVARCHAR(255),
   [OrgCode] NVARCHAR(255),
   [OrgName] NVARCHAR(255),
   [BocCode] NVARCHAR(255),
   [BocName] NVARCHAR(255),
   [FundCode] NVARCHAR(255),
   [FundName] NVARCHAR(255),
   [Amount] FLOAT,
   [OpenCommitments] FLOAT,
   [ULO] FLOAT,
   [Total Expense Accruals] FLOAT,
   [Expenditures] FLOAT,
   [Obligations] FLOAT,
   [Used] FLOAT,
   [Available] FLOAT,
   [NpmCode] NVARCHAR(255),
   [NpmName] NVARCHAR(255),
   [NpmTitle] NVARCHAR(255),
   [ProgramAreaCode] NVARCHAR(255)
);

CREATE TABLE [Supplemental]
(
   [SupId] INT NOT NULL IDENTITY (48,1),
   [Type] NVARCHAR(255),
   [RcCode] NVARCHAR(255),
   [Division] NVARCHAR(255),
   [DivisionName] NVARCHAR(255),
   [FundCode] NVARCHAR(255),
   [FundName] NVARCHAR(255),
   [BFY] NVARCHAR(255),
   [BocCode] NVARCHAR(255),
   [BocName] NVARCHAR(255),
   [Amount] FLOAT,
   [Time] FLOAT
);

CREATE TABLE [Transfers]
(
   [TransferId] INT NOT NULL IDENTITY (713,1),
   [BudgetLevel] NVARCHAR(255),
   [DocType] NVARCHAR(255),
   [BFY] NVARCHAR(255),
   [RPIO] NVARCHAR(255),
   [FundCode] NVARCHAR(255),
   [FundName] NVARCHAR(255),
   [DocumentNumber] NVARCHAR(255),
   [ProcessedDate] DATETIME,
   [AhCode] NVARCHAR(255),
   [AhName] NVARCHAR(255),
   [OrgCode] NVARCHAR(255),
   [OrgName] NVARCHAR(255),
   [RcCode] NVARCHAR(255),
   [DivisionName] NVARCHAR(255),
   [Code] NVARCHAR(255) NOT NULL,
   [ProgramAreaCode] NVARCHAR(255),
   [ProgramAreaName] NVARCHAR(255),
   [ProgramProjectCode] NVARCHAR(255),
   [ResourceType] NVARCHAR(255),
   [Line] FLOAT,
   [Subline] FLOAT,
   [FromTo] NVARCHAR(255),
   [BocCode] NVARCHAR(255),
   [BocName] NVARCHAR(255),
   [Amount] FLOAT NOT NULL,
   [Purpose] NTEXT
);

CREATE TABLE [TravelObligations]
(
   [TravelObligationId] INT NOT NULL,
   [RpioCode] NVARCHAR(255),
   [BFY] NVARCHAR(255),
   [AhCode] NVARCHAR(255),
   [AhName] NVARCHAR(255),
   [FundCode] NVARCHAR(255),
   [FundName] NVARCHAR(255),
   [AccountCode] NVARCHAR(255),
   [ProgramProjectCode] NVARCHAR(255),
   [ProgramProjectName] NVARCHAR(255),
   [OrgCode] NVARCHAR(255),
   [OrgName] NVARCHAR(255),
   [BocCode] NVARCHAR(255),
   [BocName] NVARCHAR(255),
   [RcCode] NVARCHAR(255),
   [RcName] NVARCHAR(255),
   [FocCode] NVARCHAR(255),
   [FocName] NVARCHAR(255),
   [FirstName] NVARCHAR(255),
   [LastName] NVARCHAR(255),
   [DepartureDate] DATETIME,
   [ReturnDate] DATETIME,
   [DocumentType] NVARCHAR(255),
   [DCN] NVARCHAR(255),
   [Obligations] FLOAT,
   [ULO] FLOAT,
   [Expenditures] FLOAT,
   [NpmCode] NVARCHAR(255)
);

ALTER TABLE [Allocations] ADD CONSTRAINT [PK_Allocations] PRIMARY KEY ([PrcId]);

CREATE UNIQUE INDEX [UQ__DivisionPersonnel__0000000000000701] ON [DivisionPersonnel] ([PersonnelId] ASC);

CREATE UNIQUE INDEX [UQ__DivisionTraining__0000000000000742] ON [DivisionTraining] ([DivisionTrainingId] ASC);

CREATE UNIQUE INDEX [UQ__EmployeeData__0000000000000792] ON [EmployeeData] ([EmployeeDataId] ASC);

CREATE UNIQUE INDEX [UQ__EmployeeLeave__00000000000007AE] ON [EmployeeLeave] ([EmployeeLeaveId] ASC);

CREATE UNIQUE INDEX [UQ__FullTimeEquivalents__000000000000085F] ON [FullTimeEquivalents] ([FullTimeEquivalentId] ASC);

CREATE UNIQUE INDEX [UQ__FullTimeEquivalents__0000000000000864] ON [FullTimeEquivalents] ([PrcId] ASC);

CREATE UNIQUE INDEX [UQ__LocatorData__00000000000008F1] ON [LocatorData] ([LocatorId] ASC);

CREATE UNIQUE INDEX [UQ__OperatingPlan__000000000000093F] ON [OperatingPlan] ([OppId] ASC);

CREATE UNIQUE INDEX [UQ__PayPeriods__000000000000094F] ON [PayPeriods] ([PayPeriodId] ASC);

CREATE UNIQUE INDEX [UQ__Payroll__0000000000000992] ON [Payroll] ([PayrollId] ASC);

CREATE UNIQUE INDEX [UQ__Payroll__0000000000000997] ON [Payroll] ([PrcId] ASC);

CREATE UNIQUE INDEX [UQ__PeoplePlus__00000000000009B3] ON [PeoplePlus] ([PeoplePlusId] ASC);

CREATE UNIQUE INDEX [UQ__ProgrammaticReserve__0000000000000A00] ON [ProgrammaticReserve] ([ProgrammaticReserveId] ASC);

CREATE UNIQUE INDEX [UQ__ProgrammaticReservePriorYearUtilization__0000000000000A28] ON [ProgrammaticReservePriorYearUtilization] ([ProgrammaticReservePriorYearUtilizationId] ASC);

CREATE UNIQUE INDEX [UQ__ReferenceTables__0000000000000A62] ON [ReferenceTables] ([ReferenceTableId] ASC);

CREATE UNIQUE INDEX [UQ__Rescission__0000000000000A9E] ON [Rescission] ([RescissionId] ASC);

ALTER TABLE [FullTimeEquivalents] ADD CONSTRAINT [FK_FullTimeEquivalents] FOREIGN KEY ([PrcId])
   REFERENCES [Allocations] ([PrcId]) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [Payroll] ADD CONSTRAINT [FK_Payroll] FOREIGN KEY ([PrcId])
   REFERENCES [Allocations] ([PrcId]) ON DELETE NO ACTION ON UPDATE NO ACTION;
