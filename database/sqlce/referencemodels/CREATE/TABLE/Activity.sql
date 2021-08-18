CREATE TABLE [Activity]
(
   [ActivityId] INT NOT NULL IDENTITY (1,1),
   [Code] NVARCHAR(255) DEFAULT ('NS'),
   [Name] NVARCHAR(255) DEFAULT ('NS'),
   [Title] NVARCHAR(255) DEFAULT ('NS')
);
