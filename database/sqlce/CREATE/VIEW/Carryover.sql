CREATE VIEW IF NOT EXISTS "Carryover" 
AS SELECT *
FROM 
    Allocations
WHERE
	Allocations.BFY = '2019' AND
    Allocations.Amount <> 0;