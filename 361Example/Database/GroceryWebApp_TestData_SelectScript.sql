USE [GroceryWebAppDB]

--Testing Script

--SELECT * used strictly for testing purposes

--Shows all Account data
SELECT * 
	FROM Account


--Shows all GroceryList data
SELECT *
	FROM GroceryList


--Shows all GroceryList data with corresponding Account data for all lists in the database
SELECT GroceryListId, Name, Account.AccountId, Username, EncryptedPassword 
	FROM GroceryList JOIN Account ON GroceryList.AccountId = Account.AccountId


--Shows all GroceryList data with corresponding Account data for Account with Id = 1
SELECT GroceryListId, Name, Account.AccountId, Username 
	FROM GroceryList JOIN Account ON GroceryList.AccountId = Account.AccountId 
	WHERE Account.AccountId = 1


--Shows all GroceryList data with corresponding Account data for Account with Username 'johnsmith@gmail.com'
SELECT GroceryListId, Name, Account.AccountId, Username 
	FROM GroceryList JOIN Account ON GroceryList.AccountId = Account.AccountId 
	WHERE Account.Username = 'johnsmith@gmail.com'


--Shows all Item data
SELECT *
	FROM Item


--Shows all Item data with corresponding GroceryList data for all items in the database
SELECT ItemId, Item.Name, Checkoff, Date, Item.GroceryListId, GroceryList.Name
	FROM Item JOIN GroceryList ON Item.GroceryListId = GroceryList.GroceryListId


--Shows all Item data with corresponding GroceryList data for GroceryList with Id = 1
SELECT ItemId, Item.Name, Checkoff, Date, Item.GroceryListId, GroceryList.Name
	FROM Item JOIN GroceryList ON Item.GroceryListId = GroceryList.GroceryListId
	WHERE Item.GroceryListId = 1


--Shows all Item data with corresponding GroceryList data for GroceryList with Name 'First List'
SELECT ItemId, Item.Name, Checkoff, Date, Item.GroceryListId, GroceryList.Name
	FROM Item JOIN GroceryList ON Item.GroceryListId = GroceryList.GroceryListId
	WHERE GroceryList.Name = 'First List'


--Shows all Item data with corresponding GroceryList data and corresponding Account data for all items
SELECT ItemId, Item.Name, Checkoff, Date, Item.GroceryListId, GroceryList.Name, Account.AccountId, Account.Username, Account.EncryptedPassword
	FROM Item JOIN GroceryList ON Item.GroceryListId = GroceryList.GroceryListId JOIN Account ON GroceryList.AccountId = Account.AccountId


--Shows all Item data with corresponding GroceryList data and corresponding Account data for Account with Id = 1
SELECT ItemId, Item.Name, Checkoff, Date, Item.GroceryListId, GroceryList.Name, Account.AccountId, Account.Username, Account.EncryptedPassword
	FROM Item JOIN GroceryList ON Item.GroceryListId = GroceryList.GroceryListId JOIN Account ON GroceryList.AccountId = Account.AccountId
	WHERE Account.AccountId = 1


--Shows all Item data with corresponding GroceryList data and corresponding Account data for Account with Username 'helloworld@cse.edu'
SELECT ItemId, Item.Name, Checkoff, Date, Item.GroceryListId, GroceryList.Name, Account.AccountId, Account.Username, Account.EncryptedPassword
	FROM Item JOIN GroceryList ON Item.GroceryListId = GroceryList.GroceryListId JOIN Account ON GroceryList.AccountId = Account.AccountId
	WHERE Account.Username = 'helloworld@cse.edu'


--Query that updates the Checkoff field for a record in the Item table
UPDATE Item
	SET Checkoff = 1
	WHERE ItemId = 1

SELECT * FROM Item WHERE ItemId = 1