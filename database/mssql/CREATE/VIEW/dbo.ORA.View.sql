USE [C:\USERS\DADDY\SOURCE\REPOS\BUDGETEXECUTION\NINJA\DATABASE\SQLSERVER\R6.MDF]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ORA]
AS
SELECT        PrcId, BudgetLevel, RPIO, BFY, FundCode, FundName, BocCode, BocName, AhCode, OrgCode, RcCode, DivisionName, AccountCode, Amount, ActivityCode, NpmName, NpmCode, ProgramProjectCode, ProgramProjectName, 
                         ProgramAreaCode, ProgramAreaName, GoalCode, GoalName, ObjectiveCode, ObjectiveName
FROM            dbo.PRC
WHERE        (Amount <> '0') AND (RcCode = '06A') AND (BudgetLevel = '8')
GO


