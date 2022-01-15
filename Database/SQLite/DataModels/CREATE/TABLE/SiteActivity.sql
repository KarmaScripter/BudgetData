CREATE TABLE "SiteActivity" (
	"SiteActivityId"	INTEGER NOT NULL UNIQUE,
	"EFY"	TEXT NOT NULL DEFAULT 'NS',
	"RpioCode"	TEXT NOT NULL DEFAULT 'NS',
	"RpioName"	TEXT NOT NULL DEFAULT 'NOT SPECIFIED',
	"AhCode"	TEXT NOT NULL DEFAULT 'NS',
	"FundCode"	TEXT NOT NULL DEFAULT 'NS',
	"FundName"	TEXT NOT NULL DEFAULT 'NOT SPECIFIED',
	"AccountCode"	TEXT NOT NULL DEFAULT 'NS',
	"ProgramProjectCode"	TEXT NOT NULL DEFAULT 'NS',
	"ProgramProjectName"	TEXT NOT NULL DEFAULT 'NOT SPECIFIED',
	"BocCode"	TEXT NOT NULL DEFAULT 'NS',
	"BocName"	TEXT NOT NULL DEFAULT 'NOT SPECIFIED',
	"OrgCode"	TEXT NOT NULL DEFAULT 'NS',
	"OrgName"	TEXT NOT NULL DEFAULT 'NOT SPECIFIED',
	"FocCode"	TEXT NOT NULL DEFAULT 'NS',
	"FocName"	TEXT NOT NULL DEFAULT 'NOT SPECIFIED',
	"EpaSiteId"	TEXT NOT NULL DEFAULT 'NS',
	"SiteProjectCode"	TEXT NOT NULL DEFAULT 'NS',
	"SSID"	TEXT NOT NULL DEFAULT 'NS',
	"ActionCode"	TEXT NOT NULL DEFAULT 'NS',
	"OperableUnit"	TEXT NOT NULL DEFAULT 'NS',
	"SiteProjectName"	TEXT NOT NULL DEFAULT 'NOT SPECIFIED',
	"State"	TEXT NOT NULL DEFAULT 'NS',
	"City"	TEXT NOT NULL DEFAULT 'NS',
	"CongressionalDistrict"	TEXT NOT NULL DEFAULT 'NS',
	"ProjectType"	TEXT NOT NULL DEFAULT 'NS',
	"StartDate"	TEXT NOT NULL DEFAULT 'NS',
	"LastActivity"	TEXT NOT NULL DEFAULT 'NS',
	"EndDate"	TEXT NOT NULL DEFAULT 'NS',
	"Requested"	REAL NOT NULL DEFAULT 0,
	"Accepted"	REAL NOT NULL DEFAULT 0,
	"Closed"	REAL NOT NULL DEFAULT 0,
	"Outstanding"	REAL NOT NULL DEFAULT 0,
	"Refunded"	REAL NOT NULL DEFAULT 0,
	"Reversal"	REAL NOT NULL DEFAULT 0,
	PRIMARY KEY("SiteActivityId" AUTOINCREMENT)
)