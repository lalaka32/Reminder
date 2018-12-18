USE ReminderDB
GO

CREATE PROC SelectUserById
	@Id int
AS
	SELECT * FROM Users
	WHERE Id = @Id