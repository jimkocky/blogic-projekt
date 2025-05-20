CREATE PROCEDURE ProcProductInsert
    @Name NVARCHAR(255),
    @ImageUrl NVARCHAR(500),
    @Quantity INT,
    @Price DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO Products (Name, ImageUrl, Quantity, Price)
    VALUES (@Name, @ImageUrl, @Quantity, @Price);
END;
