CREATE VIEW ItemSupplierView
AS
	SELECT SupplierID, ID, SupName, Email, SupLocation
    FROM Project.SUPPLIES JOIN Project.SUPPLIER ON SupplierID=ID