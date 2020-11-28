CREATE VIEW IF NOT EXISTS "NetTransfers" 
AS SELECT 
  RPIO,
  BFY,
  BudgetLevel,
  FundCode,
  AhCode,
  OrgCode,
  RcCode,
  AccountCode,
  BocCode,
  Amount,
  Net,
  ProcessedDate,
  DocumentNumber,
  Purpose
FROM
  Reprogrammings
GROUP BY
  DocumentNumber,
  FundCode,
  AhCode,
  OrgCode,
  RcCode,
  AccountCode,
  BocCode
ORDER BY
  BFY DESC;
