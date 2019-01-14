using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helpers.Interfaces
{
	public interface IConnectionHelper
	{
		IConnectionHelper CreateConnection();
		IConnectionHelper CreateCommand(string name);
		IConnectionHelper AddParameter(params IDataParameter[] parameters);
		IEnumerable<IDataRecord> ExecuteReader();
		IDataParameter CreateParameter(string name, object value);
		IDataParameter CreateParameter(string name, object value, DbType dbType);
		void ExecuteQuery();
		int ExecuteScalar();
	}
}
