USE [GroceryWebAppDB]

--Testing Script

--Inserting Test Data into GroceryWebAppDB Tables

--Account Test Data
INSERT Account (Username, EncryptedPassword)
	VALUES	('johnsmith@gmail.com', 'dlka3jgd45'),
			('johndoe@hotmail.com', 'sdjdsbf'),
			('helloworld@cse.edu', 'jfioseufho')


--GroceryList Test Data
INSERT GroceryList (Name, AccountId)
	VALUES	('First List', 1),
			('Sunday List', 1),
			('Groceries', 2),
			('Food', 3)


--Item Test Data
INSERT Item (Name, Date, GroceryListId)
	VALUES	('Bread', '2020-09-29', 1),
			('Milk', '2020-09-14', 1),
			('Toilet Paper', '2020-09-06', 1),
			('Butter', '2020-09-02', 1),
			('Bagels', '2020-09-16', 2),
			('Lettuce', '2020-09-18', 2),
			('Apples', '2020-09-22', 3),
			('Carrots', '2020-09-24', 4)

GO