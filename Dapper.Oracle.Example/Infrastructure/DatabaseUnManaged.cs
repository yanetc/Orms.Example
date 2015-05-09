using Dapper.Oracle.Example.Interface;
using Oracle.DataAccess.Client;
using System.Data.Common;

namespace Dapper.Oracle.Example.Infrastructure
{
    public class DatabaseUnManaged : Database, IDatabase 
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
 
        public DatabaseUnManaged(string cnnStr) : base(cnnStr)
        {
             
        }

        
    }
}
