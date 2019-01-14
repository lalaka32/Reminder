using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	class DbConstants
	{

		public const string CREATE_ROLE = "CreateRole";
		public const string GET_ALL_ROLES = "SelectAllRoles";
		public const string GET_ROLE_BY_ID = "SelectRoleById";

		public const string CREATE_USER = "CreateUser";
		public const string DELETE_USER = "DeleteUser";
		public const string GET_ALL_USERS = "SelectAllUsers";
		public const string GET_USER_BY_ID = "SelectUserById";
		public const string GET_USER_BY_LOGIN = "SelectUserByLogin";
		public const string UPDATE_USER = "UpdateUser";

		public const string CREATE_REMINDER = "CreateReminder";
		public const string DELETE_REMINDER = "DeleteReminder";
		public const string UPDATE_REMINDER = "UpdateReminder";
		public const string GET_ALL_REMINDERS = "SelectAllRemindersStoredProcedure";
		public const string GET_REMINDER_BY_ID = "SelectReminderById";
		public const string GET_REMINDER_BY_USER_ID = "SelectReminderByUserId";
		public const string GET_REMINDER_BY_LOGIN = "SelectReminderByLogin";

		public const string GET_ALL_STATES = "SelectAllStates";
		public const string GET_STATE_BY_ID = "SelectStatesById";

		public const string CREATE_ACTION = "CreateAction";
		public const string DELETE_ACTION = "DeleteAction";
		public const string UPDATE_ACTION = "UpdateAction";
		public const string GET_ALL_ACTIONS = "SelectAllActions";
		public const string GET_ACTION_BY_ID = "SelectActionById";
		public const string GET_ACTION_BY_REMINDER_ID = "SelectActionByReminderId";

		public const string CREATE_CATEGORY = "CreateCategory";
		public const string DELETE_CATEGORY = "DeleteCategory";
		public const string UPDATE_CATEGORY = "UpdateCategory";
		public const string GET_ALL_CATEGORIES = "SelectAllCategories";
		public const string GET_CATEGORY_BY_ID = "SelectCategoryById";


		public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionReminderDB"].ConnectionString;

	}
}
