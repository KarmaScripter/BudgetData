CREATE VIEW "Carryover" 
AS SELECT *
FROM 
    PRC
WHERE
	PRC.BFY = '2019' AND
    PRC.Amount <> 0