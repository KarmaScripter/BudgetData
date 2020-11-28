CREATE VIEW IF NOT EXISTS "Awards" 
AS SELECT *
FROM 
    Supplemental
WHERE 
    Type = 'MONETARY';