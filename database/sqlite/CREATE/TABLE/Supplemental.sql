CREATE TABLE IF NOT EXISTS "Supplemental" (
	"SupplementalId"	INTEGER NOT NULL UNIQUE,
	"Type"	TEXT,
	"RcCode"	TEXT NOT NULL,
	"FundCode"	TEXT,
	"BFY"	TEXT,
	"BocCode"	TEXT,
	"BocName"	TEXT,
	"Amount"	NUMERIC,
	"Time"	TEXT,
	PRIMARY KEY("SupplementalId" AUTOINCREMENT)
)