﻿using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Logger
{
	public static class Logger
	{
		public static ILog For(object LoggedObject)
		{
			if (LoggedObject != null)
			{
				return For(LoggedObject.GetType());
			}
			else
			{
				return For(null);
			}
		}

		public static ILog For(Type ObjectType)
		{
			if (ObjectType != null)
			{
				return LogManager.GetLogger(ObjectType.Name);
			}
			else
			{
				return LogManager.GetLogger(string.Empty);
			}
		}
	}
}
