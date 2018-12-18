USE ReminderDB;
GO

IF OBJECT_ID('Doings') IS NOT NULL
DROP TABLE Doings
GO

CREATE TABLE Doings(
	Id int PRIMARY KEY IDENTITY,
	[Name] nvarchar(25) ,
	[Description] nvarchar(50)
);