using Dapper.Oracle.Example.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace Dapper.Oracle.Example.Infrastructure
{
    public class Database :   IDisposable
    {
        protected DbConnection connection;

        protected string connectionString { get; private set; }
        public Database(string cnnStr)
        {
            connectionString = cnnStr;
        }

        public void Dispose()
        {
            if (connection != null)
                connection.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
