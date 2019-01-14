USE ReminderDB
GO

CREATE PROC CreateState
	@Name nvarchar(50)
AS
	INSERT [States]([Name])
	VALUES
	(@Name)