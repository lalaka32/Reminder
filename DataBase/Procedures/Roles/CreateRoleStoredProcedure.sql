USE ReminderDB
GO

CREATE PROC CreateRole
	@Name nvarchar(25)

AS
	INSERT Roles([Name])
	VALUES
	(@Name)
