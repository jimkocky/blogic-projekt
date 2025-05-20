CREATE PROCEDURE ProcUsers
AS
BEGIN 
SELECT UserId, Name, Email, ImageUrl, Role
FROM Users
END;
