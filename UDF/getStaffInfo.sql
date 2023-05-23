CREATE FUNCTION Project.getStaffInfo(@nif CHAR(9)) RETURNS TABLE
AS
    RETURN (
        SELECT NIF, [Address], PName, PhoneNumb, Email, BirthDate, Staff.ID, RegisterDate, UserPassword, UserName, Salary, StoreURL
        FROM (Project.PERSON JOIN Project.[USER] ON NIF=UserNIF) JOIN Project.STAFF ON NIF=StaffNIF
        WHERE NIF=@nif
    );