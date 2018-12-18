USE ReminderDB
GO

CREATE PROC UpdateNotification
	@Id int,
	@Name nvarchar(30),
	@Description nvarchar(200),
	@DateOfCreation datetime,
	@DateOfEvent datetime,
	@ImagePath nvarchar(200)
AS
	UPDATE Notifications
		SET 
		[Name] = @Name, 
		[DateOfCreation] = @DateOfCreation, 
		[DateOfEvent] = @DateOfEvent, 
		[ImagePath] = @ImagePath, 
		[Description] = @Description
		WHERE Id = @id