using Dapper.Oracle.Example.Interface;
using Oracle.ManagedDataAccess.Client;
using System.Data.Common;

namespace Dapper.Oracle.Example.Infrastructure
{
    public class DatabaseManaged : Database, IDatabase
    {
         
        public DbConnection Connection
        {
            get
            {
                if (connection == null)
                    connection = new OracleConnection(connectionString);
                return connection;
            }
        }

      
        public DatabaseManaged(string cnnStr) :base(cnnStr)
        {
            
        }

      
    }
}
