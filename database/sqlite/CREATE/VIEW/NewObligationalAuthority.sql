CREATE VIEW IF NOT EXISTS "NewObligationalAuthority" 
AS SELECT *
FROM 
    Allocations
WHERE
	Allocations.BFY = '2021' AND
    Allocations.Amount <> 0;