CREATE TABLE IF NOT EXISTS "ProgramAreas" 
(
	"ProgramAreaId"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	"Code" TEXT NOT NULL,
	"Name" TEXT NOT NULL DEFAULT NS
);
