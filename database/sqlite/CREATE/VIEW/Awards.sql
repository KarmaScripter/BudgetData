CREATE VIEW IF NOT EXISTS "Awards" 
AS SELECT *
FROM 
    Supplemental
WHERE 
    Supplemental.Type = 'MONETARY' AND
    Supplemental.Amount <> 0;