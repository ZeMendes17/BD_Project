CREATE VIEW Project.StaffItemStatsView
AS
	SELECT StaffNIF, StaffID, ItemID, ItemDescription, SUM(Project.ITEM_ORDER.Quantity) AS TotalNumItems, SUM(Project.ITEM.Price) AS TotalItemSales
	FROM ((Project.MANAGES JOIN Project.[ORDER] ON Project.Manages.OrderNumber=Project.[ORDER].OrderNumber)
	JOIN Project.ITEM_ORDER ON Project.Manages.OrderNumber=Project.ITEM_ORDER.OrderNumber)
	JOIN Project.ITEM ON ItemID=ID
	GROUP BY StaffNIF, StaffID, ItemID, ItemDescription