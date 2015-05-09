using Dapper.Oracle.Example.Infrastructure;
using Dapper.Oracle.Example.Interface;
using System.Linq;

namespace Dapper.Oracle.Example.Repositories
{
    public  class DatabaseInfoRepository : DbRepository
    {
        public DatabaseInfoRepository(IDatabase database) : base(database)
        { }

        public string GetDBStatus()
        {
            return Execute<string>("Select status from v$instance").FirstOrDefault();
        }
    }
}
