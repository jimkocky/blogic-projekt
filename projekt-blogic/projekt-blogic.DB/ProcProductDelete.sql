CREATE PROCEDURE ProcProductDelete
    @ProductId INT
AS
BEGIN
    UPDATE Products
    SET 
        IsDeleted = 1,
        DateUpdated = GETDATE()
    WHERE ProductId = @ProductId AND IsDeleted = 0;
END;