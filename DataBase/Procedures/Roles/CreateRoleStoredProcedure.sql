USE ReminderDB
GO

CREATE PROC CreateRole
	@Name nvarchar(30),
	@Description nvarchar(200)
AS
	INSERT Roles([Name], [Description])
	VALUES
	(@Name, @Description)