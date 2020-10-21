USE [GroceryWebAppDB]

--Drop Tables if they already exist in the Database
IF OBJECT_ID('Item', 'U') IS NOT NULL 
DROP TABLE Item

IF OBJECT_ID('GroceryList', 'U') IS NOT NULL 
DROP TABLE GroceryList

IF OBJECT_ID('Account', 'U') IS NOT NULL
DROP TABLE Account

GO

--Table Creation

--Account Table which stores information for each user account
CREATE TABLE Account
(
	AccountId	INT		IDENTITY(1,1)	NOT NULL	PRIMARY KEY,
	Username	[NVARCHAR](255)			NOT NULL,
	EncryptedPassword [NVARCHAR](50)	NOT NULL
);

--GroceryList Table which stores information for a list associated with an account
CREATE TABLE GroceryList
(
	GroceryListId	INT		IDENTITY(1,1)	NOT NULL	PRIMARY KEY,
	Name			[NVARCHAR](50)			NOT NULL,
	AccountId		INT						NOT NULL,
	Date			DATETIME				NOT NULL,
	CONSTRAINT FK_ListAccount FOREIGN KEY (AccountId) REFERENCES Account(AccountId)
);

--Item Table which stores information for an item associated with a grocery list
CREATE TABLE Item
(
   ItemId			INT		IDENTITY(1,1)		NOT NULL   PRIMARY KEY, 
   Name				[NVARCHAR](50)				NOT NULL,
   Checkoff			BIT							NOT NULL	DEFAULT(0),
   Date				DATETIME					NOT NULL,
   GroceryListId	INT							NOT NULL,
   CONSTRAINT FK_ListItem FOREIGN KEY (GroceryListId) REFERENCES GroceryList(GroceryListId)
);

GO
