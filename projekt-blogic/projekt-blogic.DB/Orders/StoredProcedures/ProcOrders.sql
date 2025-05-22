CREATE PROCEDURE [dbo].[ProcOrders]
AS
BEGIN
	SELECT 
		o.OrderId, 
		o.DateCreated, 
		u.UserId, 
		u.Name AS UserName,
		p.ProductId,
		p.Name AS ProductName
	FROM Orders o
	JOIN Products p ON o.ProductId = p.ProductID
	JOIN Users u ON o.UserId = u.UserId
END;