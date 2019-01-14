USE ReminderDB
GO

CREATE PROC CreateUser
	@RoleId INT,
	@Login nvarchar(25),
	@Password nvarchar(25),
	@UserName nvarchar(25),
	@Email nvarchar(50)
AS
	INSERT Users([RoleId],[Login], [Password], [UserName], [Email])
	VALUES
	(@RoleId, @Login, @Password, @UserName, @Email)
