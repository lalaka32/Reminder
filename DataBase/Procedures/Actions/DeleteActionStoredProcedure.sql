USE ReminderDB
GO

CREATE PROC DeleteAction
	@Id int
AS
	DELETE Actions
		WHERE Id = @id