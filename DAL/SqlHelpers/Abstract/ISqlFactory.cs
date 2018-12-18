using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SqlHelpers.Abstract
{
	public interface ISqlFactory
	{
		ISqlFactory CreateConnection();
		ISqlFactory CreateCommand(string name);
		ISqlFactory AddParameter(params IDataParameter[] parameters);
		IEnumerable<IDataRecord> ExecuteReader();
		IDataParameter CreateParameter(string name, object value, DbType type);
		void ExecuteQuery();
		int ExecuteScalar();
	}
}
