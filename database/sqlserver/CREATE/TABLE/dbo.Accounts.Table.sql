
CREATE TABLE [Accounts]
(
	[AccountId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](255) DEFAULT ('NS'),
	[Name] [nvarchar](255) DEFAULT ('NS'),
	[Title] [nvarchar](255) DEFAULT ('NS'),
	[ProgramAreaCode] [nvarchar](255) DEFAULT ('NS'),
	[GoalCode] [nvarchar](255) DEFAULT ('NS'),
	[ObjectiveCode] [nvarchar](255) DEFAULT ('NS'),
	[NpmCode] [nvarchar](255) DEFAULT ('NS'),
	[ProgramProjectCode] [nvarchar](255) DEFAULT ('NS'),
	[ActivityCode] [nvarchar](255) DEFAULT ('NS')
);
