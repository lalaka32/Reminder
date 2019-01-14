USE ReminderDB
GO

CREATE PROC SelectCategoryById
	@Id int
AS
	SELECT * FROM Categories
	WHERE Id = @Id