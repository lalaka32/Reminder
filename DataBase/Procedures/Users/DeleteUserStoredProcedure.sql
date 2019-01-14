USE ReminderDB
GO

CREATE PROC DeleteUser
	@Id int
AS
	DELETE Users
		WHERE Id = @id