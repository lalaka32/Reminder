USE ReminderDB
GO

IF OBJECT_ID('NotificationAndState') IS NOT NULL
DROP TABLE NotificationAndState
GO

CREATE TABLE NotificationAndState(
    Id INT PRIMARY KEY IDENTITY,
	NotificationId int NOT NULL,
	StateId int NOT NULL,
);