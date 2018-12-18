USE ReminderDB
GO

IF OBJECT_ID('NotificationAndCategory') IS NOT NULL
DROP TABLE NotificationAndCategory
GO

CREATE TABLE NotificationAndCategory(
	NotificationId int NOT NULL,
	CategoryId int NOT NULL,
);