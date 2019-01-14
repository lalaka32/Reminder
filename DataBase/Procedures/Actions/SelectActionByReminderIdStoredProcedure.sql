USE ReminderDB
GO

CREATE PROC SelectActionByReminderId
	@ReminderId int
AS
	SELECT * FROM Actions
	WHERE ReminderId = @ReminderId