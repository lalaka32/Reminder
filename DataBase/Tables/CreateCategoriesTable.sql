USE ReminderDB;
GO

IF OBJECT_ID('Categories') IS NOT NULL
DROP TABLE Categories
GO

CREATE TABLE Categories(
	Id int PRIMARY KEY IDENTITY,
	[Name] nvarchar(25),
);