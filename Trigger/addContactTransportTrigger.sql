-- this table has a attribute ContactID that is autoincremented
-- so we need to get the last inserted ContactID
-- and then insert it into the trigger table

CREATE TRIGGER addContactTransportTrigger
ON Project.CONTACT_TRANSPORT
INSTEAD OF INSERT
AS
    BEGIN
        DECLARE @ContactID INT;
        DECLARE @ManagerNIF CHAR(9);
        DECLARE @ManagerID INT;
        DECLARE @TransportNumber INT;
        DECLARE @OrderNumber INT;
        DECLARE @CostumerNIF CHAR(9);
        DECLARE @ContactDate DATETIME;
        DECLARE @ContactDescription VARCHAR(200);

        SELECT @ContactID = MAX(ContactID) FROM Project.CONTACT_TRANSPORT;
        -- if the table is empty
        IF @ContactID IS NULL
            SET @ContactID = 1;
        ELSE
            SET @ContactID = @ContactID + 1;
            
        SELECT @ManagerID = ManagerID, @ManagerNIF = ManagerNIF, @TransportNumber = TransportNumber, @ContactDate = ContactDate, @ContactDescription = ContactDescription, @OrderNumber = OrderNumber, @CostumerNIF = CostumerNIF
        FROM inserted;

        INSERT INTO Project.CONTACT_TRANSPORT (ContactID, ManagerNIF, ManagerID, TransportNumber, OrderNumber, CostumerNIF, ContactDate, ContactDescription)
        VALUES (@ContactID, @ManagerNIF, @ManagerID, @TransportNumber, @OrderNumber, @CostumerNIF, @ContactDate, @ContactDescription);
    END;