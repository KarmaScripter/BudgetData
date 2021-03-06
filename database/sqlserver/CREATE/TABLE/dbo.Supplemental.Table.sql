USE [C:\USERS\DADDY\SOURCE\REPOS\BUDGETEXECUTION\NINJA\DATABASE\SQLSERVER\R6.MDF]
GO
/****** Object:  Table [dbo].[Supplemental]    Script Date: 2019-10-06 23:37:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplemental](
	[SupplementalId] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](255) NULL,
	[RcCode] [nvarchar](255) NULL,
	[Division] [nvarchar](255) NULL,
	[DivisionName] [nvarchar](255) NULL,
	[FundCode] [nvarchar](255) NULL,
	[FundName] [nvarchar](255) NULL,
	[BFY] [nvarchar](255) NULL,
	[BocCode] [nvarchar](255) NULL,
	[BocName] [nvarchar](255) NULL,
	[Amount] [decimal](18, 0) NULL,
	[Time] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Supplemental] PRIMARY KEY CLUSTERED 
(
	[SupplementalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
