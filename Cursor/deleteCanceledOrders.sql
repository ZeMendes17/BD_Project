-- this SP deletes canceled orders from the order table using
-- the manager's NIF as a parameter and uses a cursor to iterate

-- DROP FUNCTION IF EXISTS deleteCanceledOrders;
-- GO

CREATE PROCEDURE deleteCanceledOrders @NIF INT
AS
BEGIN
    DECLARE @StoreURL VARCHAR(50);
    DECLARE @OrderNumber INT;

    SET @StoreURL = (SELECT StoreURL FROM Project.MANAGER WHERE NIF = @NIF);

    IF @StoreURL IS NULL
    BEGIN
        RAISERROR('Manager with NIF %d does not exist', 16, 1, @NIF);
        RETURN;
    END

    DECLARE CanceledOrders CURSOR FAST_FORWARD
        FOR SELECT OrderNumber, CostumerNIF
        FROM Project.[ORDER]
        WHERE StoreURL = @StoreURL AND OrderState = 'Canceled';

    OPEN CanceledOrders;

    FETCH CanceledOrders INTO @OrderNumber, @CostumerNIF;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        DELETE FROM Project.[ORDER] WHERE OrderNumber = @OrderNumber AND CostumerNIF = @CostumerNIF;
        DELETE FROM Project.ITEM_ORDER WHERE OrderNumber = @OrderNumber AND CostumerNIF = @CostumerNIF;
        DELETE FROM Project.MANAGES WHERE OrderNumber = @OrderNumber AND CostumerNIF = @CostumerNIF;

        FETCH CanceledOrders INTO @OrderNumber, @CostumerNIF;
    END
    
    CLOSE CanceledOrders;

    DEALLOCATE CanceledOrders;
END