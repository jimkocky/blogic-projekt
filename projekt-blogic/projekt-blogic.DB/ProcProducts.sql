

CREATE PROCEDURE ProcProducts
AS
BEGIN
    SELECT ProductId, Name, ImageUrl, Quantity, Price, DateCreated, DateUpdated
    FROM Products
    WHERE IsDeleted = 0
END;
