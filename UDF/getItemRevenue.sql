CREATE FUNCTION Project.getItemRevenue(@store VARCHAR(50)) RETURNS TABLE
AS
RETURN(
    SELECT ID, ItemDescription, SUM(Price) AS TotalSales, SUM(ITEM_ORDER.Quantity) AS NumItens
    FROM Project.ITEM_ORDER JOIN Project.ITEM ON ItemID=ID
    WHERE StoreURL=@store
    GROUP BY ID, ItemDescription, StoreURl
);