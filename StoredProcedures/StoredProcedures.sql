USE p5g4;
GO;

-- this procedure as the intent to add a new costumer to the Person table as well
CREATE PROC Project.addCostumer
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
GO;

-- procedure to when a new user is added, to also add to the Person table
CREATE PROC Project.addUser
@nif CHAR(9), @addr VARCHAR(30), @name VARCHAR(50), @phone CHAR(9), @email VARCHAR(30), @bdate DATE,
@password VARCHAR(20), @username VARCHAR(30), @salary INT
AS
    -- the user ID is automatically
    DECLARE @userID INT;
    SET @userID = ((SELECT COUNT(*) FROM p5g4.Project.[USER]) + 1)

    -- the register date is todays date so:
    DECLARE @todayDate DATE;
    SET @todayDate = GETDATE();

    BEGIN TRAN
        BEGIN TRY
            IF NOT EXISTS(SELECT NIF FROM p5g4.Project.PERSON WHERE NIF=@nif)
                INSERT INTO p5g4.Project.PERSON VALUES (@nif, @addr, @name, @phone, @email, @bdate)
                INSERT INTO p5g4.Project.[USER] VALUES (@nif, @userID, @todayDate, @password, @username, @salary)
            COMMIT TRAN
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
            RAISERROR('Not able to insert User (NIF already in the DB)', 16, 1)
        END CATCH
GO;

-- procedure to add new manager, also adding it to the user and person table
-- for this to work the store must exitst (obviously)
CREATE PROC Project.addManager
@nif CHAR(9), @addr VARCHAR(30), @name VARCHAR(50), @phone CHAR(9), @email VARCHAR(30), @bdate DATE,
@password VARCHAR(20), @username VARCHAR(30), @salary INT,
@url VARCHAR(50)
AS
    BEGIN TRAN
        BEGIN TRY
            IF NOT EXISTS(SELECT NIF FROM p5g4.Project.PERSON WHERE NIF=@nif)
            BEGIN
                EXEC p5g4.Project.addUser @nif, @addr, @name, @phone, @email, @bdate, @password, @username, @salary

                DECLARE @userID INT;
                SET @userID = (SELECT ID FROM p5g4.Project.[USER] WHERE UserNIF=@nif);

                INSERT INTO p5g4.Project.Manager VALUES (@nif, @userID, @url)
                END
            COMMIT TRAN
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
            RAISERROR('Not able to insert Manager (NIF already in the DB)', 16, 1)
            -- SELECT ERROR_MESSAGE() AS ErrorMessage;
        END CATCH
GO;

-- procedure to add new staff member, also adding it to the user and person table
-- for this to work the store must exitst (obviously)
CREATE PROC Project.addStaff
@nif CHAR(9), @addr VARCHAR(30), @name VARCHAR(50), @phone CHAR(9), @email VARCHAR(30), @bdate DATE,
@password VARCHAR(20), @username VARCHAR(30), @salary INT,
@url VARCHAR(50)
AS
    BEGIN TRAN
        BEGIN TRY
            IF NOT EXISTS(SELECT NIF FROM p5g4.Project.PERSON WHERE NIF=@nif)
            BEGIN
                EXEC p5g4.Project.addUser @nif, @addr, @name, @phone, @email, @bdate, @password, @username, @salary

                DECLARE @userID INT;
                SET @userID = (SELECT ID FROM p5g4.Project.[USER] WHERE UserNIF=@nif);

                INSERT INTO p5g4.Project.Staff VALUES (@nif, @userID, @url)
            END
            COMMIT TRAN
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
            RAISERROR('Not able to insert Staff (NIF already in the DB)', 16, 1)
        END CATCH
GO;