CREATE VIEW Project.ItemsInOrderView
AS
    SELECT OrderNumber, ItemID, ITEM_ORDER.Quantity, ItemDescription, Price
    FROM Project.ITEM_ORDER JOIN Project.ITEM ON Project.ITEM_ORDER.ItemID=Project.ITEM.ID
    