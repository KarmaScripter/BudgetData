CREATE TABLE [HumanResourceOrganizations]
(
   [HumanResourceOrganizationId] INT NOT NULL UNIQUE IDENTITY(1,1),
   [RcCode] NVARCHAR(255),
   [HumanResourceOrganizationCode] NVARCHAR(255),
   [HumanResourceOrganizationName] NVARCHAR(255)
);
