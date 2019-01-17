using DAL.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helpers.Concrete
{
	public class ConnectionHelper : IConnectionHelper
	{
		private IDbCommand _sqlCommand;
		private IDbConnection _sqlConnection;

		public IConnectionHelper CreateConnection()
		{
			string cs = DbConstants.ConnectionString;
			_sqlConnection = new SqlConnection(cs);

			return this;
		}

		public IConnectionHelper CreateCommand(string name)
		{
			_sqlCommand = new SqlCommand(name, _sqlConnection as SqlConnection)
			{
				CommandType = CommandType.StoredProcedure
			};

			return this;
		}

		public IConnectionHelper AddParameter(params IDataParameter[] parameters)
		{
			foreach (var item in parameters)
			{
				_sqlCommand.Parameters.Add(item);
			}

			return this;
		}

		public void ExecuteQuery()
		{
			using (_sqlConnection)
			{
				_sqlConnection.Open();

				_sqlCommand.ExecuteNonQuery();
			}
		}

		public IEnumerable<IDataRecord> ExecuteReader()
		{
			using (_sqlConnection)
			{
				_sqlConnection.Open();

				using (var read = _sqlCommand.ExecuteReader())
				{
					while (read.Read())
					{
						yield return read;
					}
				}
				_sqlConnection.Close();
			}
		}

		public int ExecuteScalar()
		{
			int id = default(int);

			using (_sqlConnection)
			{
				_sqlConnection.Open();

				id = (int)_sqlCommand.ExecuteScalar();
			}

			return id;
		}

		public IDataParameter CreateParameter(string name, object value)
		{
			name = name.StartsWith("@") ? name : "@" + name;

			var parameter = new SqlParameter(name, value);

			return parameter;
		}
		public IDataParameter CreateParameter(string name, object value, DbType dbType)
		{
			name = name.StartsWith("@") ? name : "@" + name;

			var parameter = new SqlParameter()
			{
				ParameterName = name,
				Value = value,
				DbType = dbType
			};

			return parameter;
		}
	}
}
