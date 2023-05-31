CREATE FUNCTION Project.getStoreRevenue(@StoreURL VARCHAR(50)) RETURNS TABLE
AS
RETURN
(
    SELECT s.StoreName, SUM(o.Price) AS TotalSales
    FROM Project.STORE s
    LEFT JOIN Project.[ORDER] o ON s.StoreURL = o.StoreURL
	WHERE s.StoreURL=@StoreURL
    GROUP BY s.StoreName
);