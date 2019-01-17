using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Logger;
using StructureMap.Configuration.DSL;

namespace Entities.DI
{
	public class EntitiesRegistry : Registry
	{
		public EntitiesRegistry()
		{
			For<IFileLogger>().Singleton().Use<FileLogger>();
		}
	}
}
