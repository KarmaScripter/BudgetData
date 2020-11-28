CREATE VIEW IF NOT EXISTS "Overtime" 
AS SELECT *
FROM 
    Supplemental
WHERE 
    Type = 'OVERTIME';