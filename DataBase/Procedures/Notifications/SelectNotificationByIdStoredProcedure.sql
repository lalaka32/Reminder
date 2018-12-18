USE ReminderDB
GO

CREATE PROC SelectNotificationById
	@Id int
AS
	SELECT * FROM Notifications
	WHERE Id = @Id