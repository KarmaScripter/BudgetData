CREATE TABLE IF NOT EXISTS "Vendors" (
	"VendorId"	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	"BFY"	TEXT NOT NULL DEFAULT NS,
	"FundCode"	TEXT NOT NULL DEFAULT NS,
	"VendorCode"	TEXT NOT NULL DEFAULT NS,
	"VendorName"	TEXT NOT NULL DEFAULT NS,
	"DUNS"	TEXT NOT NULL DEFAULT NS,
	"OrgCode"	TEXT NOT NULL DEFAULT NS,
	"RcCode"	TEXT NOT NULL DEFAULT NS,
	"AccountCode"	TEXT NOT NULL DEFAULT NS,
	"FocCode"	TEXT NOT NULL DEFAULT NS,
	"DocType"	TEXT NOT NULL DEFAULT NS,
	"DocumentNumber"	TEXT NOT NULL DEFAULT NS,
	"StartDate"	TEXT NOT NULL DEFAULT NS,
	"EndDate"	TEXT NOT NULL DEFAULT NS,
	"ClosedDate"	TEXT NOT NULL DEFAULT NS,
	"Amount"	FLOAT NOT NULL DEFAULT 0.0,
	"Expended"	FLOAT NOT NULL DEFAULT 0.0,
	"ULO"	FLOAT NOT NULL DEFAULT 0.0,
	"OrgName"	TEXT NOT NULL DEFAULT NS,
	"FundName"	TEXT NOT NULL DEFAULT NS,
	"FocName"	TEXT NOT NULL DEFAULT NS,
	"ProgramProjectName"	TEXT NOT NULL DEFAULT NS
);