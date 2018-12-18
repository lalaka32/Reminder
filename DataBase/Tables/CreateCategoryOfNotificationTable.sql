USE ReminderDB;
GO

IF OBJECT_ID('CategoryOfNotification') IS NOT NULL
DROP TABLE CategoryOfNotification
GO

CREATE TABLE CategoryOfNotification(
	Id int PRIMARY KEY IDENTITY,
	[Name] nvarchar(30) NOT NULL,
);