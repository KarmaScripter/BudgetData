BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Requisitions" (
	"RequisitionId"	INTEGER,
	"BFY"	INTEGER,
	"DCN"	TEXT,
	"DocumentNumber"	TEXT,
	"ModifiedBy"	TEXT,
	"RequestDate"	TEXT,
	"CreatedBy"	TEXT,
	"DocumentDate"	TEXT,
	"ClosedDate"	TEXT,
	"FundCode"	TEXT,
	"RcCode"	TEXT,
	"AccountCode"	TEXT,
	"ProjectCode"	TEXT,
	"FocCode"	INTEGER,
	"Requested"	INTEGER,
	"Closed"	INTEGER,
	"Outstanding"	INTEGER,
	"Expended"	INTEGER,
	"Reversed"	INTEGER
);
CREATE TABLE IF NOT EXISTS "Payments" (
	"PaymentId"	INTEGER,
	"InvoiceNumber"	TEXT,
	"InvoiceDate"	TEXT,
	"ContractNumber"	TEXT,
	"OrderNumber"	TEXT,
	"CheckDate"	TEXT,
	"ModificationNumber"	TEXT,
	"DocumentType"	TEXT,
	"DCN"	TEXT,
	"FundCode"	TEXT,
	"AccountCode"	TEXT,
	"RcCode"	TEXT,
	"ProjectCode"	TEXT,
	"FocCode"	INTEGER,
	"CostOrgCode"	TEXT,
	"Payment"	INTEGER,
	"Disbursed"	REAL
);
CREATE TABLE IF NOT EXISTS "Vendors" (
	"VendorId"	INTEGER NOT NULL,
	"BFY"	TEXT NOT NULL DEFAULT NA,
	"FundCode"	TEXT NOT NULL DEFAULT NA,
	"VendorCode"	TEXT NOT NULL DEFAULT NA,
	"VendorName"	TEXT NOT NULL DEFAULT NA,
	"DUNS"	TEXT NOT NULL DEFAULT NA,
	"OrgCode"	TEXT NOT NULL DEFAULT NA,
	"RcCode"	TEXT NOT NULL DEFAULT NA,
	"AccountCode"	TEXT NOT NULL DEFAULT NA,
	"FocCode"	TEXT NOT NULL DEFAULT NA,
	"DocType"	TEXT NOT NULL DEFAULT NA,
	"DocumentNumber"	TEXT NOT NULL DEFAULT NA,
	"StartDate"	TEXT NOT NULL DEFAULT NA,
	"EndDate"	TEXT NOT NULL DEFAULT NA,
	"ClosedDate"	TEXT NOT NULL DEFAULT NA,
	"Amount"	NUMERIC NOT NULL DEFAULT 0.0,
	"Expended"	NUMERIC NOT NULL DEFAULT 0.0,
	"ULO"	NUMERIC NOT NULL DEFAULT 0.0,
	"FundName"	TEXT NOT NULL DEFAULT NA,
	"FocName"	TEXT NOT NULL DEFAULT NA,
	"OrgName"	TEXT NOT NULL DEFAULT NA,
	"ProgramProjectName"	TEXT NOT NULL DEFAULT NA,
	PRIMARY KEY("VendorId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Sites" (
	"SiteId"	INTEGER NOT NULL,
	"RpioCode"	TEXT NOT NULL DEFAULT NS,
	"BFY"	TEXT NOT NULL DEFAULT NS,
	"FundCode"	TEXT NOT NULL DEFAULT NS,
	"AhCode"	TEXT NOT NULL DEFAULT NS,
	"AccountCode"	TEXT NOT NULL DEFAULT NS,
	"OrgCode"	TEXT NOT NULL DEFAULT NS,
	"BocCode"	TEXT NOT NULL DEFAULT NS,
	"RcCode"	TEXT NOT NULL DEFAULT NS,
	"ActivityCode"	TEXT NOT NULL DEFAULT NS,
	"ProgramProjectCode"	TEXT NOT NULL DEFAULT NS,
	"FocCode"	TEXT NOT NULL DEFAULT NS,
	"DCN"	TEXT NOT NULL DEFAULT NS,
	"EpaSiteId"	TEXT NOT NULL DEFAULT NS,
	"SiteName"	TEXT NOT NULL DEFAULT NS,
	"SiteProjectCode"	TEXT NOT NULL DEFAULT NS,
	"SiteProjectName"	TEXT NOT NULL DEFAULT NS,
	"City"	TEXT NOT NULL DEFAULT NS,
	"District"	TEXT NOT NULL DEFAULT NS,
	"OrgName"	TEXT NOT NULL DEFAULT NS,
	"County"	TEXT NOT NULL DEFAULT NS,
	"StateCode"	TEXT NOT NULL DEFAULT NS,
	"StateName"	TEXT NOT NULL DEFAULT NS,
	"StreetAddressLine1"	TEXT NOT NULL DEFAULT NS,
	"StreetAddressLine2"	TEXT NOT NULL DEFAULT NS,
	"ZipCode"	TEXT NOT NULL DEFAULT NS,
	"OriginalActionDate"	TEXT NOT NULL DEFAULT NS,
	"LastActionDate"	TEXT NOT NULL DEFAULT NS,
	"Commitments"	NUMERIC NOT NULL DEFAULT 0.0,
	"OpenCommitments"	NUMERIC NOT NULL DEFAULT 0.0,
	"Obligations"	NUMERIC NOT NULL DEFAULT 0.0,
	"ULO"	NUMERIC NOT NULL DEFAULT 0.0,
	"Deobligations"	NUMERIC NOT NULL DEFAULT 0.0,
	"Expenditures"	NUMERIC NOT NULL DEFAULT 0.0,
	PRIMARY KEY("SiteId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "TravelObligations" (
	"TravelObligationId"	INTEGER NOT NULL,
	"RpioCode"	TEXT NOT NULL DEFAULT NA,
	"BFY"	TEXT NOT NULL DEFAULT NA,
	"FundCode"	TEXT NOT NULL DEFAULT NA,
	"AhCode"	TEXT NOT NULL DEFAULT NA,
	"RcCode"	TEXT NOT NULL DEFAULT NA,
	"AccountCode"	TEXT NOT NULL DEFAULT NA,
	"ProgramAreaCode"	TEXT NOT NULL DEFAULT NA,
	"FocCode"	TEXT NOT NULL DEFAULT NA,
	"Destination"	TEXT NOT NULL DEFAULT NA,
	"FirstName"	TEXT NOT NULL DEFAULT NA,
	"MiddleName"	TEXT NOT NULL DEFAULT NA,
	"LastName"	TEXT NOT NULL DEFAULT NA,
	"Email"	TEXT NOT NULL DEFAULT NA,
	"DepartureDate"	TEXT NOT NULL DEFAULT NA,
	"ReturnDate"	TEXT NOT NULL DEFAULT NA,
	"DocumentType"	TEXT NOT NULL DEFAULT NA,
	"DCN"	TEXT NOT NULL DEFAULT NA,
	"Obligations"	NUMERIC DEFAULT 0.00,
	"FocName"	TEXT NOT NULL DEFAULT NA,
	PRIMARY KEY("TravelObligationId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "PayrollObligations" (
	"PayrollObligationsId"	INTEGER NOT NULL,
	"RpioCode"	TEXT NOT NULL DEFAULT NA,
	"BFY"	TEXT NOT NULL DEFAULT NA,
	"FundCode"	TEXT NOT NULL DEFAULT NA,
	"AhCode"	TEXT NOT NULL DEFAULT NA,
	"OrgCode"	TEXT NOT NULL DEFAULT NA,
	"RcCode"	TEXT NOT NULL DEFAULT NA,
	"AccountCode"	TEXT NOT NULL DEFAULT NA,
	"ProgramProjectCode"	TEXT NOT NULL DEFAULT NA,
	"Amount"	NUMERIC NOT NULL DEFAULT 0.0,
	"Hours"	NUMERIC NOT NULL DEFAULT 0.0,
	"CumulativeBenefits"	NUMERIC NOT NULL DEFAULT 0.0,
	"AnnualOvertimePaid"	NUMERIC NOT NULL DEFAULT 0.0,
	"AnnualOvertimeHours"	NUMERIC NOT NULL DEFAULT 0.0,
	"AnnualBasePaid"	NUMERIC NOT NULL DEFAULT 0.0,
	"AnnualBaseHours"	NUMERIC NOT NULL DEFAULT 0.0,
	"AnnualOtherHours"	NUMERIC NOT NULL DEFAULT 0.0,
	"AnnualOtherPaid"	NUMERIC NOT NULL DEFAULT 0.0,
	"AllocationPercentage"	NUMERIC NOT NULL DEFAULT 0.0,
	"PayPeriod"	TEXT NOT NULL DEFAULT NA,
	"FocCode"	TEXT NOT NULL DEFAULT NA,
	"WorkCode"	TEXT NOT NULL DEFAULT NA,
	"HumanResourceOrganizationCode"	TEXT NOT NULL DEFAULT NA,
	"WorkCodeName"	TEXT NOT NULL DEFAULT NA,
	"FocName"	TEXT NOT NULL DEFAULT NA,
	PRIMARY KEY("PayrollObligationsId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Accounts" (
	"AccountId"	INTEGER NOT NULL,
	"Code"	TEXT NOT NULL,
	"ActivityCode"	TEXT,
	"Name"	TEXT,
	"Title"	TEXT,
	"ProgramAreaCode"	TEXT,
	"GoalCode"	TEXT,
	"ObjectiveCode"	TEXT,
	"NpmCode"	TEXT,
	"ProgramProjectCode"	TEXT,
	PRIMARY KEY("AccountId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "WorkForceData" (
	"WorkforceDataId"	INTEGER NOT NULL,
	"EmployeeNumber"	TEXT NOT NULL DEFAULT NA,
	"FirstName"	TEXT NOT NULL DEFAULT NA,
	"LastName"	TEXT NOT NULL DEFAULT NA,
	"ServiceDate"	TEXT NOT NULL DEFAULT NA,
	"HireDate"	TEXT NOT NULL DEFAULT NA,
	"JobTitle"	TEXT NOT NULL DEFAULT NA,
	"OccupationalSeries"	TEXT NOT NULL DEFAULT NA,
	"HumanResourceOrganizationCode"	TEXT NOT NULL DEFAULT NA,
	"HumanResourceOrganizationName"	TEXT NOT NULL DEFAULT NA,
	"Grade"	TEXT NOT NULL DEFAULT NA,
	"Step"	TEXT NOT NULL DEFAULT NA,
	"GradeEntryDate"	TEXT NOT NULL DEFAULT NA,
	"StepEntryDate"	TEXT NOT NULL DEFAULT NA,
	"WigiDueDate"	TEXT NOT NULL DEFAULT NA,
	"AppointmentAuthority"	TEXT NOT NULL DEFAULT NA,
	"AppointmentType"	TEXT NOT NULL DEFAULT NA,
	"BargainingUnit"	TEXT NOT NULL DEFAULT NA,
	"EmployeeStatus"	TEXT NOT NULL DEFAULT NA,
	"RetirementPlan"	TEXT NOT NULL DEFAULT NA,
	"CompensationRate"	NUMERIC NOT NULL DEFAULT 0.0,
	PRIMARY KEY("WorkforceDataId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "InformationTechnology" (
	"Code"	TEXT,
	"CostAreaCode"	TEXT,
	"CostAreaName"	TEXT,
	"ProjectCode"	TEXT,
	"ProjectName"	TEXT
);
CREATE TABLE IF NOT EXISTS "Allocations" (
	"PrcId"	INTEGER NOT NULL,
	"BudgetLevel"	TEXT NOT NULL DEFAULT NA,
	"RPIO"	TEXT NOT NULL DEFAULT NA,
	"BFY"	TEXT NOT NULL DEFAULT NA,
	"FundCode"	TEXT NOT NULL DEFAULT NA,
	"AhCode"	TEXT NOT NULL DEFAULT NA,
	"OrgCode"	TEXT NOT NULL DEFAULT NA,
	"RcCode"	TEXT NOT NULL DEFAULT NA,
	"AccountCode"	TEXT NOT NULL DEFAULT NA,
	"BocCode"	TEXT NOT NULL DEFAULT NA,
	"Amount"	REAL DEFAULT 0,
	"FundName"	TEXT NOT NULL DEFAULT NA,
	"BocName"	TEXT NOT NULL DEFAULT NA,
	"Division"	TEXT NOT NULL DEFAULT NA,
	"DivisionName"	TEXT NOT NULL DEFAULT NA,
	"ActivityCode"	TEXT NOT NULL DEFAULT NA,
	"NpmName"	TEXT NOT NULL DEFAULT NA,
	"NpmCode"	TEXT NOT NULL DEFAULT NA,
	"ProgramProjectCode"	TEXT NOT NULL DEFAULT NA,
	"ProgramProjectName"	TEXT NOT NULL DEFAULT NA,
	"ProgramAreaCode"	TEXT NOT NULL DEFAULT NA,
	"ProgramAreaName"	TEXT NOT NULL DEFAULT NA,
	"GoalCode"	TEXT NOT NULL DEFAULT NA,
	"GoalName"	TEXT NOT NULL DEFAULT NA,
	"ObjectiveCode"	TEXT NOT NULL DEFAULT NA,
	"ObjectiveName"	TEXT,
	PRIMARY KEY("PrcId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Reimbursables" (
	"ReimbursableId"	INTEGER NOT NULL,
	"RpioCode"	TEXT NOT NULL DEFAULT NA,
	"BFY"	TEXT NOT NULL DEFAULT NA,
	"FundCode"	TEXT NOT NULL DEFAULT NA,
	"AgreementNumber"	TEXT NOT NULL DEFAULT NA,
	"RcCode"	TEXT NOT NULL DEFAULT NA,
	"OrgCode"	TEXT NOT NULL DEFAULT NA,
	"AccountCode"	TEXT NOT NULL DEFAULT NA,
	"BocCode"	TEXT NOT NULL DEFAULT NA,
	"Authority"	NUMERIC DEFAULT 0.0,
	"OpenCommitments"	NUMERIC DEFAULT 0.0,
	"ULO"	NUMERIC DEFAULT 0.0,
	"Expenditures"	NUMERIC DEFAULT 0.0,
	PRIMARY KEY("ReimbursableId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Transfers" (
	"TransferId"	INTEGER NOT NULL,
	"BudgetLevel"	TEXT NOT NULL DEFAULT NA,
	"DocType"	TEXT NOT NULL DEFAULT NA,
	"BFY"	TEXT NOT NULL DEFAULT NA,
	"RpioCode"	TEXT NOT NULL DEFAULT '06',
	"FundCode"	TEXT NOT NULL DEFAULT NA,
	"DocumentNumber"	TEXT NOT NULL DEFAULT NA,
	"ProcessedDate"	TEXT NOT NULL DEFAULT NA,
	"AhCode"	TEXT NOT NULL DEFAULT NA,
	"OrgCode"	TEXT NOT NULL DEFAULT NA,
	"RcCode"	TEXT NOT NULL DEFAULT NA,
	"AccountCode"	TEXT NOT NULL DEFAULT NA,
	"ProgramAreaCode"	TEXT NOT NULL DEFAULT NA,
	"ProgramProjectCode"	TEXT NOT NULL DEFAULT NA,
	"ResourceType"	TEXT NOT NULL DEFAULT NA,
	"Line"	TEXT NOT NULL DEFAULT NA,
	"Subline"	TEXT NOT NULL DEFAULT NA,
	"FromTo"	TEXT NOT NULL DEFAULT NA,
	"BocCode"	TEXT NOT NULL DEFAULT NA,
	"Amount"	NUMERIC DEFAULT 0.0,
	"Purpose"	TEXT DEFAULT NA,
	PRIMARY KEY("TransferId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "WorkCodes" (
	"WorkCodeId"	INTEGER NOT NULL,
	"RpioCode"	TEXT NOT NULL DEFAULT NA,
	"WorkCode"	TEXT NOT NULL DEFAULT NA,
	"WorkCodeName"	TEXT NOT NULL DEFAULT NA,
	"ChargeType"	TEXT NOT NULL DEFAULT NA,
	"Notifications"	TEXT NOT NULL DEFAULT NA,
	"PayPeriod"	TEXT NOT NULL DEFAULT NA,
	"BFY"	TEXT NOT NULL DEFAULT NA,
	"ApproverUserName"	TEXT NOT NULL DEFAULT NA,
	"ApprovedDate"	TEXT NOT NULL DEFAULT NA,
	"ModifierUserName"	TEXT NOT NULL DEFAULT NA,
	"ModifiedDate"	TEXT NOT NULL DEFAULT NA,
	"FundCode"	TEXT NOT NULL DEFAULT NA,
	"FocCode"	TEXT NOT NULL DEFAULT NA,
	"CostOrgCode"	TEXT NOT NULL DEFAULT NA,
	"CostOrgName"	TEXT NOT NULL DEFAULT NA,
	"RcCode"	TEXT NOT NULL DEFAULT NA,
	"AccountCode"	TEXT NOT NULL DEFAULT NA,
	"WorkProjectCode"	TEXT NOT NULL DEFAULT NA,
	"WorkProjectName"	TEXT NOT NULL DEFAULT NA,
	"Percentage"	NUMERIC NOT NULL DEFAULT 0.0,
	PRIMARY KEY("WorkCodeId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "LeaveProjections" (
	"LeaveProjectionId"	INTEGER NOT NULL,
	"RpioCode"	TEXT NOT NULL DEFAULT NA,
	"EmployeeNumber"	TEXT NOT NULL DEFAULT NA,
	"FirstName"	TEXT NOT NULL DEFAULT NA,
	"LastName"	TEXT NOT NULL DEFAULT NA,
	"HumanResourceOrganizationCode"	TEXT NOT NULL DEFAULT NA,
	"HumanResourceOrganizationName"	TEXT NOT NULL DEFAULT NA,
	"WorkCode"	TEXT NOT NULL DEFAULT NA,
	"YearToDateEarned"	NUMERIC DEFAULT 0.0,
	"YearToDateUsed"	NUMERIC DEFAULT 0.0,
	"MaxLeaveCarryover"	NUMERIC DEFAULT 0.0,
	"MaxCarryoverExcess"	NUMERIC DEFAULT 0.0,
	"UseOrLose"	NUMERIC DEFAULT 0.0,
	"ProjectedPayPeriod"	NUMERIC DEFAULT 0.0,
	"ProjectedAnnual"	NUMERIC DEFAULT 0.0,
	"AvailableHours"	NUMERIC DEFAULT 0.0,
	PRIMARY KEY("LeaveProjectionId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Activity" (
	"ActivityId"	INTEGER NOT NULL,
	"Code"	TEXT NOT NULL,
	"Name"	TEXT,
	"Title"	TEXT,
	PRIMARY KEY("ActivityId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "AllowanceHolders" (
	"AllowanceHolderId"	INTEGER NOT NULL,
	"Code"	TEXT NOT NULL,
	"Name"	TEXT,
	PRIMARY KEY("AllowanceHolderId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Appropriations" (
	"AppropriationId"	INTEGER NOT NULL UNIQUE,
	"Code"	TEXT NOT NULL,
	"Name"	TEXT,
	"Title"	TEXT,
	PRIMARY KEY("AppropriationId")
);
CREATE TABLE IF NOT EXISTS "BudgetObjectClass" (
	"BudgetObjectClassId"	INTEGER NOT NULL,
	"Code"	TEXT NOT NULL,
	"Name"	TEXT,
	PRIMARY KEY("BudgetObjectClassId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "AppropriationBills" (
	"ID"	INTEGER NOT NULL,
	"BFY"	TEXT,
	"Title"	TEXT,
	"PublicLaw"	TEXT,
	"EnactedDate"	TEXT,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "HumanResourceOrganizations" (
	"HumanResourceOrganizationId"	INTEGER,
	"RcCode"	TEXT,
	"HumanResourceOrganizationCode"	TEXT,
	"HumanResourceOrganizationName"	TEXT
);
CREATE TABLE IF NOT EXISTS "Employees" (
	"EmployeeId"	INTEGER NOT NULL,
	"FirstName"	TEXT,
	"LastName"	TEXT,
	"Section"	TEXT,
	"Email"	TEXT,
	"Office"	TEXT,
	"PhoneNumber"	TEXT,
	"CellNumber"	TEXT,
	"Status"	TEXT,
	PRIMARY KEY("EmployeeId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "ControlNumbers" (
	"ControlNumberId"	INTEGER NOT NULL UNIQUE,
	"BFY"	TEXT NOT NULL DEFAULT 2019,
	"RPIO"	TEXT NOT NULL DEFAULT 06,
	"AhCode"	TEXT DEFAULT 06,
	"RegionControlNumber"	INTEGER,
	"FundCode"	TEXT NOT NULL,
	"FundControlNumber"	INTEGER,
	"RcCode"	TEXT,
	"DivisionName"	TEXT,
	"DivisionControlNumber"	INTEGER,
	"DateIssued"	TEXT NOT NULL,
	PRIMARY KEY("ControlNumberId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "ProgramProjects" (
	"ProgramProjectId"	INTEGER NOT NULL,
	"Code"	TEXT,
	"Name"	TEXT,
	"Title"	TEXT,
	"Laws"	TEXT,
	"Narrative"	TEXT,
	"Definition"	TEXT,
	"ProgramAreaCode"	TEXT,
	"ProgramAreaName"	TEXT,
	PRIMARY KEY("ProgramProjectId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "FinanceObjectClass" (
	"FinanceObjectClassId"	INTEGER NOT NULL,
	"Code"	TEXT NOT NULL,
	"Name"	TEXT,
	PRIMARY KEY("FinanceObjectClassId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "ResponsibilityCenters" (
	"ResponsibilityCenterId"	INTEGER NOT NULL,
	"Code"	TEXT NOT NULL,
	"Name"	TEXT,
	"Title"	TEXT,
	PRIMARY KEY("ResponsibilityCenterId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Funds" (
	"FundId"	INTEGER NOT NULL UNIQUE,
	"Code"	TEXT NOT NULL,
	"Name"	TEXT,
	"TreasurySymbol"	TEXT,
	"Title"	TEXT,
	PRIMARY KEY("FundId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Supplemental" (
	"SupplementalId"	INTEGER NOT NULL UNIQUE,
	"Type"	TEXT,
	"RcCode"	TEXT NOT NULL,
	"FundCode"	TEXT,
	"BFY"	TEXT,
	"BocCode"	TEXT,
	"BocName"	TEXT,
	"Amount"	NUMERIC,
	"Time"	TEXT,
	PRIMARY KEY("SupplementalId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "NationalPrograms" (
	"NationalProgramId"	INTEGER NOT NULL UNIQUE,
	"Code"	TEXT NOT NULL,
	"Name"	TEXT,
	"RpioCode"	TEXT,
	"Title"	TEXT,
	PRIMARY KEY("NationalProgramId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Organizations" (
	"OrganizationId"	INTEGER NOT NULL UNIQUE,
	"Code"	TEXT NOT NULL,
	"Name"	TEXT,
	PRIMARY KEY("OrganizationId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "ResourcePlanningOffices" (
	"ResourcePlanningOfficeId"	INTEGER NOT NULL UNIQUE,
	"Code"	TEXT NOT NULL,
	"Name"	TEXT,
	PRIMARY KEY("ResourcePlanningOfficeId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Divisions" (
	"DivisionId"	INTEGER NOT NULL UNIQUE,
	"Code"	TEXT NOT NULL,
	"Name"	TEXT,
	"Caption"	TEXT,
	"Title"	TEXT,
	PRIMARY KEY("DivisionId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Objectives" (
	"ObjectiveId"	INTEGER NOT NULL UNIQUE,
	"Code"	TEXT NOT NULL,
	"Name"	TEXT,
	"Title"	TEXT,
	PRIMARY KEY("ObjectiveId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Goals" (
	"GoalId"	INTEGER NOT NULL UNIQUE,
	"Code"	TEXT NOT NULL,
	"Name"	TEXT,
	"Title"	TEXT,
	PRIMARY KEY("GoalId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "ProgramAreas" (
	"ProgramAreaId"	INTEGER NOT NULL UNIQUE,
	"Code"	TEXT NOT NULL,
	"Name"	TEXT,
	PRIMARY KEY("ProgramAreaId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Projects" (
	"ProjectId"	INTEGER NOT NULL UNIQUE,
	"Code"	TEXT NOT NULL,
	"Name"	TEXT,
	PRIMARY KEY("ProjectId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Outlays" (
	"OutlayId"	INTEGER NOT NULL UNIQUE,
	"BudgetLevel"	TEXT NOT NULL DEFAULT 'NS',
	"RpioCode"	TEXT NOT NULL DEFAULT 'NS',
	"BFY"	TEXT NOT NULL DEFAULT 'NS',
	"FundCode"	TEXT NOT NULL DEFAULT 'NS',
	"AhCode"	TEXT NOT NULL DEFAULT 'NS',
	"OrgCode"	TEXT NOT NULL DEFAULT 'NS',
	"RcCode"	TEXT NOT NULL DEFAULT 'NS',
	"AccountCode"	TEXT NOT NULL DEFAULT 'NS',
	"BocCode"	TEXT NOT NULL DEFAULT 'NS',
	"Authority"	NUMERIC NOT NULL DEFAULT 0.0,
	"Budgeted"	NUMERIC NOT NULL DEFAULT 0.0,
	"Posted"	NUMERIC NOT NULL DEFAULT 0.0,
	"CarryIn"	NUMERIC NOT NULL DEFAULT 0.0,
	"CarryOut"	NUMERIC NOT NULL DEFAULT 0.0,
	"Commitments"	NUMERIC NOT NULL DEFAULT 0.0,
	"OpenCommitments"	NUMERIC NOT NULL DEFAULT 0.0,
	"Obligations"	NUMERIC NOT NULL DEFAULT 0.0,
	"ULO"	NUMERIC NOT NULL DEFAULT 0.0,
	"Balance"	NUMERIC NOT NULL DEFAULT 0.0,
	"NpmCode"	TEXT NOT NULL DEFAULT 'NS',
	"ProgramProjectCode"	TEXT NOT NULL DEFAULT 'NS',
	"ProgramAreaCode"	TEXT NOT NULL DEFAULT 'NS',
	PRIMARY KEY("OutlayId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Purchases" (
	"PurchaseId"	INTEGER NOT NULL UNIQUE,
	"BFY"	TEXT NOT NULL DEFAULT 'NS',
	"RpioCode"	TEXT NOT NULL DEFAULT 'NS',
	"AhCode"	TEXT NOT NULL DEFAULT 'NS',
	"FundCode"	TEXT NOT NULL DEFAULT 'NS',
	"OrgCode"	TEXT NOT NULL DEFAULT 'NS',
	"RcCode"	TEXT NOT NULL DEFAULT 'NS',
	"BocCode"	TEXT NOT NULL DEFAULT 'NS',
	"AccountCode"	TEXT NOT NULL DEFAULT 'NS',
	"ActivityCode"	TEXT NOT NULL DEFAULT 'NS',
	"Commitments"	NUMERIC DEFAULT 0.00,
	"OpenCommitments"	NUMERIC DEFAULT 0.00,
	"Obligations"	NUMERIC DEFAULT 0.00,
	"ULO"	NUMERIC DEFAULT 0.00,
	"Deobligations"	NUMERIC DEFAULT 0.00,
	"Expenditures"	NUMERIC DEFAULT 0.00,
	"NpmCode"	TEXT NOT NULL DEFAULT 'NS',
	"FocCode"	TEXT NOT NULL DEFAULT 'NS',
	"FocName"	TEXT NOT NULL DEFAULT 'NS',
	"System"	TEXT NOT NULL DEFAULT 'NS',
	"DocumentType"	TEXT NOT NULL DEFAULT 'NS',
	"DocumentPrefix"	TEXT NOT NULL DEFAULT 'NS',
	"DocumentControlNumber"	TEXT NOT NULL DEFAULT 'NS',
	"PurchaseRequest"	TEXT NOT NULL DEFAULT 'NS',
	"GrantNumber"	TEXT NOT NULL DEFAULT 'NS',
	"ObligatingDocumentNumber"	TEXT NOT NULL DEFAULT 'NS',
	"ReimbursableAgreementNumber"	TEXT NOT NULL DEFAULT 'NS',
	"SiteProjectCode"	TEXT NOT NULL DEFAULT 'NS',
	"TransactionNumber"	TEXT NOT NULL DEFAULT 'NS',
	"OriginalActionDate"	TEXT NOT NULL DEFAULT 'NS',
	PRIMARY KEY("PurchaseId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "FiscalYears" (
	"FiscalYearId"	INTEGER,
	"BBFY"	INTEGER,
	"EBFY"	INTEGER,
	"FirstYear"	INTEGER,
	"LastYear"	INTEGER,
	"ExpiringYear"	INTEGER,
	"StartDate"	TEXT,
	"EndDate"	TEXT,
	"Availability"	TEXT,
	"Columbus"	TEXT,
	"Thanksgiving"	TEXT,
	"Christmas"	TEXT,
	"NewYears"	TEXT,
	"MartinLutherKing"	TEXT,
	"Presidents"	TEXT,
	"Memorial"	TEXT,
	"Veterans"	TEXT,
	"Labor"	TEXT,
	"WorkDays"	INTEGER,
	"WeekDays"	INTEGER,
	"WeekEnds"	INTEGER
);
CREATE TABLE IF NOT EXISTS "Procurements" (
	"ProcurementId"	INTEGER,
	"DocumentType"	TEXT NOT NULL DEFAULT NS,
	"DocumentNumber"	TEXT NOT NULL DEFAULT NS,
	"DocumentDate"	TEXT NOT NULL DEFAULT NS,
	"Title"	TEXT NOT NULL DEFAULT NS,
	"RequestedBy"	TEXT NOT NULL DEFAULT NS,
	"CreatedBy"	TEXT NOT NULL DEFAULT NS,
	"ModifiedBy"	TEXT NOT NULL DEFAULT NS,
	"RequestDate"	TEXT NOT NULL DEFAULT NS,
	"LastActionDate"	TEXT NOT NULL DEFAULT NS,
	"ProcessedDate"	TEXT NOT NULL DEFAULT NS,
	"BFY"	TEXT NOT NULL DEFAULT NS,
	"SecurityOrg"	TEXT NOT NULL DEFAULT NS,
	"ClosedDate"	TEXT NOT NULL DEFAULT NS,
	"VendorCode"	TEXT NOT NULL DEFAULT NS,
	"VendorName"	TEXT NOT NULL DEFAULT NS,
	"Description"	TEXT NOT NULL DEFAULT NS,
	"FundCode"	TEXT NOT NULL DEFAULT NS,
	"AhCode"	TEXT NOT NULL DEFAULT NS,
	"OrgCode"	TEXT NOT NULL DEFAULT NS,
	"OrgName"	TEXT NOT NULL DEFAULT NS,
	"AccountCode"	TEXT NOT NULL DEFAULT NS,
	"RcCode"	TEXT NOT NULL DEFAULT NS,
	"BocCode"	TEXT NOT NULL DEFAULT NS,
	"FocCode"	TEXT NOT NULL DEFAULT NS,
	"ProjectCode"	TEXT NOT NULL DEFAULT NS,
	"DocumentPrefix"	TEXT NOT NULL DEFAULT NS,
	"DocumentControlNumber"	TEXT NOT NULL DEFAULT NS,
	"Ordered"	FLOAT NOT NULL DEFAULT 0.0,
	"Closed"	FLOAT NOT NULL DEFAULT 0.0,
	"Expended"	FLOAT NOT NULL DEFAULT 0.0,
	PRIMARY KEY("ProcurementId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "PayrollHours" (
	"PayrollHoursId"	INTEGER NOT NULL UNIQUE,
	"RpioCode"	TEXT NOT NULL DEFAULT NS,
	"PayPeriod"	TEXT NOT NULL DEFAULT NS,
	"StartDate"	TEXT NOT NULL DEFAULT NS,
	"EndDate"	TEXT NOT NULL DEFAULT NS,
	"EmployeeNumber"	TEXT NOT NULL DEFAULT NS,
	"EmployeeFirstName"	TEXT NOT NULL DEFAULT NS,
	"EmployeeLastName"	TEXT NOT NULL DEFAULT NS,
	"Date"	TEXT NOT NULL DEFAULT NS,
	"HumanResourceOrganizationCode"	TEXT NOT NULL DEFAULT NS,
	"HumanResourceOrganizationCodeName"	TEXT NOT NULL DEFAULT NS,
	"ReportingCode"	TEXT NOT NULL DEFAULT NS,
	"ReportingCodeDescription"	TEXT NOT NULL DEFAULT NS,
	"ApprovalDate"	TEXT NOT NULL DEFAULT NS,
	"WorkCode"	TEXT NOT NULL DEFAULT NS,
	"Hours"	NUMERIC NOT NULL DEFAULT 0.0,
	PRIMARY KEY("PayrollHoursId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "FullTimeUtilization" (
	"FullTimeUtilizationId"	INTEGER NOT NULL,
	"BudgetLevel"	INTEGER NOT NULL DEFAULT 7,
	"RpioCode"	TEXT NOT NULL DEFAULT 06,
	"BFY"	TEXT NOT NULL DEFAULT 'NS',
	"FundCode"	TEXT NOT NULL DEFAULT 'NS',
	"NpmCode"	TEXT NOT NULL DEFAULT 'NS',
	"AhCode"	TEXT NOT NULL DEFAULT 'NS',
	"OrgCode"	TEXT NOT NULL DEFAULT 'NS',
	"RcCode"	TEXT NOT NULL DEFAULT 'NS',
	"AccountCode"	TEXT NOT NULL DEFAULT 'NS',
	"ProgramProjectCode"	TEXT NOT NULL DEFAULT 'NS',
	"ProgramAreaCode"	TEXT NOT NULL DEFAULT 'NS',
	"Allocation"	REAL DEFAULT 0.0,
	"Expended"	REAL DEFAULT 0.0,
	"Available"	REAL DEFAULT 0.0,
	PRIMARY KEY("FullTimeUtilizationId")
);
CREATE TABLE IF NOT EXISTS "Documents" (
	"DocumentId"	INTEGER NOT NULL,
	"Code"	TEXT NOT NULL DEFAULT 'NS',
	"Category"	TEXT NOT NULL DEFAULT 'NS',
	"Name"	TEXT NOT NULL DEFAULT 'NS',
	"System"	TEXT NOT NULL DEFAULT 'NS',
	PRIMARY KEY("DocumentId" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "AccountingEvents" (
	"AccountingEventId"	INTEGER NOT NULL,
	"Code"	TEXT NOT NULL DEFAULT 'NS',
	"Name"	TEXT NOT NULL DEFAULT 'NS',
	PRIMARY KEY("AccountingEventId" AUTOINCREMENT)
);
CREATE VIEW "PRC" 
AS SELECT * 
FROM 
    Allocations
WHERE 
    Allocations.Amount <> 0;
CREATE VIEW "XA" 
AS SELECT PrcId, BudgetLevel, BFY, FundCode, AhCode, OrgCode, AccountCode, ActivityCode, RcCode, BocCode, Amount 
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06X' AND
    Allocations.Amount <> 0 AND 
    Allocations.BudgetLevel = '8';
CREATE VIEW "LCARD" 
AS SELECT PrcId, BudgetLevel, BFY, FundCode, AhCode, OrgCode, AccountCode, ActivityCode, RcCode, BocCode, Amount 
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06B' AND
    Allocations.Amount <> 0 AND 
    Allocations.BudgetLevel = '8';
CREATE VIEW "LSASD" 
AS SELECT PrcId, BudgetLevel, BFY, FundCode, AhCode, OrgCode, AccountCode, ActivityCode, RcCode, BocCode, Amount 
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06H' AND
    Allocations.Amount <> 0 AND 
    Allocations.BudgetLevel = '8';
CREATE VIEW "WD"
AS SELECT PrcId, BudgetLevel, BFY, FundCode, AhCode, OrgCode, AccountCode, ActivityCode, RcCode, BocCode, Amount 
FROM Allocations
WHERE RcCode = '06K' AND
	BudgetLevel = '8' AND
	Amount <> 0.0;
CREATE VIEW "ExecutionLevel8" AS
SELECT
    OutlayId,
    BudgetLevel,
    RpioCode,
    BFY,
    FundCode,
	CASE 
	WHEN AhCode LIKE '6A%' THEN '6A'
	ELSE AhCode
	END AhCode,
    OrgCode,
    AccountCode,
	CASE
	WHEN RcCode LIKE '6A%' AND
		FundCode LIKE 'T%' THEN '06L'
	WHEN length(RcCode) = 3 AND 
		RcCode NOT LIKE '6A%' THEN RcCode
	ELSE RcCode
	END RcCode, 
    BocCode,
    Authority,
	Budgeted,
	Posted,
	CarryIn,
	CarryOut,
	Commitments,
	OpenCommitments,
    Obligations,
	ULO,
    Balance,
    NpmCode,
    ProgramProjectCode,
    ProgramAreaCode
FROM
    Outlays
WHERE 
    BudgetLevel = '8' AND
    FundCode IN ('B', 'T', 'F', 'H', 'ZL') AND
    BocCode != '17' AND
    Authority > 0
GROUP BY 
    AhCode, BFY, FundCode, AccountCode, OrgCode, BocCode, RcCode;
CREATE VIEW "ExecutionLevel7"
AS SELECT
    OutlayId,
    BudgetLevel,
    RpioCode,
    BFY,
    FundCode,
	CASE
	WHEN AhCode LIKE '6A%' THEN '6A'
	WHEN AhCode LIKE '0600%' THEN '06'
	ELSE AhCode
	END AhCode,
	CASE
	WHEN AhCode LIKE '0600%' THEN AhCode
	WHEN AhCode LIKE '6A%'  THEN AhCode
	ELSE OrgCode
    END OrgCode,
    AccountCode,
    CASE
	WHEN FundCode LIKE 'E%' AND
        NpmCode = 'A' THEN '06J'
	WHEN FundCode LIKE 'E%' AND
        NpmCode = 'C' THEN '06B'
	WHEN FundCode LIKE 'E%' AND
        ProgramProjectCode = '15' THEN '06F'
	WHEN FundCode LIKE 'E%' AND
        NpmCode IN ('C') THEN '06B'
	WHEN FundCode LIKE 'E%' AND
        NpmCode = 'E' THEN '06M'			
	WHEN FundCode LIKE 'E%' AND
        NpmCode = 'B' THEN '06K'
	WHEN FundCode LIKE 'E%' AND
        (NpmCode = 'D' AND AccountCode LIKE '%11') THEN '06B'
	WHEN FundCode LIKE 'E%' AND
        (NpmCode = 'D' AND ProgramProjectCode IN ('79', '24')) THEN '06L'
	WHEN FundCode = 'T' AND
        OrgCode LIKE '6A%' OR
        AhCode LIKE '6A%' THEN '06L'
	WHEN FundCode LIKE 'TR%' THEN '06L'
	END RcCode,
    BocCode,
    Authority,
    Budgeted,
    Posted,
    CarryIn,
    CarryOut,
    Commitments,
    OpenCommitments,
    Obligations,
    ULO,
    Balance,
    NpmCode,
    ProgramProjectCode,
    ProgramAreaCode
FROM
    Outlays
WHERE BudgetLevel = 7 AND
    BocCode NOT IN ('10', '17', '21', '28') AND
    (FundCode LIKE 'E%' OR
    FundCode LIKE 'TR%') AND
    Authority > 0
GROUP BY 
    RpioCode, BFY, FundCode, AhCode, OrgCode, AccountCode, BocCode, RcCode
HAVING RcCode IS NOT NULL;
CREATE VIEW "Reprogrammings" AS SELECT TransferId, RpioCode, BudgetLevel, DocumentNumber, AhCode, OrgCode, RcCode, FundCode, BFY, AccountCode, FromTo, CASE WHEN FromTo = 'TO' THEN 'Increase' WHEN FromTo = 'FROM' THEN 'Decrease' END Net, BocCode, CASE WHEN FromTo = 'TO' THEN (Amount) WHEN FromTo = 'FROM' THEN (Amount * -1) END Amount, ProcessedDate, Purpose FROM Transfers GROUP BY DocumentNumber, ProcessedDate, AccountCode, BocCode, FromTo;
CREATE VIEW "NetTransfers" AS SELECT RpioCode, BFY, BudgetLevel, FundCode, AhCode, OrgCode, RcCode, AccountCode, BocCode, Amount, Net, ProcessedDate, DocumentNumber, Purpose FROM Reprogrammings GROUP BY DocumentNumber, FundCode, AhCode, OrgCode, RcCode, AccountCode, BocCode ORDER BY BFY DESC;
CREATE VIEW "NewObligationalAuthority" AS
SELECT * 
FROM Allocations
WHERE BFY = '2020';
CREATE VIEW "Carryover" AS
SELECT * 
FROM Allocations
WHERE BFY = '2019';
CREATE VIEW "StatusOfFunds" AS
SELECT OutlayId, BudgetLevel, BFY, FundCode, AhCode, OrgCode, 
    CASE
        WHEN FundCode LIKE 'E%' AND 
            NpmCode = 'A' THEN '06J'	
        WHEN FundCode LIKE 'E%' AND 
            NpmCode = 'B' THEN '06K'
        WHEN FundCode LIKE 'E%' AND 
            NpmCode IN ('D', 'C') THEN '06B'
        WHEN FundCode = 'T' AND 
            OrgCode LIKE '6A%' OR 
            AhCode LIKE '6A%' THEN '06L'
        WHEN FundCode LIKE 'TR%' THEN '06L'
        WHEN FundCode LIKE 'E%' AND 
            NpmCode = 'E' THEN '06M'
        WHEN FundCode LIKE 'E%' AND 
            NpmCode = 'L' THEN '06F'
		WHEN BudgetLevel = '7' AND 
			FundCode IN ('H', 'HR', 'HD', 'B', 'T', 'TD', 'TS3', 'F', 'FD', 'FR', 'FS3', 'ZL') THEN AhCode
		WHEN BudgetLevel = '8' AND 
			length(OrgCode) = 3 THEN OrgCode
    END RcCode, 
    AccountCode, BocCode, Authority, Budgeted, Posted, CarryIn, CarryOut, Commitments, OpenCommitments, Obligations, ULO, Balance 
FROM Outlays 
WHERE (Authority <> 0)
GROUP BY BFY, AhCode, FundCode, AccountCode, BocCode, RcCode;
CREATE VIEW "BudgetLevels" AS
SELECT OutlayId, BudgetLevel, BFY, FundCode, AhCode, OrgCode, 
    CASE
		WHEN BocCode IN ('10', '17') THEN '06'
        WHEN FundCode LIKE 'E%' AND 
            NpmCode = 'A' THEN '06J'	
        WHEN FundCode LIKE 'E%' AND 
            NpmCode = 'B' THEN '06K'
        WHEN FundCode LIKE 'E%' AND 
            NpmCode = 'C' THEN '06B'
        WHEN FundCode LIKE 'E%' AND 
            ProgramProjectCode = '11' THEN '06B'
        WHEN FundCode LIKE 'E%' AND 
            ProgramProjectCode IN ('24', '79') THEN '06L'
        WHEN FundCode = 'T' AND 
            OrgCode LIKE '6A%' OR 
            AhCode LIKE '6A%' THEN '06L'
		WHEN FundCode LIKE 'ZL%' THEN '06K'
        WHEN FundCode LIKE 'TR%' THEN '06L'
        WHEN FundCode LIKE 'E%' AND 
            NpmCode = 'E' THEN '06M'
        WHEN FundCode LIKE 'E%' AND 
            NpmCode = 'L' THEN '06F'
		WHEN BudgetLevel = '7' AND
			FundCode = 'B' THEN '06'
		WHEN BudgetLevel = '7' AND
			FundCode = 'T' AND
			AhCode = '06' THEN '06'
		WHEN BudgetLevel = '8' AND
			FundCode IN ('B', 'T', 'H', 'F') AND
			length(RcCode) = 3 THEN RcCode
    END RcCode, 
    AccountCode, BocCode, Authority, Budgeted, Posted, CarryIn, CarryOut, Commitments, OpenCommitments, Obligations, ULO, Balance 
FROM Outlays 
WHERE 
	Authority <> 0 AND
	BocCode <> '10'
GROUP BY BFY, FundCode, AccountCode, BocCode, OrgCode, AhCode, RcCode;
CREATE VIEW "FTE" AS SELECT *
FROM Allocations WHERE Allocations.BudgetLevel = '8' AND 
	Allocations.Amount <> 0 AND
	BocCode = '17';
CREATE VIEW "TimeOff" 
AS SELECT *
FROM 
    Supplemental
WHERE 
    Type = 'TIMEOFF' AND 
    TIME != 0;
CREATE VIEW "Overtime" 
AS SELECT *
FROM 
    Supplemental
WHERE 
    Type = 'OVERTIME';
CREATE VIEW "Awards" 
AS SELECT *
FROM 
    Supplemental
WHERE 
    Type = 'MONETARY';
CREATE VIEW "RegionExecution" AS
SELECT BFY, BudgetLevel, FundCode, AhCode, OrgCode, AccountCode, 
	CASE 
	
	-- Water Division  
	WHEN AhCode == '6A%' THEN '06'
	WHEN AhCode != '6A' THEN '06'
	END RcCode, 
	BocCode, SUM(Commitments) AS Commitments, SUM(OpenCommitments) AS OpenCommitments, SUM(Obligations) AS Obligations, SUM(ULO) AS ULO 
FROM Outlays
WHERE BudgetLevel = '7' AND 
	(Commitments > 0 OR OpenCommitments > 0 OR Obligations > 0 OR ULO > 0)
GROUP BY BFY, FundCode, AhCode, AccountCode, OrgCode, BocCode, RcCode, BudgetLevel;
CREATE VIEW "RegionAuthority" AS 
SELECT BFY, BudgetLevel, FundCode, AhCode, OrgCode,
CASE
	WHEN AccountCode LIKE '%W%' THEN substr(AccountCode, 1, 6) ELSE AccountCode
END AccountCode, RcCode, Amount, NpmCode, ProgramProjectCode, ProgramAreaCode
FROM Allocations
WHERE BudgetLevel = '7' AND Amount > 0
GROUP BY BFY, FundCode, AhCode, AccountCode, OrgCode, BocCode, RcCode, BudgetLevel;
CREATE VIEW "DivisionAuthority" AS 
SELECT BFY, BudgetLevel, FundCode, AhCode, OrgCode, 
CASE 
	WHEN AccountCode LIKE '%W%' THEN substr(AccountCode, 1, 6) ELSE AccountCode
END AccountCode, RcCode, BocCode, Amount, NpmCode, ProgramProjectCode, ProgramAreaCode
FROM Allocations
WHERE BudgetLevel = '8' AND Amount > 0
GROUP BY BFY, FundCode, AhCode, AccountCode, OrgCode, BocCode, RcCode, BudgetLevel;
CREATE VIEW "Schema" AS 
SELECT * FROM sqlite_master
WHERE type IN ('table', 'view');
CREATE VIEW "PurchaseActivity" AS
SELECT RpioCode as RPIO, (SELECT '8') as BudgetLevel, BFY, FundCode, AhCode, OrgCode, REPLACE(AccountCode, 'X', ' ') AS AccountCode, NpmCode,
	DocumentControlNumber, PurchaseRequest, GrantNumber, TransactionNumber, BocCode, FocCode, FocName, SiteProjectCode, OriginalActionDate,
	
	-- Water Division  
	CASE
	WHEN OrgCode IN ('061K', '062K', '063K', '064K', '065K') THEN '06K'
	WHEN OrgCode LIKE '06_K%' THEN '06K'
	WHEN OrgCode LIKE '06K%' THEN '06K'
	WHEN FundCode LIKE 'E_%' AND
		 NpmCode = 'B' THEN '06K'
	WHEN AccountCode IN ('000B01', '000B03', '000B06', '000B06XP1', '000B08') THEN '06K'
	
	-- Air And Radiation Division 
	WHEN OrgCode LIKE '06J%' AND 
		 FundCode IN ('E1', 'E2', 'E3', 'E4') AND
		 NpmCode != 'E' THEN '06J'
	WHEN AccountCode IN ('000A04', '000A05', '000A04XPM', '000A17') THEN '06J'
	WHEN OrgCode LIKE '%06A%' THEN '06A'
	WHEN NpmCode = 'A' AND
		 FundCode LIKE 'E_%' THEN '06J'
	
	-- Land, Chemical, And Revitalization Division
	WHEN AccountCode IN ('000C09', '000C10', '000D11', '000E14', '000E12') AND
		 FundCode IN ('E1', 'E2', 'E3', 'E4') THEN '06B'
	WHEN NpmCode = 'E' AND 
		 FundCode IN ('E1', 'E2', 'E3', 'E4') THEN '06B'
	WHEN OrgCode LIKE '0600%' AND 
		 FundCode LIKE ('E%') THEN '06B'
		 
	-- External Affairs
	WHEN AccountCode IN ('06X', '06AX') THEN '06X'
	
	-- Working Captial FundCode
	WHEN BocCode = '38' THEN '06G'
		
	-- Superfund And Emergency Management
	WHEN OrgCode LIKE '06L%' THEN '06L'
	WHEN OrgCode LIKE '6A%' THEN '06L' 
	WHEN FundCode LIKE ('TR%') THEN '06L'
	WHEN AccountCode LIKE '%___EC7' AND 
		 FundCode = 'T' AND
		 BocCode NOT IN ('10', '17', '38') THEN '06L' ELSE OrgCode
	END RcCode, SUM(Commitments) AS Commitments, SUM(OpenCommitments) AS OpenCommitments, SUM(Obligations) AS Obligations, SUM(ULO) AS ULO, SUM(Expenditures) AS Expenditures
FROM Purchases
WHERE BudgetLevel = '8' AND 
	BocCode NOT IN ('10', '17') AND
	(Commitments > 0 OR OpenCommitments > 0 OR Obligations > 0 OR ULO > 0)
GROUP BY RPIO, BFY, FundCode, AhCode, AccountCode, OrgCode, BocCode, RcCode, BudgetLevel;
CREATE VIEW "Commitments" AS
SELECT PurchaseId as CommitmentId, BFY, (Select 8) as BudgetLevel, RpioCode, AhCode, FundCode, OrgCode, REPLACE(AccountCode, 'X', ' ') AS AccountCode, NpmCode, ActivityCode, 
	
	-- Water Division  
	CASE
	WHEN OrgCode IN ('061K', '062K', '063K', '064K', '065K') THEN '06K'
	WHEN OrgCode LIKE '06_K%' THEN '06K'
	WHEN OrgCode LIKE '06K%' THEN '06K'
	WHEN FundCode LIKE 'E_%' AND
		 NpmCode = 'B' THEN '06K'
	WHEN AccountCode IN ('000B01', '000B03', '000B06', '000B06XP1', '000B08') THEN '06K'
	
	-- Air And Radiation Division 
	WHEN OrgCode LIKE '06J%' AND 
		 FundCode IN ('E1', 'E2', 'E3', 'E4') AND
		 NpmCode != 'E' THEN '06J'
	WHEN AccountCode IN ('000A04', '000A05', '000A04XPM', '000A17') THEN '06J'
	WHEN OrgCode LIKE '%06A%' THEN '06A'
	WHEN NpmCode = 'A' AND
		 FundCode LIKE 'E_%' THEN '06J'
	
	-- Land, Chemical, And Revitalization Division
	WHEN AccountCode IN ('000C09', '000C10', '000D11', '000E14', '000E12') AND
		 FundCode IN ('E1', 'E2', 'E3', 'E4') THEN '06B'
	WHEN NpmCode = 'E' AND 
		 FundCode IN ('E1', 'E2', 'E3', 'E4') THEN '06B'
	WHEN OrgCode LIKE '0600%' AND 
		 FundCode LIKE ('E%') THEN '06B'
		 
	-- External Affairs
	WHEN AccountCode IN ('06X', '06AX') THEN '06X'
	
	-- Working Captial FundCode
	WHEN BocCode = '38' THEN '06G'
		
	-- Superfund And Emergency Management
	WHEN OrgCode LIKE '06L%' THEN '06L'
	WHEN OrgCode LIKE '6A%' THEN '06L' 
	WHEN FundCode LIKE ('TR%') THEN '06L'
	WHEN AccountCode LIKE '%___EC7' AND 
		 FundCode = 'T' AND
		 BocCode NOT IN ('10', '17', '38') THEN '06L' ELSE OrgCode
	END RcCode, BocCode, SUM(Commitments) as Amount, FocCode, UPPER(FocName) as FocName, OriginalActionDate, DocumentControlNumber
FROM Purchases
WHERE Commitments != 0 
GROUP BY BFY, BudgetLevel, RpioCode, AhCode, FundCode, OrgCode, AccountCode, ActivityCode, BocCode, RcCode;
CREATE VIEW "Deobligations" AS
SELECT PurchaseId as DeobligationId, BFY, (Select 8) as BudgetLevel, RpioCode, AhCode, FundCode, OrgCode, REPLACE(AccountCode, 'X', ' ') AS ActivityCode, NpmCode, ActivityCode, 
	
	-- Water Division  
	CASE
	WHEN OrgCode IN ('061K', '062K', '063K', '064K', '065K') THEN '06K'
	WHEN OrgCode LIKE '06_K%' THEN '06K'
	WHEN OrgCode LIKE '06K%' THEN '06K'
	WHEN FundCode LIKE 'E_%' AND
		 NpmCode = 'B' THEN '06K'
	WHEN AccountCode IN ('000B01', '000B03', '000B06', '000B06XP1', '000B08') THEN '06K'
	
	-- Air And Radiation Division 
	WHEN OrgCode LIKE '06J%' AND 
		 FundCode IN ('E1', 'E2', 'E3', 'E4') AND
		 NpmCode != 'E' THEN '06J'
	WHEN AccountCode IN ('000A04', '000A05', '000A04XPM', '000A17') THEN '06J'
	WHEN OrgCode LIKE '%06A%' THEN '06A'
	WHEN NpmCode = 'A' AND
		 FundCode LIKE 'E_%' THEN '06J'
	
	-- Land, Chemical, And Revitalization Division
	WHEN AccountCode IN ('000C09', '000C10', '000D11', '000E14', '000E12') AND
		 FundCode IN ('E1', 'E2', 'E3', 'E4') THEN '06B'
	WHEN NpmCode = 'E' AND 
		 FundCode IN ('E1', 'E2', 'E3', 'E4') THEN '06B'
	WHEN OrgCode LIKE '0600%' AND 
		 FundCode LIKE ('E%') THEN '06B'
		 
	-- External Affairs
	WHEN AccountCode IN ('06X', '06AX') THEN '06X'
	
	-- Working Captial FundCode
	WHEN BocCode = '38' THEN '06G'
		
	-- Superfund And Emergency Management
	WHEN OrgCode LIKE '06L%' THEN '06L'
	WHEN OrgCode LIKE '6A%' THEN '06L' 
	WHEN FundCode LIKE ('TR%') THEN '06L'
	WHEN AccountCode LIKE '%___EC7' AND 
		 FundCode = 'T' AND
		 BocCode NOT IN ('10', '17', '38') THEN '06L' ELSE OrgCode
	END RcCode, BocCode, SUM(Commitments) as Amount, FocCode, UPPER(FocName) as FocName, OriginalActionDate, DocumentControlNumber
FROM Purchases
WHERE Deobligations != 0
GROUP BY BFY, BudgetLevel, RpioCode, AhCode, FundCode, OrgCode, AccountCode, ActivityCode, BocCode, RcCode;
CREATE VIEW "Expenditures" AS
SELECT PurchaseId as ExpenditureId, BFY, (Select 8) as BudgetLevel, RpioCode, AhCode, FundCode, OrgCode, REPLACE(AccountCode, 'X', ' ') AS ActivityCode, NpmCode, ActivityCode, 
	
	-- Water Division  
	CASE
	WHEN OrgCode IN ('061K', '062K', '063K', '064K', '065K') THEN '06K'
	WHEN OrgCode LIKE '06_K%' THEN '06K'
	WHEN OrgCode LIKE '06K%' THEN '06K'
	WHEN FundCode LIKE 'E_%' AND
		 NpmCode = 'B' THEN '06K'
	WHEN AccountCode IN ('000B01', '000B03', '000B06', '000B06XP1', '000B08') THEN '06K'
	
	-- Air And Radiation Division 
	WHEN OrgCode LIKE '06J%' AND 
		 FundCode IN ('E1', 'E2', 'E3', 'E4') AND
		 NpmCode != 'E' THEN '06J'
	WHEN AccountCode IN ('000A04', '000A05', '000A04XPM', '000A17') THEN '06J'
	WHEN OrgCode LIKE '%06A%' THEN '06A'
	WHEN NpmCode = 'A' AND
		 FundCode LIKE 'E_%' THEN '06J'
	
	-- Land, Chemical, And Revitalization Division
	WHEN AccountCode IN ('000C09', '000C10', '000D11', '000E14', '000E12') AND
		 FundCode IN ('E1', 'E2', 'E3', 'E4') THEN '06B'
	WHEN NpmCode = 'E' AND 
		 FundCode IN ('E1', 'E2', 'E3', 'E4') THEN '06B'
	WHEN OrgCode LIKE '0600%' AND 
		 FundCode LIKE ('E%') THEN '06B'
		 
	-- External Affairs
	WHEN AccountCode IN ('06X', '06AX') THEN '06X'
	
	-- Working Captial FundCode
	WHEN BocCode = '38' THEN '06G'
		
	-- Superfund And Emergency Management
	WHEN OrgCode LIKE '06L%' THEN '06L'
	WHEN OrgCode LIKE '6A%' THEN '06L' 
	WHEN FundCode LIKE ('TR%') THEN '06L'
	WHEN AccountCode LIKE '%___EC7' AND 
		 FundCode = 'T' AND
		 BocCode NOT IN ('10', '17', '38') THEN '06L' ELSE OrgCode
	END RcCode, BocCode, SUM(Commitments) as Amount, FocCode, UPPER(FocName) as FocName, OriginalActionDate, DocumentControlNumber
FROM Purchases
WHERE Expenditures != 0
GROUP BY BFY, BudgetLevel, RpioCode, AhCode, FundCode, OrgCode, AccountCode, ActivityCode, BocCode, RcCode;
CREATE VIEW "Obligations" AS
SELECT PurchaseId as ObligationId, BFY, (Select 8) as BudgetLevel, RpioCode, AhCode, FundCode, OrgCode, REPLACE(AccountCode, 'X', ' ') AS ActivityCode, NpmCode, ActivityCode, 
	
	-- Water Division  
	CASE
	WHEN OrgCode IN ('061K', '062K', '063K', '064K', '065K') THEN '06K'
	WHEN OrgCode LIKE '06_K%' THEN '06K'
	WHEN OrgCode LIKE '06K%' THEN '06K'
	WHEN FundCode LIKE 'E_%' AND
		 NpmCode = 'B' THEN '06K'
	WHEN AccountCode IN ('000B01', '000B03', '000B06', '000B06XP1', '000B08') THEN '06K'
	
	-- Air And Radiation Division 
	WHEN OrgCode LIKE '06J%' AND 
		 FundCode IN ('E1', 'E2', 'E3', 'E4') AND
		 NpmCode != 'E' THEN '06J'
	WHEN AccountCode IN ('000A04', '000A05', '000A04XPM', '000A17') THEN '06J'
	WHEN OrgCode LIKE '%06A%' THEN '06A'
	WHEN NpmCode = 'A' AND
		 FundCode LIKE 'E_%' THEN '06J'
	
	-- Land, Chemical, And Revitalization Division
	WHEN AccountCode IN ('000C09', '000C10', '000D11', '000E14', '000E12') AND
		 FundCode IN ('E1', 'E2', 'E3', 'E4') THEN '06B'
	WHEN NpmCode = 'E' AND 
		 FundCode IN ('E1', 'E2', 'E3', 'E4') THEN '06B'
	WHEN OrgCode LIKE '0600%' AND 
		 FundCode LIKE ('E%') THEN '06B'
		 
	-- External Affairs
	WHEN AccountCode IN ('06X', '06AX') THEN '06X'
	
	-- Working Captial FundCode
	WHEN BocCode = '38' THEN '06G'
		
	-- Superfund And Emergency Management
	WHEN OrgCode LIKE '06L%' THEN '06L'
	WHEN OrgCode LIKE '6A%' THEN '06L' 
	WHEN FundCode LIKE ('TR%') THEN '06L'
	WHEN AccountCode LIKE '%___EC7' AND 
		 FundCode = 'T' AND
		 BocCode NOT IN ('10', '17', '38') THEN '06L' ELSE OrgCode
	END RcCode, BocCode, SUM(Commitments) as Amount, FocCode, UPPER(FocName) as FocName, OriginalActionDate, DocumentControlNumber
FROM Purchases
WHERE Obligations != 0
GROUP BY BFY, BudgetLevel, RpioCode, AhCode, FundCode, OrgCode, AccountCode, ActivityCode, BocCode, RcCode;
CREATE VIEW "OpenCommitments" AS
SELECT PurchaseId as OpenCommitmentId, BFY, (Select 8) as BudgetLevel, RpioCode, AhCode, FundCode, OrgCode, REPLACE(AccountCode, 'X', ' ') AS AccountCode, ActivityCode, NpmCode, ActivityCode, 
	
	-- Water Division  
	CASE
	WHEN OrgCode IN ('061K', '062K', '063K', '064K', '065K') THEN '06K'
	WHEN OrgCode LIKE '06_K%' THEN '06K'
	WHEN OrgCode LIKE '06K%' THEN '06K'
	WHEN FundCode LIKE 'E_%' AND
		 NpmCode = 'B' THEN '06K'
	WHEN AccountCode IN ('000B01', '000B03', '000B06', '000B06XP1', '000B08') THEN '06K'
	
	-- Air And Radiation Division 
	WHEN OrgCode LIKE '06J%' AND 
		 FundCode IN ('E1', 'E2', 'E3', 'E4') AND
		 NpmCode != 'E' THEN '06J'
	WHEN AccountCode IN ('000A04', '000A05', '000A04XPM', '000A17') THEN '06J'
	WHEN OrgCode LIKE '%06A%' THEN '06A'
	WHEN NpmCode = 'A' AND
		 FundCode LIKE 'E_%' THEN '06J'
	
	-- Land, Chemical, And Revitalization Division
	WHEN AccountCode IN ('000C09', '000C10', '000D11', '000E14', '000E12') AND
		 FundCode IN ('E1', 'E2', 'E3', 'E4') THEN '06B'
	WHEN NpmCode = 'E' AND 
		 FundCode IN ('E1', 'E2', 'E3', 'E4') THEN '06B'
	WHEN OrgCode LIKE '0600%' AND 
		 FundCode LIKE ('E%') THEN '06B'
		 
	-- External Affairs
	WHEN AccountCode IN ('06X', '06AX') THEN '06X'
	
	-- Working Captial FundCode
	WHEN BocCode = '38' THEN '06G'
		
	-- Superfund And Emergency Management
	WHEN OrgCode LIKE '06L%' THEN '06L'
	WHEN OrgCode LIKE '6A%' THEN '06L' 
	WHEN FundCode LIKE ('TR%') THEN '06L'
	WHEN AccountCode LIKE '%___EC7' AND 
		 FundCode = 'T' AND
		 BocCode NOT IN ('10', '17', '38') THEN '06L' ELSE OrgCode
	END RcCode, BocCode, SUM(Commitments) as Amount, FocCode, UPPER(FocName) as FocName, OriginalActionDate, DocumentControlNumber
FROM Purchases
WHERE OpenCommitments != 0
GROUP BY BFY, BudgetLevel, RpioCode, AhCode, FundCode, OrgCode, AccountCode, ActivityCode, BocCode, RcCode;
CREATE VIEW "UnliquidatedObligations" AS
SELECT PurchaseId as UnliquidatedObligationId, BFY, (Select 8) as BudgetLevel, RpioCode, AhCode, FundCode, OrgCode, REPLACE(AccountCode, 'X', ' ') AS ActivityCode,  NpmCode, ActivityCode,
	
	-- Water Division  
	CASE
	WHEN OrgCode IN ('061K', '062K', '063K', '064K', '065K') THEN '06K'
	WHEN OrgCode LIKE '06_K%' THEN '06K'
	WHEN OrgCode LIKE '06K%' THEN '06K'
	WHEN FundCode LIKE 'E_%' AND
		 NpmCode = 'B' THEN '06K'
	WHEN AccountCode IN ('000B01', '000B03', '000B06', '000B06XP1', '000B08') THEN '06K'
	
	-- Air And Radiation Division 
	WHEN OrgCode LIKE '06J%' AND 
		 FundCode IN ('E1', 'E2', 'E3', 'E4') AND
		 NpmCode != 'E' THEN '06J'
	WHEN AccountCode IN ('000A04', '000A05', '000A04XPM', '000A17') THEN '06J'
	WHEN OrgCode LIKE '%06A%' THEN '06A'
	WHEN NpmCode = 'A' AND
		 FundCode LIKE 'E_%' THEN '06J'
	
	-- Land, Chemical, And Revitalization Division
	WHEN AccountCode IN ('000C09', '000C10', '000D11', '000E14', '000E12') AND
		 FundCode IN ('E1', 'E2', 'E3', 'E4') THEN '06B'
	WHEN NpmCode = 'E' AND 
		 FundCode IN ('E1', 'E2', 'E3', 'E4') THEN '06B'
	WHEN OrgCode LIKE '0600%' AND 
		 FundCode LIKE ('E%') THEN '06B'
		 
	-- External Affairs
	WHEN AccountCode IN ('06X', '06AX') THEN '06X'
	
	-- Working Captial FundCode
	WHEN BocCode = '38' THEN '06G'
		
	-- Superfund And Emergency Management
	WHEN OrgCode LIKE '06L%' THEN '06L'
	WHEN OrgCode LIKE '6A%' THEN '06L' 
	WHEN FundCode LIKE ('TR%') THEN '06L'
	WHEN AccountCode LIKE '%___EC7' AND 
		 FundCode = 'T' AND
		 BocCode NOT IN ('10', '17', '38') THEN '06L' ELSE OrgCode
	END RcCode, BocCode, SUM(Commitments) as Amount, FocCode, UPPER(FocName) as FocName, OriginalActionDate, DocumentControlNumber
FROM Purchases
WHERE ULO != 0
GROUP BY BFY, BudgetLevel, RpioCode, AhCode, FundCode, OrgCode, AccountCode, ActivityCode, BocCode, RcCode;
CREATE VIEW "Contracts" 
AS SELECT * 
FROM 
    Allocations 
WHERE 
    Allocations.BocCode = '37' AND 
    Allocations.Amount <> 0 AND 
    Allocations.BudgetLevel = '7';
CREATE VIEW "Expenses" 
AS SELECT * 
FROM 
    Allocations 
WHERE 
    Allocations.BocCode = '36' AND 
    Allocations.Amount <> 0 AND 
    Allocations.BudgetLevel = '7';
CREATE VIEW "Payroll" 
AS SELECT * 
FROM 
    Allocations 
WHERE 
    Allocations.BocCode = '10' AND 
    Allocations.Amount <> 0 AND 
    Allocations.BudgetLevel = '7';
CREATE VIEW "DivisionExecution" AS 
SELECT RpioCode, BFY, '8' AS BudgetLevel, FundCode, AhCode, OrgCode, REPLACE(AccountCode, 'X', ' ') AS AccountCode, ActivityCode, 
	
	-- Water Division  
	CASE
	WHEN OrgCode IN ('061K', '062K', '063K', '064K', '065K') THEN '06K'
	WHEN OrgCode LIKE '06_K%' THEN '06K'
	WHEN OrgCode LIKE '06K%' THEN '06K'
	WHEN FundCode LIKE 'E_%' AND
		 NpmCode = 'B' THEN '06K'
	WHEN AccountCode IN ('000B01', '000B03', '000B06', '000B06XP1', '000B08') THEN '06K'
	
	-- Air And Radiation Division 
	WHEN OrgCode LIKE '06J%' AND 
		 FundCode IN ('E1', 'E2', 'E3', 'E4') AND
		 NpmCode != 'E' THEN '06J'
	WHEN AccountCode IN ('000A04', '000A05', '000A04XPM', '000A17') THEN '06J'
	WHEN OrgCode LIKE '%06A%' THEN '06A'
	WHEN NpmCode = 'A' AND
		 FundCode LIKE 'E_%' THEN '06J'
	
	-- Land, Chemical, And Revitalization Division
	WHEN AccountCode IN ('000C09', '000C10', '000D11', '000E14', '000E12') AND
		 FundCode IN ('E1', 'E2', 'E3', 'E4') THEN '06B'
	WHEN NpmCode = 'E' AND 
		 FundCode IN ('E1', 'E2', 'E3', 'E4') THEN '06B'
	WHEN OrgCode LIKE '0600%' AND 
		 FundCode LIKE ('E%') THEN '06B'
		 
	-- External Affairs
	WHEN AccountCode IN ('06X', '06AX') THEN '06X'
	
	-- Working Captial FundCode
	WHEN BocCode = '38' THEN '06G'
		
	-- Superfund And Emergency Management
	WHEN OrgCode LIKE '06L%' THEN '06L'
	WHEN OrgCode LIKE '6A%' THEN '06L' 
	WHEN FundCode LIKE ('TR%') THEN '06L'
	WHEN AccountCode LIKE '%___EC7' AND 
		 FundCode = 'T' AND
		 BocCode NOT IN ('10', '17', '38') THEN '06L' ELSE OrgCode
	END RcCode, BocCode, SUM(Commitments) AS Commitments, SUM(OpenCommitments) AS OpenCommitments, SUM(Obligations) AS Obligations, SUM(ULO) AS ULO 
FROM Purchases
GROUP BY RpioCode, BFY, FundCode, AhCode, OrgCode, AccountCode, ActivityCode, BocCode, RcCode;
CREATE VIEW "ARD" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06J' AND
    Allocations.BudgetLevel = '8';
CREATE VIEW "WSA" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06N' AND
    Allocations.BudgetLevel = '8';
CREATE VIEW "WCF" 
AS SELECT * 
FROM 
    Allocations 
WHERE 
    Allocations.RcCode = '06G' 
AND 
    Allocations.Amount <> 0 
AND 
    Allocations.BudgetLevel = '8';
CREATE VIEW "WorkingCapitalFund" 
AS SELECT * 
FROM 
    Allocations 
WHERE 
    Allocations.BocCode = '38' 
AND 
    Allocations.Amount <> 0 
AND 
    Allocations.BudgetLevel = '7';
CREATE VIEW Travel AS 
SELECT * 
FROM Allocations 
WHERE BocCode IN ('21', '28') AND
Amount > 0;
CREATE VIEW "SuperfundSupplemental" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.FundCode = 'TS3' AND
    Allocations.Amount <> 0 AND 
    Allocations.BudgetLevel = '7';
CREATE VIEW "Superfund" 
AS SELECT *
FROM 
    Allocations
WHERE Allocations.FundCode LIKE 'T%' AND
    Allocations.FundCode NOT LIKE 'TR%' AND
	Allocations.AhCode = '06' AND
    Allocations.Amount <> 0 AND  
    Allocations.BudgetLevel = '7';
CREATE VIEW "SpecialAccounts" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.FundCode LIKE 'TR%' AND
    Allocations.AhCode = '06' AND
    Allocations.Amount <> 0 AND 
    Allocations.BudgetLevel = '7';
CREATE VIEW "SEMD" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06L' AND
    Allocations.Amount <> 0 AND 
    Allocations.BudgetLevel = '8';
CREATE VIEW "ORC" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06D' AND
    Allocations.BudgetLevel = '8';
CREATE VIEW "ORA" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06A' AND
    Allocations.BudgetLevel = '8';
CREATE VIEW "MSD"
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06C' AND
    Allocations.BudgetLevel = '8';
CREATE VIEW "LUST" 
AS SELECT *
FROM 
    Allocations
WHERE Allocations.FundCode LIKE 'F%' AND
    Allocations.FundCode NOT LIKE 'FS%' AND
    Allocations.Amount <> 0 AND  
    Allocations.BudgetLevel = '7';
CREATE VIEW "ECAD" 
AS SELECT *
FROM 
    Allocations
WHERE 
    Allocations.RcCode = '06M' AND
    Allocations.BudgetLevel = '8';
CREATE VIEW "Grants" 
AS SELECT * 
FROM 
    Allocations 
WHERE 
    Allocations.BocCode = '41' AND 
    Allocations.Amount <> 0 AND 
    Allocations.BudgetLevel = '7';
COMMIT;
