CREATE FUNCTION Project.getOrderTransportInfo(@OrderNumber INT) RETURNS TABLE
AS
    RETURN (
        SELECT TransportNumber, CompanyName, CompanyEmail, Method
        FROM Project.DELIVERS JOIN Project.TRANSPORT ON Project.DELIVERS.TransportNumber = Project.TRANSPORT.TransportNumber
        WHERE Project.DELIVERS.OrderNumber = @OrderNumber
    );