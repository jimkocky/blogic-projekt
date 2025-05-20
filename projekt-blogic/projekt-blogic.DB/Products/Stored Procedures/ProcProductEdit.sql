CREATE PROCEDURE ProcProductEdit
    @ProductId INT,
    @Name NVARCHAR(255),
    @ImageUrl NVARCHAR(500),
    @Quantity INT,
    @Price DECIMAL(10,2)
AS
BEGIN
    UPDATE Products
    SET 
        Name = @Name,
        ImageUrl = ISNULL(@ImageUrl, ImageUrl),
        Quantity = @Quantity,
        Price = @Price,
        DateUpdated = GETDATE()
    WHERE ProductId = @ProductId AND IsDeleted = 0;
END;