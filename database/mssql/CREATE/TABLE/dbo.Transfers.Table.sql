USE [C:\USERS\DADDY\SOURCE\REPOS\BUDGETEXECUTION\NINJA\DATABASE\SQLSERVER\R6.MDF]
GO

/****** Object:  Table [dbo].[Transfers]    Script Date: 2020-01-20 09:46:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Transfers](
	[TransferId] [int] IDENTITY(1,1) NOT NULL,
	[BudgetLevel] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[DocType] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[BFY] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[RPIO] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[FundCode] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[FundName] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[DocumentNumber] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[ProcessedDate] [datetime] NOT NULL DEFAULT ('NS'),
	[AhCode] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[AhName] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[OrgCode] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[OrgName] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[RcCode] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[DivisionName] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[AccountCode] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[ProgramAreaCode] [nvarchar](255) NULL,
	[ProgramAreaName] [nvarchar](255)  NOT NULL DEFAULT ('NS'),
	[ProgramProjectCode] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[ResourceType] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[Line] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[Subline] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[FromTo] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[BocCode] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[BocName] [nvarchar](255) NOT NULL DEFAULT ('NS'),
	[Amount] [float]  NOT NULL DEFAULT 0.0,
	[Purpose] [nvarchar](max) NOT NULL DEFAULT ('NS'),
 CONSTRAINT [PK_Transfers] PRIMARY KEY CLUSTERED 
(
	[TransferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


