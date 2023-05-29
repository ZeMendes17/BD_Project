CREATE TRIGGER PreventDeleteItem
ON Project.ITEM
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Verifica se o item está relacionado com pedidos com estado diferente de 'delivered' ou 'shipped'
    IF EXISTS (
        SELECT 1
        FROM Project.ITEM i
        JOIN Project.ITEM_ORDER io ON i.ID = io.ItemID
        JOIN Project.[ORDER] o ON io.OrderNumber = o.OrderNumber AND io.CostumerNIF = o.CostumerNIF
        WHERE i.ID IN (SELECT ID FROM deleted)
          AND o.OrderState NOT IN ('delivered', 'shipped')
    )
    BEGIN
        RAISERROR('Não é possível excluir o item. Ele está relacionado com pedidos com estado diferente de "delivered" ou "shipped".', 16, 1);
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        -- Deleta o item
        DELETE FROM Project.ITEM
        WHERE ID IN (SELECT ID FROM deleted);
    END
END;
