--This SQL script creates a stored procedure in the GroceryWebAppDB
--The stored procedure selects the necessary columns from GroceryList for a given user ID,
--which are used in the GListAccessor to create GList objects

CREATE PROC Find_GroceryLists_For_Given_Account @userId INT
AS
    SET NOCOUNT ON;
    SELECT GroceryListId, Name, Date, AccountId FROM GroceryList WHERE AccountId = @userId; 
GO