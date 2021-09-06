CREATE VIEW "NewObligationalAuthority" 
AS SELECT *
FROM 
    PRC
WHERE
	PRC.BFY = '2020' AND
    PRC.Amount <> 0