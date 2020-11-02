USE [GroceryWebAppDB]

--Testing Script

--Inserting Test Data into GroceryWebAppDB Tables

--Account Test Data
INSERT Account (Username, EncryptedPassword)
	VALUES	('johnsmith@gmail.com', 'dlka3jgd45'),
			('johndoe@hotmail.com', 'sdjdsbf'),
			('helloworld@cse.edu', 'jfioseufho'),
			('ihavenolists@gmail.com', 'sfljrred2')





--Item Test Data
INSERT Item (Name, Date, GroceryListId, CheckOff, Quantity)
	VALUES	('Bread', '2020-09-29 05:40:23', 1,0, 3),
			('Milk', '2020-09-14 06:23:19', 1, 0, 1),
			('Toilet Paper', '2020-09-06 19:42:03', 1, 0, 1),
			('Butter', '2020-09-02 19:42:03', 1, 0, 2),
			('Bagels', '2020-09-16 19:42:03', 2, 1, 2),
			('Lettuce', '2020-09-18 23:42:03 ', 2, 1, 4),
			('Apples', '2020-09-22 19:42:03', 3, 1, 6),
			('Carrots', '2020-09-24 19:42:03', 4, 1, 2),
			('Cabbage', '2020-09-29 19:42:03', 1, 0, 1)

GO
