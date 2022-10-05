using Dapper;
using Dapper.Contrib.Extensions;
using peopleaddress.General;
using peopleaddress.GeneralData;
using peopleaddress.Models;
using peopleaddress.QueryStrings;
using peopleaddress.Request;

namespace peopleaddress.Repository
{
    public class Pessoas
    {
        private DbSession _session;

        public Pessoas(DbSession dbSession)
        {
            _session = dbSession;
        }

        public GeneralResult Get(int pessoaId)
        {
            var result = new GeneralResult();
            var queryParams = new DynamicParameters();

            try
            {
                queryParams.Add("pessoaId", pessoaId);
                result.data = _session.Connection.Query<PessoasDM>(PessoaQuery.Get, queryParams, _session.Transaction)?.SingleOrDefault();
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        public GeneralResult GetAll()
        {
            var result = new GeneralResult();

            try
            {
                result.data = _session.Connection.GetAll<PessoasDM>(_session.Transaction);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        public GeneralResult Insert(PeopleRequest peopleRequest)
        {
            var result = new GeneralResult();

            try
            {
                result.data = _session.Connection.QuerySingle<int>(PessoaQuery.Insert, peopleRequest, _session.Transaction);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        public GeneralResult Put(int pessoaId, PeopleRequest peopleRequest)
        {
            var result = new GeneralResult();
            var queryParams = new DynamicParameters();

            try
            {
                queryParams.Add("nome", peopleRequest.nome);
                queryParams.Add("idade", peopleRequest.idade.ToString());
                queryParams.Add("dataNascimento", peopleRequest.dataNascimento);
                queryParams.Add("email", peopleRequest.email);
                queryParams.Add("telefone", peopleRequest.telefone);
                queryParams.Add("celular", peopleRequest.celular);
                queryParams.Add("pessoaId", pessoaId.ToString());

                result.data = _session.Connection.Execute(PessoaQuery.Update, queryParams, _session.Transaction) >= 1;
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        public GeneralResult Delete(int pessoaId)
        {
            var result = new GeneralResult();
            var queryParams = new DynamicParameters();

            try
            {
                queryParams.Add("pessoaId", pessoaId);
                result.data = _session.Connection.Execute(PessoaQuery.Delete, queryParams, _session.Transaction) >= 1;
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }
    }
}
