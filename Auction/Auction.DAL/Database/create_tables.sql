CREATE TABLE tblSellers(
    Id bigint IDENTITY(1,1) PRIMARY KEY not null,
	Sellers_Username nvarchar(50) not null,
	Sellers_Password nvarchar(50) not null,
	Sellers_FirstName nvarchar(50) not null,
    Sellers_LastName nvarchar(50) not null,
	Sellers_Email nvarchar(50) not null,
    Sellers_Phone nvarchar(50) not null
);
CREATE TABLE tblBuyers(
    Id bigint IDENTITY(1,1) PRIMARY KEY not null,
	Buyers_Username nvarchar(50) not null,
	Buyers_Password nvarchar(50) not null,
	Buyers_FirstName nvarchar(50) not null,
    Buyers_LastName nvarchar(50) not null,
	Buyers_Email nvarchar(50) not null,
    Buyers_Phone nvarchar(50) not null
);
CREATE TABLE tblCategories (
	Id bigint IDENTITY(1,1) PRIMARY KEY not null,
	Category nvarchar(50) not null
);
CREATE TABLE tblItems(
    Id bigint IDENTITY(1,1) PRIMARY KEY not null,
	Item_Title nvarchar(50) not null,
	Condition nvarchar(50) not null,
	Category_ID bigint not null,
	Seller_ID bigint not null,
	Buyer_ID bigint,
	Start_Bid int not null,
	Ship_Price int,
	Ship_Date date
);
ALTER TABLE tblItems
	ADD CONSTRAINT FK_Item_Seller FOREIGN KEY (Seller_ID)
		REFERENCES tblSellers(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE;
ALTER TABLE tblItems
	ADD CONSTRAINT FK_Category FOREIGN KEY (Category_ID)
		REFERENCES tblCategories(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE;
CREATE TABLE tblPhotos (
	Item_Id bigint not null,
	Photo_Path nvarchar(50) not null
);
ALTER TABLE tblPhotos
	ADD CONSTRAINT FK_Item FOREIGN KEY (Item_Id)
		REFERENCES tblItems(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE;
CREATE TABLE tblBids (
	Id bigint IDENTITY(1,1) PRIMARY KEY not null,
	Bid_Item_ID bigint not null,
	Bid_Buyer_ID bigint not null,
	BidAmount int not null,
	BidTime date not null,
	WinStatus nvarchar(10)
);
ALTER TABLE tblBids
	ADD CONSTRAINT FK_Bid_Item FOREIGN KEY (Bid_Item_ID)
		REFERENCES tblItems(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE;
CREATE TABLE tblBidsToBuyer (
	Id bigint IDENTITY(1,1) PRIMARY KEY not null,
	Buyer_ID bigint not null,
	Bid_ID bigint not null
);
ALTER TABLE tblBidsToBuyer
	ADD CONSTRAINT FK_Buyer_Bid FOREIGN KEY (Buyer_ID)
		REFERENCES tblBuyers(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE;
ALTER TABLE tblBidsToBuyer
	ADD CONSTRAINT FK_Bid FOREIGN KEY (Bid_ID)
		REFERENCES tblBids(Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE;