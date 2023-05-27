CREATE PROCEDURE Project.updateOrder @ItemId INT, @AmountToRemove INT
AS
    BEGIN
        BEGIN TRANSACTION
            UPDATE Project.ITEM SET Quantity = Quantity - @AmountToRemove WHERE ID = @ItemId;
            IF @@ROWCOUNT > 0
                BEGIN
                    COMMIT;
                    PRINT 'Transaction committed.';
                    -- UPDATE Project.[ORDER] SET OrderState='Shipped' WHERE OrderNumber=@OrderNumber;
                END
            ELSE
                BEGIN
                    ROLLBACK;
                    PRINT 'Transaction rolled back.';
                    RAISERROR('Not able to complete Order Update', 16, 1)
                END
    END
