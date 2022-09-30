using Dapper;
using MySqlConnector;
using System.Net;

namespace peopleaddress.General
{
    public class ObjectDAO
    {
        private IConfiguration _configuration;

        public ObjectDAO(IConfiguration config)
        {
            _configuration = config;
        }

        public GeneralResult Get(string query)
        {
            var result = new GeneralResult();

            try
            {

                using (var conexao = new MySqlConnection(
                        _configuration.GetConnectionString("DefaultConnection")))
                {
                    result.data = conexao.QueryFirstOrDefault<object>(query);
                }
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        public GeneralResult GetAll(string query)
        {
            var result = new GeneralResult();

            try
            {
                using (var conexao = new MySqlConnection(
                        _configuration.GetConnectionString("DefaultConnection")))
                {
                    result.data = conexao.Query<object>(query);
                }
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        public GeneralResult Insert(string query)
        {
            var result = new GeneralResult();

            try
            {
                using (var conexao = new MySqlConnection(
                        _configuration.GetConnectionString("DefaultConnection")))
                {
                    result.data = conexao.QueryFirstOrDefault<int>(query);
                }
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }


        public GeneralResult Other(string query)
        {
            var result = new GeneralResult();

            try
            {
                using (var conexao = new MySqlConnection(
                        _configuration.GetConnectionString("DefaultConnection")))
                {
                    result.data = conexao.Execute(query) >= 1;
                }

                if (!(bool)result.data)
                    result.code = ((int)HttpStatusCode.NoContent).ToString();
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }
    }
}
