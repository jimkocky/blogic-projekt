CREATE PROCEDURE [dbo].[ProcOrdersDelete]
	@OrderID INT
AS
BEGIN
    DECLARE @ProductID INT;
    SELECT @ProductID = ProductID FROM Orders WHERE OrderID = @OrderID;
    UPDATE Products
    SET Quantity = Quantity + 1
    WHERE ProductID = @ProductID;
    DELETE FROM Orders
    WHERE OrderID = @OrderID;
END
