CREATE FUNCTION Project.getManagerInfo(@nif CHAR(9)) RETURNS TABLE
AS
    RETURN (
        SELECT NIF, [Address], PName, PhoneNumb, Email, BirthDate, Manager.ID, RegisterDate, UserPassword, UserName, Salary, StoreURL
        FROM (Project.PERSON JOIN Project.[USER] ON NIF=UserNIF) JOIN Project.MANAGER ON NIF=ManagerNIF
        WHERE NIF=@nif
    );