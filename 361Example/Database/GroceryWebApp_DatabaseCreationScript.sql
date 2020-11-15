--This script was used in SMSS in order to create a local database for testing purposes

USE master
GO
IF NOT EXISTS (
   SELECT name
   FROM sys.databases
   WHERE name = N'GroceryWebAppDB'
)
CREATE DATABASE [GroceryWebAppDB]
GO

ALTER DATABASE [GroceryWebAppDB] SET QUERY_STORE=ON
GO