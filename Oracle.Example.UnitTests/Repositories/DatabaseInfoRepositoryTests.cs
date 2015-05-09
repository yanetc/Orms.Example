using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Configuration;
using Dapper.Oracle.Example.Infrastructure;

namespace Dapper.Oracle.Example.Repositories.Tests
{
    [TestClass()]
    public class DatabaseInfoRepositoryTests
    {
        protected string connectionString = ConfigurationManager.ConnectionStrings["Oracle11g"].ConnectionString;



        [TestMethod()]
        public void GetDBStatusWithManagedClientTest()
        {
            using (var database = new DatabaseManaged(connectionString))
            {
                var dbInfoRepository = new DatabaseInfoRepository(database);
                var dbStatus = dbInfoRepository.GetDBStatus();
                Assert.IsNotNull(dbStatus);
            }
        }

        [TestMethod()]
        public void GetDBStatusWithUnManagedClientTest()
        {
            using (var database = new DatabaseUnManaged(connectionString))
            {
                var dbInfoRepository = new DatabaseInfoRepository(database);
                var dbStatus = dbInfoRepository.GetDBStatus();
                Assert.IsNotNull(dbStatus);
            }
        }


    }
}