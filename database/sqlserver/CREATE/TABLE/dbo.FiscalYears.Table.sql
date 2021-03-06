USE [C:\USERS\DADDY\SOURCE\REPOS\BUDGETEXECUTION\NINJA\DATABASE\SQLSERVER\R6.MDF]
GO
/****** Object:  Table [dbo].[FiscalYears]    Script Date: 2019-10-06 23:37:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FiscalYears](
	[FiscalYearId] [int] NOT NULL,
	[BBFY] [nvarchar](50) NOT NULL,
	[EBFY] [nvarchar](50) NULL,
	[BeginYear] [nvarchar](50) NULL,
	[EndYear] [nvarchar](50) NULL,
	[ExpiringYear] [nvarchar](50) NULL,
	[BeginDate] [nvarchar](50) NULL,
	[EndDate] [nvarchar](50) NULL,
	[Availability] [nvarchar](50) NULL,
 CONSTRAINT [PK_FiscalYears] PRIMARY KEY CLUSTERED 
(
	[FiscalYearId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
