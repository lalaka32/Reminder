USE ReminderDB
GO

CREATE PROC SelectAllUsers
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
	 	LEFT JOIN Roles r 
			ON u.RoleId = r.Id 

			