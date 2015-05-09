using System.Data.Common;

namespace Dapper.Oracle.Example.Interface
{
    public interface  IDatabase
    {
        DbConnection Connection { get; }
    }
}
