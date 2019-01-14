USE ReminderDB
GO


DECLARE @Name nvarchar(25);

SET @Name = 'Planned'
EXECUTE CreateState @Name

SET @Name = 'Deferred'
EXECUTE CreateState @Name

SET @Name = 'Completed'
EXECUTE CreateState @Name