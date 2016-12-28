CREATE TABLE [dbo].[Inventory]
(
	[CarId] INT NOT NULL PRIMARY KEY IDENTITY (1,1), 
    [Make] NVARCHAR(50) NULL, 
    [Color] NVARCHAR(50) NULL, 
    [PetName] NVARCHAR(50) NULL
)
