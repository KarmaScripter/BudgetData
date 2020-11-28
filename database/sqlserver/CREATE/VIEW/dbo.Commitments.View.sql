CREATE VIEW "Commitments"
AS SELECT PurchaseId as CommitmentId, BFY, RpioCode, FundCode, AhCode, OrgCode, RcCode, AccountCode, ActivityCode, BocCode, FocCode, FocName, DCN, DocumentType, DocumentPrefix, OriginalActionDate, GrantNumber, 
	NpmCode, PurchaseRequest, ReimbursableAgreementNumber, SiteProjectCode, System, TransactionNumber, Commitments
	
FROM Purchases
WHERE Commitments != 0