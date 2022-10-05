using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Data;

namespace peopleaddress.GeneralData
{
    public sealed class DbSession : IDisposable
    {
        private Guid _id;
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }
        private IConfiguration _configuration;

        public DbSession(IConfiguration pConfig)
        {
            _configuration = pConfig;
            _id = Guid.NewGuid();
            Connection = new MySqlConnection(_configuration?.GetConnectionString("DefaultConnection"));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
