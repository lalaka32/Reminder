USE ReminderDB
GO

CREATE PROC UpdateReminder
	@Id int,
	@UserId int,
	@StateId int,
	@CategoryId int,
	@Name nvarchar(30),
	@Description nvarchar(200),
	@DateOfCreation datetime,
	@DateOfEvent datetime,
	@Picture varbinary(max)
AS
	UPDATE Reminders
		SET 
		[UserId] = @UserId,
		[StateId] = @StateId,
		[CategoryId] = @CategoryId,
		[Name] = @Name, 
		[Description] = @Description,
		[DateOfCreation] = @DateOfCreation, 
		[DateOfEvent] = @DateOfEvent, 
		[Picture] = @Picture
		WHERE Id = @id