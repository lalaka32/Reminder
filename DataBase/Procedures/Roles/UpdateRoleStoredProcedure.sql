USE ReminderDB
GO

CREATE PROC UpdateRole 
	@Id int, 
	@Name nvarchar(30), 
	@Description nvarchar(200)
AS
	UPDATE Roles
		SET 
		[Name] = @Name, 
		[Description] = @Description
		WHERE Id = @id