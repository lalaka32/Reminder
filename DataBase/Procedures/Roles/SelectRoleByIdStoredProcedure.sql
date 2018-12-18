USE ReminderDB
GO

CREATE PROC SelectRoleById
	@Id int
AS
	SELECT * FROM Roles
	WHERE Id = @Id