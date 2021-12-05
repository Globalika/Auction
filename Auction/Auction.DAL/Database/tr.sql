CREATE TRIGGER nameTrigger
ON tblBuyers
 AFTER INSERT
 AS
 BEGIN
   UPDATE tblBuyers
   SET created = GETDATE()
   FROM inserted
   WHERE tblBuyers.id = inserted.id;
 END
GO;