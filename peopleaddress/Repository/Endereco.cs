using Dapper.Contrib.Extensions;
using Dapper;
using peopleaddress.General;
using peopleaddress.GeneralData;
using peopleaddress.Models;
using peopleaddress.QueryStrings;
using peopleaddress.Request;
using System.Net;

namespace peopleaddress.Repository
{
    public class Endereco
    {
        private DbSession _session;

        public Endereco(DbSession dbSession)
        {
            _session = dbSession;
        }

        public GeneralResult Get(int enderecoId)
        {
            var result = new GeneralResult();
            var queryParams = new DynamicParameters();

            try
            {
                queryParams.Add("enderecoId", enderecoId);
                result.data = _session.Connection.Query<EnderecoDM>(EnderecoQuery.Get, queryParams, _session.Transaction)?.SingleOrDefault();
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        public GeneralResult GetAll(int pessoaId)
        {
            var result = new GeneralResult();

            try
            {
                result.data = _session.Connection.GetAll<EnderecoDM>(_session.Transaction)?.Where(x => x.pessoaId == pessoaId);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        public GeneralResult Insert(AddressRequest addressRequest)
        {
            var result = new GeneralResult();

            try
            {
                result.data = _session.Connection.QuerySingle<int>(EnderecoQuery.Insert, addressRequest, _session.Transaction);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        public GeneralResult Put(int enderecoId, AddressRequest addressRequest)
        {
            var result = new GeneralResult();
            var queryParams = new DynamicParameters();

            try
            {
                queryParams.Add("pessoaId", addressRequest.pessoaId);
                queryParams.Add("logradouro", addressRequest.logradouro);
                queryParams.Add("numero", addressRequest.numero);
                queryParams.Add("bairro", addressRequest.bairro);
                queryParams.Add("cidade", addressRequest.cidade);
                queryParams.Add("uf", addressRequest.uf);
                queryParams.Add("enderecoId", enderecoId);

                result.data = _session.Connection.Execute(EnderecoQuery.Update, queryParams, _session.Transaction) >= 1;

                if (!(bool)result.data)
                    result.ChangeStatus(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        public GeneralResult Delete(int enderecoId)
        {
            var result = new GeneralResult();
            var queryParams = new DynamicParameters();

            try
            {
                queryParams.Add("enderecoId", enderecoId);
                result.data = _session.Connection.Execute(EnderecoQuery.Delete, queryParams, _session.Transaction) >= 1;

                if (!(bool)result.data)
                    result.ChangeStatus(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }
    }
}
