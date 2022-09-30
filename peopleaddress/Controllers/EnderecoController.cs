using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using peopleaddress.General;
using peopleaddress.QueryStrings;
using peopleaddress.Request;

namespace peopleaddress.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {

        [HttpGet("{enderecoId}")]
        public GeneralResult Get(int enderecoId, [FromServices] ObjectDAO pObject)
        {
            return pObject.Get(string.Format(EnderecoQuery.Get, enderecoId));
        }

        [HttpPut("{enderecoId}")]
        public GeneralResult Put(int enderecoId, [FromBody] AddressRequest addressRequest, [FromServices] ObjectDAO pObject)
        {
            var result = new GeneralResult();

            try
            {
                var queryParams = EnderecoQuery.Update.Replace("{pessoaId}", addressRequest.pessoaId.ToString())
                                                      .Replace("{logradouro}", addressRequest.logradouro)
                                                      .Replace("{numero}", addressRequest.numero?.ToString() ?? "NULL")
                                                      .Replace("{bairro}", addressRequest.bairro)
                                                      .Replace("{cidade}", addressRequest.cidade)
                                                      .Replace("{uf}", addressRequest.uf)
                                                      .Replace("{enderecoId}", enderecoId.ToString());

                result = pObject.Other(queryParams);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        [HttpDelete("{enderecoId}")]
        public GeneralResult Delete(int enderecoId, [FromServices] ObjectDAO pObject)
        {
            return pObject.Other(string.Format(EnderecoQuery.Delete, enderecoId));
        }

        [HttpPost]
        public GeneralResult Post([FromBody] AddressRequest addressRequest, [FromServices] ObjectDAO pObject)
        {
            var result = new GeneralResult();

            try
            {
                var queryParams = EnderecoQuery.Insert.Replace("{pessoaId}", addressRequest.pessoaId.ToString())
                                                      .Replace("{logradouro}", addressRequest.logradouro)
                                                      .Replace("{numero}", addressRequest.numero?.ToString() ?? "NULL")
                                                      .Replace("{bairro}", addressRequest.bairro)
                                                      .Replace("{cidade}", addressRequest.cidade)
                                                      .Replace("{uf}", addressRequest.uf);

                result = pObject.Insert(queryParams);
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        [HttpGet("GetAll/{pessoaId}")]
        public GeneralResult GetAll(int pessoaId, [FromServices] ObjectDAO pObject)
        {
            return pObject.GetAll(string.Format(EnderecoQuery.GetAll, pessoaId));
        }
    }
}
