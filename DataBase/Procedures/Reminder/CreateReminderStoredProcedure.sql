USE ReminderDB
GO

CREATE PROC CreateReminder
	@UserId int,
	@StateId int,
	@CategoryId int,
	@Name nvarchar(30),
	@Description nvarchar(200),
	@DateOfCreation datetime,
	@DateOfEvent datetime,
	@Picture varbinary(max)
AS
	INSERT Reminders([UserId], [StateId], [CategoryId], [Name], [Description], [DateOfCreation], [DateOfEvent], [Picture])
	VALUES
	(@UserId, @StateId, @CategoryId, @Name, @Description, @DateOfCreation, @DateOfEvent, @Picture)