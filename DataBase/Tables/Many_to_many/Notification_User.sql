USE ReminderDB;
GO

IF OBJECT_ID('NotificationAndUser') IS NOT NULL
DROP TABLE NotificationAndUser
GO

CREATE TABLE NotificationAndUser(
	Id int PRIMARY KEY IDENTITY,
    Notificationid int NOT NULL,
	UserId int NOT NULL,
);