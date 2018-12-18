USE ReminderDB
GO

CREATE PROC CreateUser
	@Email nvarchar(50),
	@Password nvarchar(25),
	@UserName nvarchar(25),
	@Login nvarchar(25)
AS
	INSERT Users([UserName], [Login], [Password], [Email])
	VALUES
	(@UserName, @Login, @Password, @Email)