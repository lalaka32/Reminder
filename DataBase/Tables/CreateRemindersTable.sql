USE ReminderDB;
GO

IF OBJECT_ID('Reminders') IS NOT NULL
DROP TABLE Reminders
GO

CREATE TABLE Reminders(
	Id int PRIMARY KEY IDENTITY,
    UserId int NOT NULL,
    [StateId] INT NOT NULL,
    [CategoryId] INT NOT NULL,
	[Name] nvarchar(50) NOT NULL,
	[Description] nvarchar(300) NULL,
    DateOfCreation datetime NOT NULL,
    DateOfEvent datetime NOT NULL,
    Picture varbinary(max),
);