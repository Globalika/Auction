INSERT INTO tblCategories(Category)
VALUES
('Cars'),
('Furniture'),
('Painting'),
('Sports equipment');
INSERT INTO tblSellers(Sellers_Username, Sellers_Password, Sellers_Email)
VALUES
('yrthe', 'passtrdge', 'fdfd@gmail.com'),
('ugyfde', 'passtree', 'v4v4@gmail.com'),
('rthgrtgre', 'passrthge', '7nbvfds@gmail.com'),
('rthrew', 'passwythrgse', '5gvr@gmail.com'),
('rtheert', 'passwrhtees', 'uytr@gmail.com');
INSERT INTO tblBuyers(Buyers_Username, Buyers_Password, Buyers_Email)
VALUES
('oiuytre', 'nytrfghj', '876rdesw@gmail.com'),
('yu7t6fd', 'uikujyhtgr', 'u8y7gytfr@gmail.com'),
('iuytrer', 'nuytr', '8y7t6r5@gmail.com'),
('l;kjhgrty', 'iuyt5re', 'i9u8y76h@gmail.com'),
('hiuig65', 'kogtfdrt', '3s4d5f@gmail.com');
INSERT INTO tblItems(Category_ID, Seller_ID, Buyer_ID, Start_Bid)
VALUES
(1, 1, 2, 111),
(3, 2, 1, 111),
(1, 1, 1, 111),
(1, 3, 1, 111),
(3, 1, 1, 111),
(2, 1, 2, 111);
INSERT INTO tblPhotos(Item_Id, Photo_Path)
VALUES
(1, 'pathdvefw'),
(2, 'pathdvefw'),
(1, 'pathuiyt'),
(4, 'pathujyht'),
(3, 'pathhiuytr'),
(1, 'pathuyjth');
INSERT INTO tblBids(Bid_Item_ID, Bid_Buyer_ID, BidAmount, BidTime)
VALUES
(1, 2, 44, convert(datetime, '20210914 10:24:10 PM', 5)),
(1, 2, 44, convert(datetime, '20210622 06:34:03 PM', 5)),
(1, 2, 44, convert(datetime, '20211018 04:19:22 AM', 5)),
(1, 2, 44, convert(datetime, '20210518 10:34:44 AM', 5)),
(1, 2, 44, convert(datetime, '20210211 11:14:09 AM', 5));
INSERT INTO tblBidsToBuyer(Buyer_ID, Bid_ID)
VALUES
(1, 2),
(2, 2),
(3, 3),
(2, 1);