set sqlServer="ANTON"
set currentPath=%~dp0


sqlcmd -S %sqlServer% -i DropDataBase.sql
sqlcmd -S %sqlServer% -i CreateDataBase.sql

sqlcmd -S %sqlServer% -i Tables/CreateRolesTable.sql
sqlcmd -S %sqlServer% -i Tables/CreateUsersTable.sql
sqlcmd -S %sqlServer% -i Tables/CreateNotificationsTable.sql
sqlcmd -S %sqlServer% -i Tables/CreateDoingsTable.sql
sqlcmd -S %sqlServer% -i Tables/CreateStatesOfNotificationTable.sql
sqlcmd -S %sqlServer% -i Tables/CreateCategoryOfNotificationTable.sql

sqlcmd -S %sqlServer% -i Tables/Many_to_many/User_Role.sql
sqlcmd -S %sqlServer% -i Tables/Many_to_many/Notification_User.sql
sqlcmd -S %sqlServer% -i Tables/Many_to_many/Notification_State.sql
sqlcmd -S %sqlServer% -i Tables/Many_to_many/Notification_Doing.sql
sqlcmd -S %sqlServer% -i Tables/Many_to_many/Notification_Category.sql


sqlcmd -S %sqlServer% -i Relationship/CteateRelationships.sql



sqlcmd -S %sqlServer% -i Procedures/Notifications/CreateNotificationStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Notifications/DeleteNotificationStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Notifications/SelectAllNotificationsStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Notifications/SelectNotificationByIdStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Notifications/UpdateNotificationStoredProcedure.sql

sqlcmd -S %sqlServer% -i Procedures/Roles/CreateRoleStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Roles/DeleteRoleStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Roles/SelectAllRolesStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Roles/SelectRoleByIdStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Roles/UpdateRoleStoredProcedure.sql

sqlcmd -S %sqlServer% -i Procedures/Users/CreateUserStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Users/DeleteUserStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Users/SelectAllUsersStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Users/SelectUserByIdStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Users/UpdateUserStoredProcedure.sql

PAUSE