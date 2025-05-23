
using System.Data;

namespace projekt_blogic.Data
{
    internal class SqlConnection : IDisposable
    {
        private string connectionString;

        public SqlConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        internal object Query<T>(string v, CommandType commandType)
        {
            throw new NotImplementedException();
        }

        internal T QueryFirstOrDefault<T>(string v, object value, CommandType commandType)
        {
            throw new NotImplementedException();
        }

        internal T QueryFirstOrDefault<T>(string v, object value)
        {
            throw new NotImplementedException();
        }

        internal T QuerySingle<T>(string v, DynamicParameters parameters, CommandType commandType)
        {
            throw new NotImplementedException();
        }
    }
}