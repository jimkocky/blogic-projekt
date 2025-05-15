CREATE TABLE [dbo].[Products]
(
	[ProductID] INT NOT NULL PRIMARY KEY, 
    [DateCreated] DATETIME NULL DEFAULT GETDATE(), 
    [CreatedBy] INT NULL DEFAULT 0, 
    [DateUpdated] DATETIME NULL DEFAULT GETDATE(), 
    [UpdatedBy] INT NULL DEFAULT 0, 
    [IsDeleted] BIT NULL DEFAULT 0, 
    [Name] NVARCHAR(512) NULL, 
    [Price] INT NULL, 
    [Quantity] INT NULL, 
    [ImageURL] NVARCHAR(1024) NULL
)
