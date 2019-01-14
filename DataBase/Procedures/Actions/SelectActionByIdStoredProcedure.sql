USE ReminderDB
GO

CREATE PROC SelectActionById
	@Id int
AS
	SELECT * FROM Actions
	WHERE Id = @Id