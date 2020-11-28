USE [C:\USERS\DADDY\SOURCE\REPOS\BUDGETEXECUTION\NINJA\DATABASE\SQLSERVER\R6.MDF]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[SEMD]
AS
SELECT        PrcId, BudgetLevel, RPIO, BFY, FundCode, FundName, BocCode, BocName, AhCode, OrgCode, RcCode, DivisionName, AccountCode, Amount, ActivityCode, NpmName, NpmCode, ProgramProjectCode, ProgramProjectName, 
                         ProgramAreaCode, ProgramAreaName, GoalCode, GoalName, ObjectiveCode, ObjectiveName
FROM            dbo.PRC
WHERE        (RcCode = '06L') AND (BudgetLevel = N'8') AND (Amount <> 0)
GO

