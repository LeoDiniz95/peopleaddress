using Dapper;
using Dapper.Contrib.Extensions;
using peopleaddress.General;
using peopleaddress.GeneralData;
using peopleaddress.Models;
using peopleaddress.QueryStrings;
using peopleaddress.Request;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace peopleaddress.Repository
{
    public class User
    {
        private DbSession _session;

        public User(DbSession dbSession)
        {
            _session = dbSession;
        }

        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            var sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        public GeneralResult Get(UserRequest userrequest)
        {
            var result = new GeneralResult();

            try
            {
                userrequest.password = GetHashString(userrequest.password);
                var user = _session.Connection.GetAll<UsersDM>(_session.Transaction)?
                                                 .FirstOrDefault(x => x.username == userrequest.username
                                                    && x.password == userrequest.password
                                                    && x.status == Constantes.Status.Ativo);

                if (user == null)
                {
                    result.AddMessage("Usuário não encontrado");
                    result.ChangeStatus(HttpStatusCode.NoContent);
                    result.failure = true;
                }

                if (!result.failure)
                {
                    var token = TokenService.GenerateToken(user, _session.GetToken());

                    user.password = String.Empty;

                    result.data = new
                    {
                        user = user,
                        token = token
                    };
                }
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        public GeneralResult Insert(UserRequest userrequest)
        {
            var result = new GeneralResult();

            try
            {
                userrequest.password = GetHashString(userrequest.password);
                userrequest.status = Constantes.Status.Ativo;
                result.data = _session.Connection.QuerySingle<int>(UserQuery.Insert, userrequest, _session.Transaction);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }
    }
}
