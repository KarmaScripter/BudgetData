CREATE VIEW IF NOT EXISTS "Schema" AS 
SELECT * 
FROM sqlite_master
WHERE 
	type IN ('table', 'view') AND 
	name NOT IN ('sqlite_sequence', 'Schema');