USE ReminderDB
GO

CREATE PROC SelectUserByLogin
	@Login nvarchar(25)
AS
		SELECT 
			u.Id,
			u.RoleId,
			r.Name AS RoleName,
			u.Login,
			u.Password,
			u.UserName,
			u.Email

	 FROM Users u
	 	JOIN Roles r 
			ON u.RoleId = r.Id 

	WHERE u.Login = @Login