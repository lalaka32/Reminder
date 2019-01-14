USE ReminderDB;
GO

IF OBJECT_ID('Actions') IS NOT NULL
DROP TABLE Actions
GO

CREATE TABLE Actions(
	Id int PRIMARY KEY IDENTITY,
	ReminderId INT NOT NULL,
	[Description] nvarchar(100)
);