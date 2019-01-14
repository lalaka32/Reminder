USE ReminderDB
GO

CREATE PROC SelectReminderById
	@Id int
AS
	SELECT r.Id, 
		   u.RoleId,
		   Roles.Name AS RoleName,
		   u.Login,
		   u.Password,
		   u.UserName,
		   u.Email,
		   States.Name AS [State],
		   Categories.Name AS [Category], 
		   r.Name, 
		   r.Description, 
		   r.DateOfCreation, 
		   r.DateOfEvent, 
		   r.Picture,
		   r.UserId,
		   r.StateId,
		   r.CategoryId
		   FROM Reminders r

	JOIN [Users] u
		ON r.UserId = u.Id
	JOIN [States] 
		ON r.StateId = States.Id
	JOIN Categories 
		ON r.CategoryId = Categories.Id
	JOIN [Roles] 
		ON u.RoleId = Roles.Id 

	WHERE r.Id = @Id