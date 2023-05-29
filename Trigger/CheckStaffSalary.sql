CREATE TRIGGER [Project].[CheckStaffSalary]
ON [Project].[STAFF]
AFTER INSERT, UPDATE
AS
BEGIN
    -- Verifica se há pelo menos um registro inserido ou atualizado
    IF (EXISTS(SELECT 1 FROM inserted))
    BEGIN
        -- Verifica para cada registro inserido ou atualizado
        IF EXISTS(
            SELECT 1
            FROM inserted i
            INNER JOIN Project.MANAGER m ON i.StoreURL = m.StoreURL
            INNER JOIN Project.[USER] us ON i.StaffNIF = us.UserNIF AND i.ID = us.ID
            WHERE us.Salary > (SELECT Salary FROM Project.[USER] WHERE UserNIF = m.ManagerNIF AND ID = m.ID)
        )
        BEGIN
            -- Caso algum usuário do tipo "Staff" tenha salário maior do que o usuário do tipo "Manager" na mesma loja
            RAISERROR ('O salário do usuário "Staff" não pode ser maior do que o salário do usuário "Manager" na mesma loja.', 16, 1);
            ROLLBACK TRANSACTION; -- Impede a operação de ser concluída
            RETURN;
        END
    END
END;
