CREATE VIEW IF NOT EXISTS "TimeOff" 
AS SELECT *
FROM 
    Supplemental
WHERE 
    Type = 'TIMEOFF' AND 
    TIME != 0;
