CREATE VIEW Project.StaffTotalStatsView
AS
	SELECT StaffNIF, StaffID, COUNT(StaffNIF) AS TotalOrders, SUM(Price) AS TotalMoney FROM (Project.MANAGES JOIN Project.[ORDER] ON Project.Manages.OrderNumber=Project.[ORDER].OrderNumber)
	GROUP BY StaffNIF, StaffID