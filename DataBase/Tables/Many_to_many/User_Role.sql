USE ReminderDB
GO

IF OBJECT_ID('UserAndRole') IS NOT NULL
DROP TABLE UserAndRole
GO

CREATE TABLE UserAndRole(
	UserId int NOT NULL,
	RoleId int NOT NULL,
);