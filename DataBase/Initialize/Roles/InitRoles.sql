USE ReminderDB
GO


DECLARE @Name nvarchar(25);

SET @Name = 'User'
EXECUTE CreateRole @Name

SET @Name = 'Moderator'
EXECUTE CreateRole @Name

SET @Name = 'Admin'
EXECUTE CreateRole @Name