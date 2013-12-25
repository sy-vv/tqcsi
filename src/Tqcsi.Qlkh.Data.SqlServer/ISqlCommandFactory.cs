using System.Data.SqlClient;

namespace Tqcsi.Qlkh.Data.SqlServer
{
    public interface ISqlCommandFactory
    {
        SqlCommand GetCommand();
    }
}