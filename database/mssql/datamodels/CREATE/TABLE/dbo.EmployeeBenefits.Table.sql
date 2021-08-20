USE [DataModels]
GO

/****** Object:  Table [dbo].[Images]    Script Date: 7/26/2021 6:51:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Images](
	[ID] [int] NOT NULL,
	[FileName] [nvarchar](255) NULL,
	[FilePath] [nvarchar](255) NULL,
	[FileExtension] [nvarchar](255) NULL,
	[ImageFile] [image] NULL,
	[Attachments] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


