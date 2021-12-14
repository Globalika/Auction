CREATE TRIGGER belowZero
ON tblItems
 AFTER INSERT
 AS
 BEGIN
   UPDATE tblItems
   SET Start_Bid = 0
   OUTPUT inserted.Id
   WHERE tblItems.Start_Bid < 0
 END;