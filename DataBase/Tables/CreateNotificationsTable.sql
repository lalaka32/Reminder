USE ReminderDB;
GO

IF OBJECT_ID('Notifications') IS NOT NULL
DROP TABLE Notifications
GO

CREATE TABLE Notifications(
	Id int PRIMARY KEY IDENTITY,
	[Name] nvarchar(30) NOT NULL,
	[Description] nvarchar(200) NULL,
    DateOfCreation datetime NOT NULL,
    DateOfEvent datetime NOT NULL,
    ImagePath nvarchar(200) NOT NULL,
);