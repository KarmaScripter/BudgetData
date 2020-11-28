CREATE TABLE IF NOT EXISTS "HumanResourceOrganizations" 
(
	"HumanResourceOrganizationId"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	"RcCode"	TEXT NOT NULL DEFAULT NS,
	"HumanResourceOrganizationCode"	TEXT NOT NULL DEFAULT NS,
	"HumanResourceOrganizationName"	TEXT NOT NULL DEFAULT NS
);
