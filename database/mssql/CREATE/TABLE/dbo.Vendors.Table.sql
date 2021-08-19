USE [C:\USERS\DADDY\SOURCE\REPOS\BUDGETEXECUTION\NINJA\DATABASE\SQLSERVER\R6.MDF]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Vendors](
	[VendorId] [int] IDENTITY(1,1) NOT NULL,
	[BFY] [nvarchar](50) NOT NULL DEFAULT 'NS',
	[FundCode] [nvarchar](50) NOT NULL DEFAULT 'NS',
	[VendorCode] [nvarchar](50) NOT NULL DEFAULT 'NS',
	[VendorName] [nvarchar](100) NOT NULL DEFAULT 'NS',
	[DUNS] [nvarchar](100) NOT NULL DEFAULT 'NS',
	[OrgCode] [nvarchar](50) NOT NULL DEFAULT 'NS',
	[RcCode] [nvarchar](50) NOT NULL DEFAULT 'NS',
	[AccountCode] [nvarchar](50) NOT NULL DEFAULT 'NS',
	[FocCode] [nvarchar](100) NOT NULL DEFAULT 'NS',
	[DocType] [nvarchar](50) NOT NULL DEFAULT 'NS',
	[DocumentNumber] [nvarchar](50) NOT NULL DEFAULT 'NS',
	[StartDate] [nvarchar](50) NOT NULL DEFAULT 'NS',
	[EndDate] [nvarchar](50) NOT NULL DEFAULT 'NS',
	[ClosedDate] [nvarchar](50) NOT NULL DEFAULT 'NS',
	[Amount] [float] NOT NULL DEFAULT 0.0,
	[Expended] [float] NOT NULL DEFAULT 0.0,
	[ULO] [float] NOT NULL DEFAULT 0.0,
	[FundName] [nvarchar](50) NOT NULL,
	[FocName] [nvarchar](50) NOT NULL,
	[OrgName] [nvarchar](100) NOT NULL,
	[ProgramProjectName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED 
(
	[VendorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


