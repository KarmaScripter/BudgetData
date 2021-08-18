CREATE TABLE [WorkCodes]
(
   [WorkCodeId] INT NOT NULL IDENTITY (1,1),
   [RpioCode] NVARCHAR(255) DEFAULT ('NS'),
   [WorkCode] NVARCHAR(255) DEFAULT ('NS'),
   [WorkCodeName] NVARCHAR(255) DEFAULT ('NS'),
   [ChargeType] NVARCHAR(255) DEFAULT ('NS'),
   [Notifications] NVARCHAR(255) DEFAULT ('NS'),
   [PayPeriod] NVARCHAR(255) DEFAULT ('NS'),
   [BFY] NVARCHAR(255) DEFAULT ('NS'),
   [ApproverUserName] NVARCHAR(255) DEFAULT ('NS'),
   [ApprovedDate] NVARCHAR(255) DEFAULT ('NS'),
   [ModifierUserName] NVARCHAR(255) DEFAULT ('NS'),
   [ModifiedDate] NVARCHAR(255) DEFAULT ('NS'),
   [FundCode] NVARCHAR(255) DEFAULT ('NS'),
   [FocCode] NVARCHAR(255) DEFAULT ('NS'),
   [CostOrgCode] NVARCHAR(255) DEFAULT ('NS'),
   [CostOrgName] NVARCHAR(255) DEFAULT ('NS'),
   [RcCode] NVARCHAR(255) DEFAULT ('NS'),
   [AccountCode] NVARCHAR(255) DEFAULT ('NS'),
   [WorkProjectCode] NVARCHAR(255) DEFAULT ('NS'),
   [WorkProjectName] NVARCHAR(255) DEFAULT ('NS'),
   [Percentage] FLOAT NOT NULL DEFAULT (0.0)
);
