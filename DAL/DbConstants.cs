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

		public const string CREATE_NOTIFICATION = "CreateNotification";
		public const string DELETE_NOTIFICATION = "DeleteNotification";
		public const string UPDATE_NOTIFICATION = "UpdateNotification";
		public const string GET_ALL_NOTIFICATION = "SelectAllNotifications";
		public const string GET_NOTIFICATION_BY_ID = "SelectNotificationById";


		public const string CREATE_ROLE = "CreateRole";
		public const string DELETE_ROLE = "DeleteRole";
		public const string UPDATE_ROLE = "UpdateRole";
		public const string GET_ALL_ROLES = "SelectAllRole";
		public const string GET_ROLE_BY_ID = "SelectRoleById";


		public const string CREATE_USER = "CreateUser";
		public const string DELETE_USER = "DeleteUser";
		public const string GET_ALL_USERS = "SelectAllUsers";
		public const string GET_USER_BY_ID = "SelectUserById";
		public const string UPDATE_USER = "UpdateUser";


		public static string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionReminderDB"].ConnectionString;

	}
}
