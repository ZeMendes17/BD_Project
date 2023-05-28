-- this table has a attribute ContactID that is autoincremented
-- so we need to get the last inserted ContactID
-- and then insert it into the trigger table

CREATE TRIGGER addContactSupplierTrigger
ON Project.CONTACT_SUPPLIER
INSTEAD OF INSERT
AS
    BEGIN
        DECLARE @ContactID INT;
        DECLARE @ManagerNIF CHAR(9);
        DECLARE @ManagerID INT;
        DECLARE @SupplierID INT;
        DECLARE @ContactDate DATETIME;
        DECLARE @ContactDescription VARCHAR(200);

        SELECT @ContactID = MAX(ContactID) FROM Project.CONTACT_SUPPLIER;
        -- if the table is empty
        IF @ContactID IS NULL
            SET @ContactID = 1;
        ELSE
            SET @ContactID = @ContactID + 1;
            
        SELECT @ManagerID = ManagerID, @ManagerNIF = ManagerNIF, @SupplierID = SupplierID, @ContactDate = ContactDate, @ContactDescription = ContactDescription
        FROM inserted;

        INSERT INTO Project.CONTACT_SUPPLIER (ContactID, ManagerNIF, ManagerID, SupplierID, ContactDate, ContactDescription)
        VALUES (@ContactID, @ManagerNIF, @ManagerID, @SupplierID, @ContactDate, @ContactDescription);
    END;