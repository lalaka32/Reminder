USE ReminderDB
GO

CREATE PROC SelectStatesById
	@Id int
AS
	SELECT * FROM States
	WHERE Id = @Id