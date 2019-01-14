USE ReminderDB
GO

CREATE PROC UpdateUser 
	@Id int, 
	@RoleId INT,
	@Email nvarchar(50),
	@Password nvarchar(25),
	@UserName nvarchar(25),
	@Login nvarchar(25)
AS
	UPDATE Users
		SET 
		[RoleId] = @RoleId,
		[Login] = @Login,
		[Password] = @Password,
		[UserName] = @UserName, 
		[Email] = @Email
		WHERE Id = @id