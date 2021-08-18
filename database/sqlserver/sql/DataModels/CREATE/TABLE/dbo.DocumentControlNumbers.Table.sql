USE [DataModels]
GO
/****** Object:  Table [dbo].[DocumentControlNumbers]    Script Date: 7/17/2021 9:04:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentControlNumbers](
	[DocumentControlNumberId] [int] NOT NULL,
	[RcCode] [nvarchar](255) NULL,
	[DocumentControlNumber] [nvarchar](255) NULL,
 CONSTRAINT [PK_DocumentControlNumbers] PRIMARY KEY CLUSTERED 
(
	[DocumentControlNumberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
