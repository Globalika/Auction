IF(OBJECT_ID('dbo.tblBidsToBuyer') IS NOT NULL)
BEGIN
    ALTER TABLE dbo.tblBidsToBuyer
    DROP CONSTRAINT FK_Buyer_Bid;
ALTER TABLE dbo.tblBidsToBuyer
	DROP CONSTRAINT FK_Bid;
DROP TABLE dbo.tblBidsToBuyer;
END
DROP TABLE IF EXISTS dbo.tblBuyers;
IF(OBJECT_ID('dbo.tblBids') IS NOT NULL)
BEGIN
    ALTER TABLE dbo.tblBids
    DROP CONSTRAINT FK_Bid_Item;
DROP TABLE dbo.tblBids;
END
IF(OBJECT_ID('dbo.tblPhotos') IS NOT NULL)
BEGIN
    ALTER TABLE dbo.tblPhotos
    DROP CONSTRAINT FK_Item;
DROP TABLE dbo.tblPhotos;
END
IF(OBJECT_ID('dbo.tblItems') IS NOT NULL)
BEGIN
    ALTER TABLE dbo.tblItems
    DROP CONSTRAINT FK_Item_Seller;
ALTER TABLE dbo.tblItems
	DROP CONSTRAINT FK_Category;
DROP TABLE dbo.tblItems;
END
DROP TABLE IF EXISTS dbo.tblSellers;
DROP TABLE IF EXISTS dbo.tblCategories;