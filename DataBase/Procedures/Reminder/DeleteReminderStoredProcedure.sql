USE ReminderDB
GO

CREATE PROC DeleteReminder
	@Id int
AS
	DELETE Reminders
		WHERE Id = @id