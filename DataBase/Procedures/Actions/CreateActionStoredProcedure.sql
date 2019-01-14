USE ReminderDB
GO

CREATE PROC CreateAction
	@ReminderId int,
	@Description nvarchar(100)
AS
	INSERT Actions([ReminderId], [Description])
	VALUES
	(@ReminderId, @Description)