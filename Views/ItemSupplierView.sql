CREATE VIEW Project.ItemSupplierView
AS
	SELECT SupplierID, ItemID, SupName, Email, SupLocation
    FROM Project.SUPPLIES JOIN Project.SUPPLIER ON SupplierID=ID