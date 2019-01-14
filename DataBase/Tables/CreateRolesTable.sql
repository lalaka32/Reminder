USE ReminderDB;
GO

IF OBJECT_ID('Roles') IS NOT NULL
DROP TABLE Roles
GO

CREATE TABLE Roles(
	Id int PRIMARY KEY IDENTITY,
	[Name] nvarchar(25),
);