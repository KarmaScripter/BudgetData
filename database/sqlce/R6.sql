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
