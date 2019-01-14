USE ReminderDB
GO

CREATE PROC DeleteCategory
	@Id int
AS
	DELETE Categories
		WHERE Id = @id