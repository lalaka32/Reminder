USE ReminderDB
GO

CREATE PROC UpdateAction
	@Id int,
	@ReminderId int,
	@Description nvarchar(100)
AS
	UPDATE Actions
		SET 
		[ReminderId] = @ReminderId,
		[Description] = @Description
		WHERE Id = @id