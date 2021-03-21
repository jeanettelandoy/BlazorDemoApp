CREATE TABLE [dbo].[Transportation]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CompanyName] NVARCHAR(50) NULL, 
    [TransportationName] NVARCHAR(50) NULL, 
    [TransportationType] NVARCHAR(50) NULL, 
    [TransportationCharacteristics] NVARCHAR(MAX) NULL, 
    [Registered] DATETIME2 NULL
)
