USE ReminderDB
GO

DECLARE	@Email nvarchar(50),
	@RoleId int,
	@Password nvarchar(25),
	@UserName nvarchar(25),
	@Login nvarchar(25);

SET @Email = 'User@mail.com'
SET @RoleId = 1
SET @Password = 'User123'
SET @UserName = 'UserName'
SET @Login = 'User'
EXECUTE CreateUser @RoleId, @Login, @Password, @UserName, @Email

SET @Email = 'Moderator@mail.com'
SET @RoleId = 2
SET @Password = 'Moderator123'
SET @UserName = 'ModeratorName'
SET @Login = 'Moderator'
EXECUTE CreateUser @RoleId, @Login, @Password, @UserName, @Email

SET @Email = 'Admin@mail.com'
SET @RoleId = 3
SET @Password = 'Admin123'
SET @UserName = 'AdminName'
SET @Login = 'Admin'
EXECUTE CreateUser @RoleId, @Login, @Password, @UserName, @Email

SET @Email = 'User2@mail.com'
SET @Password = 'User123'
SET @UserName = 'UserName2'
SET @Login = 'User2'
EXECUTE CreateUser @RoleId, @Login, @Password, @UserName, @Email