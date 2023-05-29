CREATE TRIGGER PreventDeleteTransport
ON Project.TRANSPORT
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar se existem pedidos associados ao transporte com OrderState diferente de "delivered" na tabela "deleted"
    IF EXISTS (
        SELECT 1
        FROM deleted d
        INNER JOIN Project.[ORDER] o ON d.OrderNumber = o.OrderNumber AND d.CostumerNIF = o.CostumerNIF
        WHERE o.OrderState <> 'delivered'
    )
    BEGIN
        RAISERROR('Não é possível excluir um transporte associado a pedidos que não estão no estado "delivered".', 16, 1);
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        -- Excluir os transportes que não estão associados a pedidos não "delivered"
        DELETE FROM Project.TRANSPORT
        WHERE TransportNumber IN (SELECT TransportNumber FROM deleted)
          AND NOT EXISTS (
              SELECT 1
              FROM Project.[ORDER] o
              WHERE o.TransportNumber = Project.TRANSPORT.TransportNumber
                AND o.OrderState <> 'delivered'
          );
    END
END;
