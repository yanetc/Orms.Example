using Dapper.Oracle.Example.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Oracle.Example.Infrastructure
{
    public class DbRepository
    {
        private readonly IDatabase _database;

        protected DbConnection connection
        {
            get
            {
                if (_database.Connection.State == ConnectionState.Closed)
                    _database.Connection.Open();
                return _database.Connection;
            }
        }

        public virtual IEnumerable<TDataModel> Execute<TDataModel>(string sqlCommand, object parameters = null)
        {
            return Execute(connection => connection.Query<TDataModel>(sqlCommand, parameters));
        }

        protected virtual void Execute(string sqlCommand, object parameters = null)
        {
            Execute(connection => connection.Query(sqlCommand, parameters));
        }
        protected DbRepository(IDatabase database)
        {
            _database = database;
        }


        protected virtual T Execute<T>(Func<DbConnection, T> executeCommand)
        {
            return executeCommand(connection);
        }

        protected virtual void Execute(Action<DbConnection> executeCommand)
        {
            executeCommand(connection);
        }

        protected virtual TResult ExecuteTransaction<TResult>(Func<DbConnection, DbTransaction, TResult> executeCommand)
        {
            using (var transaction = connection.BeginTransaction())
            {
                TResult result = executeCommand(connection, transaction);

                transaction.Commit();

                return result;
            }
        }

        protected virtual void ExecuteTransaction(Action<DbConnection, DbTransaction> executeCommand)
        {
            using (var transaction = connection.BeginTransaction())
            {
                executeCommand(connection, transaction);

                transaction.Commit();
            }
        }
    }
}
