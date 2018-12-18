USE ReminderDB
GO

CREATE PROC CreateNotification
	@Name nvarchar(30),
	@Description nvarchar(200),
	@DateOfCreation datetime,
	@DateOfEvent datetime,
	@ImagePath nvarchar(200)
AS
	INSERT Notifications([Name], [Description], [DateOfCreation], [DateOfEvent], [ImagePath])
	VALUES
	(@Name, @Description, @DateOfCreation, @DateOfEvent, @ImagePath)