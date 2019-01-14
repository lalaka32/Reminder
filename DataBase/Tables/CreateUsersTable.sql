USE ReminderDB;
GO

IF OBJECT_ID('Users') IS NOT NULL
DROP TABLE Users
GO

CREATE TABLE Users(
	Id int PRIMARY KEY IDENTITY,
	RoleId int NOT NULL,
	[Login] nvarchar(25) UNIQUE,
	[Password] nvarchar(25) NOT NULL,
	[UserName] nvarchar(25) NOT NULL,
	Email nvarchar(50) UNIQUE,
);