CREATE TABLE IF NOT EXISTS "AppropriationBills" 
(
	"AppropriationBillId" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	"BFY" TEXT NOT NULL DEFAULT NA,
	"Title"	TEXT NOT NULL DEFAULT NA,
	"PublicLaw"	TEXT NOT NULL DEFAULT NA,
	"EnactedDate"	TEXT NOT NULL DEFAULT NA
);
