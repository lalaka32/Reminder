USE ReminderDB
GO

DECLARE @Name nvarchar(25);

SET @Name = 'Birthday'
EXECUTE CreateCategory @Name

SET @Name = 'Free time'
EXECUTE CreateCategory @Name

SET @Name = 'Rest'
EXECUTE CreateCategory @Name

SET @Name = 'Holiday'
EXECUTE CreateCategory @Name

SET @Name = 'Housework'
EXECUTE CreateCategory @Name

SET @Name = 'Shopping'
EXECUTE CreateCategory @Name

SET @Name = 'Social'
EXECUTE CreateCategory @Name

SET @Name = 'Sport'
EXECUTE CreateCategory @Name

SET @Name = 'Learning'
EXECUTE CreateCategory @Name

SET @Name = 'Party'
EXECUTE CreateCategory @Name

SET @Name = 'Work'
EXECUTE CreateCategory @Name