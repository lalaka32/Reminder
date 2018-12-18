USE ReminderDB;
GO

IF OBJECT_ID('StatesOfNotification') IS NOT NULL
DROP TABLE StatesOfNotification
GO

CREATE TABLE StatesOfNotification(
	Id int PRIMARY KEY IDENTITY,
	[Name] nvarchar(30) NOT NULL,
);