USE ReminderDB
GO

DECLARE @UserId int,
	@StateId int,
	@CategoryId int,
	@Name nvarchar(30),
	@Description nvarchar(200),
	@DateOfCreation datetime,
	@DateOfEvent datetime,
	@Picture varbinary(max);

SET @Name = 'New Year Party !!!'
SET @UserId = 1
SET @StateId = 3
SET @CategoryId = 10
SET @Description = 'It will be cool event with my friends'
SET @DateOfCreation = '2018-12-12 16:20:00.000'
SET @DateOfEvent = '2018-31-12 23:00:00.000'
SET @Picture = null
EXECUTE CreateReminder @UserId, @StateId, @CategoryId, @Name, @Description, @DateOfCreation, @DateOfEvent, @Picture

SET @UserId = 2
EXECUTE CreateReminder @UserId, @StateId, @CategoryId, @Name, @Description, @DateOfCreation, @DateOfEvent, @Picture

SET @UserId = 3
EXECUTE CreateReminder @UserId, @StateId, @CategoryId, @Name, @Description, @DateOfCreation, @DateOfEvent, @Picture

SET @Name = 'Cloth shopping'
SET @UserId = 1
SET @StateId = 1
SET @CategoryId = 6
SET @Description = 'I need to buy some cloth'
SET @DateOfCreation = '2019-01-05 12:46:00.000'
SET @DateOfEvent = '2019-23-04 19:00:00.000'
SET @Picture = null
EXECUTE CreateReminder @UserId, @StateId, @CategoryId, @Name, @Description, @DateOfCreation, @DateOfEvent, @Picture

SET @UserId = 2
EXECUTE CreateReminder @UserId, @StateId, @CategoryId, @Name, @Description, @DateOfCreation, @DateOfEvent, @Picture

SET @UserId = 3
EXECUTE CreateReminder @UserId, @StateId, @CategoryId, @Name, @Description, @DateOfCreation, @DateOfEvent, @Picture


SET @Name = 'Wash dishes'
SET @UserId = 1
SET @StateId = 2
SET @CategoryId = 5
SET @Description = 'I have to wash my dishes'
SET @DateOfCreation = '2019-01-05 12:46:00.000'
SET @DateOfEvent = '2019-23-03 19:00:00.000'
SET @Picture =NULL
EXECUTE CreateReminder @UserId, @StateId, @CategoryId, @Name, @Description, @DateOfCreation, @DateOfEvent, @Picture

SET @UserId = 2
EXECUTE CreateReminder @UserId, @StateId, @CategoryId, @Name, @Description, @DateOfCreation, @DateOfEvent, @Picture

SET @UserId = 3
EXECUTE CreateReminder @UserId, @StateId, @CategoryId, @Name, @Description, @DateOfCreation, @DateOfEvent, @Picture
