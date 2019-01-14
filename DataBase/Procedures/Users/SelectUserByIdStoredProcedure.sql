USE ReminderDB
GO

CREATE PROC SelectUserById
	@Id int
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

	WHERE u.Id = @Id