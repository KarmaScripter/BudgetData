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
