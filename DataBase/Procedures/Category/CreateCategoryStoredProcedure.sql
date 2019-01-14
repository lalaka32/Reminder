USE ReminderDB
GO

CREATE PROC CreateCategory
	@Name nvarchar(25)
AS
	INSERT Categories([Name])
	VALUES
	(@Name)