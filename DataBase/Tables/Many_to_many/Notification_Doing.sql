USE ReminderDB
GO

IF OBJECT_ID('NotificationAndDoing') IS NOT NULL
DROP TABLE NotificationAndDoing
GO

CREATE TABLE NotificationAndDoing(
    Id INT PRIMARY KEY IDENTITY,
	NotificationId int NOT NULL,
	DoingId int NOT NULL,
);