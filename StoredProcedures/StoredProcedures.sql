USE p5g4;
GO;

CREATE PROC Project.createCostumer
@nif CHAR(9), @addr VARCHAR(30), @name VARCHAR(50), @phone CHAR(9), @email VARCHAR(30), @bdate DATE
AS
    BEGIN TRAN
        BEGIN TRY
            IF NOT EXISTS(SELECT NIF FROM p5g4.Project.PERSON WHERE NIF=@nif)
                INSERT INTO p5g4.Project.PERSON VALUES (@nif, @addr, @name, @phone, @email, @bdate)
                INSERT INTO p5g4.Project.COSTUMER VALUES (@nif)
            COMMIT TRAN
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
            RAISERROR('Not able to insert Costumer (NIF already in the DB)', 16, 1)
        END CATCH