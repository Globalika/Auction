INSERT INTO tblCategories(Category)
VALUES
('Cars'),
('Furniture'),
('Painting'),
('Sports equipment');
INSERT INTO tblSellers(Sellers_Username, Sellers_Password,
Sellers_FirstName, Sellers_LastName, Sellers_Email, Sellers_Phone)
VALUES
('yrthe', 'passtrdge', 'George', 'Dddd', 'fdfd@gmail.com', '245678908'),
('ugyfde', 'passtree', 'Geller', 'Sef', 'v4v4@gmail.com', '398765347'),
('rthgrtgre', 'passrthge', 'Gina', 'Hre', '7nbvfds@gmail.com', '865432345'),
('rthrew', 'passwythrgse', 'Nicole', 'Wvrt', '5gvr@gmail.com', '345678763'),
('rtheert', 'passwrhtees', 'Kyle', 'Wtrbt', 'uytr@gmail.com', '876543456');
INSERT INTO tblBuyers(Buyers_Username, Buyers_Password,
Buyers_FirstName, Buyers_LastName, Buyers_Email, Buyers_Phone)
VALUES
('oiuytre', 'nytrfghj', 'Giorgina', 'Rgrtr', '876rdesw@gmail.com', '798655543'),
('yu7t6fd', 'uikujyhtgr', 'Liam', 'Efyu', 'u8y7gytfr@gmail.com', '675600453'),
('iuytrer', 'nuytr', 'Henry', 'Eytujiu', '8y7t6r5@gmail.com', '506433654'),
('l;kjhgrty', 'iuyt5re', 'Ava', 'Egtr', 'i9u8y76h@gmail.com', '345678763'),
('hiuig65', 'kogtfdrt', 'Lucas', 'Kgftre', '3s4d5f@gmail.com', '876543456');
INSERT INTO tblItems(Item_Title, Condition, Category_ID,
Seller_ID, Start_Bid)
VALUES
('drver', 'sdrg', 1, 1, 111),
('trhre', 'rthtr', 3, 2, 111),
('rthrt', 'rthrth', 1, 1, 111),
('fgbvrd', 'hilu', 1, 3, 111),
('hythgref', 'gyt', 3, 1, 111),
('yiujth', 'unytr', 2, 1, 111);
INSERT INTO tblPhotos(Item_Id, Photo_Path)
VALUES
(1, 'pathdvefw'),
(2, 'pathdvefw'),
(1, 'pathuiyt'),
(4, 'pathujyht'),
(3, 'pathhiuytr'),
(1, 'pathuyjth');
INSERT INTO tblBids(Bid_Item_ID, Bid_Buyer_ID, BidAmount, BidTime, WinStatus)
VALUES
(1, 2, 44, convert(datetime, '20210914 10:24:10 PM', 5), 'expired'),
(1, 2, 44, convert(datetime, '20210622 06:34:03 PM', 5), 'highest'),
(1, 2, 44, convert(datetime, '20211018 04:19:22 AM', 5), 'outbid'),
(1, 2, 44, convert(datetime, '20210518 10:34:44 AM', 5), 'expired'),
(1, 2, 44, convert(datetime, '20210211 11:14:09 AM', 5), 'highest');
INSERT INTO tblBidsToBuyer(Buyer_ID, Bid_ID)
VALUES
(1, 2),
(2, 2),
(3, 3),
(2, 1);