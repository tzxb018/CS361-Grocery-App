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