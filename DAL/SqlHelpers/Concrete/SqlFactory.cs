using DAL.SqlHelpers.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SqlHelpers.Concrete
{
	public class SqlFactory : ISqlFactory
	{
		private IDbCommand _sqlCommand;
		private IDbConnection _sqlConnection;

		public ISqlFactory CreateConnection()
		{
			string cs = DbConstants.ConnectionString;
			_sqlConnection = new SqlConnection(cs);

			return this;
		}

		public ISqlFactory CreateCommand(string name)
		{
			_sqlCommand = new SqlCommand(name, _sqlConnection as SqlConnection)
			{
				CommandType = CommandType.StoredProcedure
			};

			return this;
		}

		public ISqlFactory AddParameter(params IDataParameter[] parameters)
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

		public IDataParameter CreateParameter(string name, object value, DbType type)
		{
			name = name.StartsWith("@") ? name : "@" + name;

			var parameter = new SqlParameter
			{
				ParameterName = name,
				Value = value,
				DbType = type
			};

			return parameter;
		}
	}
}
