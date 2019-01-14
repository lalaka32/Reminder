USE ReminderDB;
GO

IF OBJECT_ID('States') IS NOT NULL
DROP TABLE [States]
GO

CREATE TABLE [States](
	Id int PRIMARY KEY IDENTITY,
	[Name] nvarchar(25),
);