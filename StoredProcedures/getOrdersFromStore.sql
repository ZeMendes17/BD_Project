CREATE PROCEDURE Project.getOrdersFromStore @store VARCHAR(50), @state VARCHAR(15)
AS
    BEGIN
        SELECT OrderNumber, CostumerNIF, Price, NumItems, OrderDate
        FROM Project.[ORDER]
        WHERE StoreURL=@store AND OrderState=@state
    END