using Microsoft.AspNetCore.Mvc;
using peopleaddress.General;
using peopleaddress.QueryStrings;
using peopleaddress.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace peopleaddress.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        [HttpGet("{pessoaId}")]
        public GeneralResult Get(int pessoaId, [FromServices] ObjectDAO pObject)
        {
            return pObject.Get(string.Format(PessoaQuery.Get, pessoaId));
        }

        [HttpPut("{pessoaId}")]
        public GeneralResult Put(int pessoaId, [FromBody] PeopleRequest peopleRequest, [FromServices] ObjectDAO pObject)
        {
            var result = new GeneralResult();

            try
            {
                var queryParams = PessoaQuery.Update.Replace("{nome}", peopleRequest.nome)
                                                .Replace("{idade}", peopleRequest.idade.ToString())
                                                .Replace("{email}", peopleRequest.email)
                                                .Replace("{telefone}", peopleRequest.telefone)
                                                .Replace("{celular}", peopleRequest.celular)
                                                .Replace("{pessoaId}", pessoaId.ToString());

                result = pObject.Other(queryParams);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        [HttpDelete("{pessoaId}")]
        public GeneralResult Delete(int pessoaId, [FromServices] ObjectDAO pObject)
        {
            return pObject.Other(string.Format(PessoaQuery.Delete, pessoaId));
        }

        [HttpPost]
        public GeneralResult Post([FromBody] PeopleRequest peopleRequest, [FromServices] ObjectDAO pObject)
        {
            var result = new GeneralResult();

            try
            {
                var queryParams = PessoaQuery.Insert.Replace("{nome}", peopleRequest.nome)
                                                .Replace("{idade}", peopleRequest.idade.ToString())
                                                .Replace("{email}", peopleRequest.email)
                                                .Replace("{telefone}", peopleRequest.telefone)
                                                .Replace("{celular}", peopleRequest.celular);

                result = pObject.Insert(queryParams);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        [HttpGet("GetAll")]
        public GeneralResult GetAll([FromServices] ObjectDAO pObject)
        {
            return pObject.GetAll(PessoaQuery.GetAll);
        }
    }
}
