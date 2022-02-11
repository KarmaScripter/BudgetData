CREATE TABLE [HumanResourceOrganizations]
(
   [HumanResourceOrganizationsId] INT NOT NULL IDENTITY(1,1),
   [RcCode] NVARCHAR(255),
   [HrOrgCode] NVARCHAR(255),
   [HrOrgName] NVARCHAR(255),
        CONSTRAINT PK_HumanResourceOrganizations
        PRIMARY KEY (HumanResourceOrganizationsId) 
);