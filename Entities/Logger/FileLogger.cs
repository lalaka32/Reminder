using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Logger
{
	public class FileLogger : IFileLogger
	{
		private const string LOGGER_NAME = "FileLogger";
		private readonly ILog _logger;

		public FileLogger()
		{
			var config = GetConfigFile("app.config");

			if (config.Exists)
			{
				XmlConfigurator.Configure(config);

				_logger = LogManager.GetLogger(LOGGER_NAME);
			}
		}

		private FileInfo GetConfigFile(string configName)
		{
			string fullPath = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), configName);

			var fileInfo = new FileInfo(fullPath);

			return fileInfo;
		}

		public void WriteToFile(string message)
		{
			_logger.Info(message);
		}
	}
}
