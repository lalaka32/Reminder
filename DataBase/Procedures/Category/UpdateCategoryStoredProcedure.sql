USE ReminderDB
GO

CREATE PROC UpdateCategory
	@Id INT,
	@Name nvarchar(25)
AS
	UPDATE Categories
		SET 
		[Name] = @Name
		WHERE Id = @id