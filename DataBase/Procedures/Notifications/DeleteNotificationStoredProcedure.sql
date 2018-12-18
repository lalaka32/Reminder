USE ReminderDB
GO

CREATE PROC DeleteNotification 
	@Id int
AS
	DELETE Notifications
		WHERE Id = @id