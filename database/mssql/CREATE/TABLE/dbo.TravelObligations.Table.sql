USE [C:\USERS\DADDY\SOURCE\REPOS\BUDGETEXECUTION\NINJA\DATABASE\SQLSERVER\R6.MDF]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TravelObligations](
	[TravelObligationId] [int] IDENTITY(1,1) NOT NULL,
	[RpioCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[BFY] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[FundCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[AhCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[RcCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[AccountCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[ProgramAreaCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[FocCode] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[FocName] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[Destination] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[FirstName] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[MiddleName] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[LastName] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[Email] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[DepartureDate] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[ReturnDate] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[DocumentType] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[DCN] [nvarchar](50) NOT NULL DEFAULT ('NS'),
	[Obligations] [float] NOT NULL DEFAULT  0.0,
 CONSTRAINT [PK_TravelObligations] PRIMARY KEY CLUSTERED 
(
	[TravelObligationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


