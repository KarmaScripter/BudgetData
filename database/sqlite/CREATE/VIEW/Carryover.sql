CREATE VIEW IF NOT EXISTS "Carryover" 
AS SELECT *
FROM 
    Allocations
WHERE
	Allocations.BFY = '2020' AND
    Allocations.Amount <> 0;