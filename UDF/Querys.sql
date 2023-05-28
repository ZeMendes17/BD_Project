go
-- 1) todos os manager's de uma loja:

CREATE FUNCTION GetManagersByStoreName(@StoreName VARCHAR(20))
RETURNS TABLE
AS
RETURN
(
    SELECT p.PName
    FROM Project.MANAGER m
    JOIN Project.PERSON p ON m.ManagerNIF = p.NIF
    JOIN Project.STORE s ON m.StoreURL = s.StoreURL
    WHERE s.StoreName = @StoreName
    UNION ALL
    SELECT 'Loja nao encontrada' AS PName
    WHERE NOT EXISTS (
        SELECT 1
        FROM Project.STORE
        WHERE StoreName = @StoreName
    )
);
go

go
-- 2) A lista da staff de uma loja e seus respetivos salarios:

CREATE FUNCTION GetStaffByStoreName(@StoreName VARCHAR(50))
RETURNS TABLE
AS
RETURN
(
    SELECT u.UserName, s.StaffNIF, s.ID, u.Salary
    FROM Project.[USER] u
    JOIN Project.STAFF s ON u.UserNIF = s.StaffNIF AND u.ID = s.ID
    JOIN Project.STORE st ON s.StoreURL = st.StoreURL
    WHERE st.StoreName = @StoreName
    UNION ALL
    SELECT NULL AS UserName, NULL AS StaffNIF, NULL AS ID, NULL AS Salary
    WHERE NOT EXISTS (
        SELECT 1
        FROM Project.STORE
        WHERE StoreName = @StoreName
    )
);
go

go

-- 3) Todas as lojas que tem determinado Manager como respons�vel:

CREATE FUNCTION GetStoreByManagerID(@ManagerID INT)
RETURNS TABLE
AS
RETURN
(
    SELECT s.StoreName, s.StoreDescription
    FROM Project.MANAGER m
    JOIN Project.STORE s ON m.StoreURL = s.StoreURL
    WHERE m.ID = @ManagerID
);
go

go
-- 4) Valor total de venda por loja ordenado do maior para o menor:

SELECT s.StoreName, SUM(o.Price) AS TotalSales
FROM Project.STORE s
LEFT JOIN Project.[ORDER] o ON s.StoreURL = o.StoreURL
GROUP BY s.StoreName
ORDER BY TotalSales DESC;
go

go
-- 5) Lista de ordens em um determinado estado (Pending,shipped ou delivered):

CREATE FUNCTION GetOrdersByState(@OrderState VARCHAR(15))
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM Project.[ORDER]
    WHERE OrderState = @OrderState AND Price > 100
);
go


go
-- 6) Nome e endere�o de um cliente em um pedido:

CREATE FUNCTION GetCustomerByOrderNumber(@OrderNumber INT)
RETURNS TABLE
AS
RETURN
(
    SELECT PName AS CustomerName, Address
    FROM Project.COSTUMER c
    JOIN Project.PERSON p ON c.CostumerNIF = p.NIF
    JOIN Project.[ORDER] o ON c.CostumerNIF = o.CostumerNIF
    WHERE o.OrderNumber = @OrderNumber
);
go


go
-- 7) Para cada loja, listar a quantidade e o pre�o m�dio de vendas em um determinado estado:

CREATE FUNCTION GetStoreStatisticsByOrderState(@OrderState VARCHAR(15))
RETURNS TABLE
AS
RETURN
(
    SELECT s.StoreName, COUNT(o.OrderNumber) AS Quantity, AVG(o.Price) AS AveragePrice
    FROM Project.STORE s
    LEFT JOIN Project.[ORDER] o ON s.StoreURL = o.StoreURL
    WHERE o.OrderState = @OrderState
    GROUP BY s.StoreName
);
go



go
-- 8) Quantidade de itens de uma order:

CREATE FUNCTION GetTotalItemsByOrderNumber(@OrderNumber INT)
RETURNS TABLE
AS
RETURN
(
    SELECT COUNT(*) AS TotalItems
    FROM Project.ITEM_ORDER
    WHERE OrderNumber = @OrderNumber
);
go



go
-- 9) Listar todos os itens de um pedido, juntamente com suas descri��es e quantidades:

CREATE FUNCTION GetItemsByOrderNumber(@OrderNumber INT)
RETURNS TABLE
AS
RETURN
(
    SELECT i.ID, i.ItemDescription
    FROM Project.ITEM i
    JOIN Project.ITEM_ORDER io ON i.ID = io.ItemID
    WHERE io.OrderNumber = @OrderNumber
);
go



go
-- 10) Todos os itens fornecidos por uma determinada empresa:

CREATE FUNCTION GetItemDescriptionBySupplierName(@SupName VARCHAR(50))
RETURNS TABLE
AS
RETURN
(
    SELECT i.ItemDescription
    FROM Project.ITEM i
    JOIN Project.SUPPLIES s ON i.ID = s.ItemID
    JOIN Project.SUPPLIER sup ON s.SupplierID = sup.ID
    WHERE sup.SupName = @SupName
);
go


go
-- 11) Informa��o do m�todo de envio de uma order:

CREATE FUNCTION GetTransportInfoByOrderNumber(@OrderNumber INT)
RETURNS TABLE
AS
RETURN
(
    SELECT t.CompanyName, t.CostumerNIF, t.Cost, t.Method, t.CompanyEmail
    FROM Project.TRANSPORT t
    JOIN Project.[ORDER] o ON t.OrderNumber = o.OrderNumber AND t.CostumerNIF = o.CostumerNIF
    WHERE o.OrderNumber = @OrderNumber
);
go


go
-- 12) A lista dos contatos feitos por um manager com os transportes:

CREATE FUNCTION GetContactTransportInfoByPName(@PName VARCHAR(50))
RETURNS TABLE
AS
RETURN
(
    SELECT p.PName AS Name, m.ManagerNIF AS NIF, m.ID, t.TransportNumber, t.CompanyName, ct.ContactDate, ct.ContactDescription
    FROM Project.CONTACT_TRANSPORT ct
    JOIN Project.MANAGER m ON ct.ManagerNIF = m.ManagerNIF AND ct.ManagerID = m.ID
    JOIN Project.PERSON p ON m.ManagerNIF = p.NIF
    JOIN Project.TRANSPORT t ON ct.TransportNumber = t.TransportNumber AND ct.OrderNumber = t.OrderNumber AND ct.CostumerNIF = t.CostumerNIF
    WHERE p.PName = @PName
);
go




