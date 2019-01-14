set sqlServer="ANTON"
set currentPath=%~dp0


sqlcmd -S %sqlServer% -i DropDataBase.sql
sqlcmd -S %sqlServer% -i CreateDataBase.sql

sqlcmd -S %sqlServer% -i Tables/CreateActionsTable.sql
sqlcmd -S %sqlServer% -i Tables/CreateCategoriesTable.sql
sqlcmd -S %sqlServer% -i Tables/CreateRemindersTable.sql
sqlcmd -S %sqlServer% -i Tables/CreateUsersTable.sql
sqlcmd -S %sqlServer% -i Tables/CreateStatesTable.sql
sqlcmd -S %sqlServer% -i Tables/CreateRolesTable.sql

sqlcmd -S %sqlServer% -i Relationship/CteateRelationships.sql

sqlcmd -S %sqlServer% -i Procedures/Reminder/CreateReminderStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Reminder/DeleteReminderStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Reminder/SelectAllRemindersStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Reminder/SelectReminderByIdStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Reminder/UpdateReminderStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Reminder/SelectReminderByUserIdStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Reminder/SelectReminderByLoginStoredProcedure.sql

sqlcmd -S %sqlServer% -i Procedures/Roles/CreateRoleStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Roles/SelectAllRolesStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Roles/SelectRoleByIdStoredProcedure.sql

sqlcmd -S %sqlServer% -i Procedures/Users/CreateUserStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Users/DeleteUserStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Users/SelectAllUsersStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Users/SelectUserByIdStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Users/UpdateUserStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Users/SelectUserByLoginStoredProcedure.sql

sqlcmd -S %sqlServer% -i Procedures/State/CreateStateStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/State/SelectAllStatesStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/State/SelectStateByIdStoredProcedure.sql

sqlcmd -S %sqlServer% -i Procedures/Category/CreateCategoryStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Category/DeleteCategoryStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Category/SelectAllCategoriesStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Category/SelectCategoryByIdStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Category/UpdateCategoryStoredProcedure.sql

sqlcmd -S %sqlServer% -i Procedures/Actions/CreateActionStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Actions/DeleteActionStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Actions/SelectAllActionsStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Actions/SelectActionByIdStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Actions/SelectActionByReminderIdStoredProcedure.sql
sqlcmd -S %sqlServer% -i Procedures/Actions/UpdateActionStoredProcedure.sql


sqlcmd -S %sqlServer% -i Initialize/Roles/InitRoles.sql
sqlcmd -S %sqlServer% -i Initialize/State/InitState.sql
sqlcmd -S %sqlServer% -i Initialize/Users/InitUsers.sql
sqlcmd -S %sqlServer% -i Initialize/Category/InitCategories.sql
sqlcmd -S %sqlServer% -i Initialize/Reminder/InitReminders.sql

PAUSE