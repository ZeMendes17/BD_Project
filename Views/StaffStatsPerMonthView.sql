CREATE VIEW Project.StaffStatsPerMonthView
AS
	SELECT StaffNIF, StaffID, MONTH(OrderDate) AS [Month], SUM(Price) AS TotalPrice FROM (Project.MANAGES JOIN Project.[ORDER] ON Project.Manages.OrderNumber=Project.[ORDER].OrderNumber)
	GROUP BY StaffNIF, StaffID, MONTH(OrderDate)
