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
        public GeneralResult Put(int enderecoId, [FromBody] AddressRequest pAddressRequest, [FromServices] ObjectDAO pObject)
        {
            var result = new GeneralResult();

            try
            {
                var queryParams = EnderecoQuery.Update.Replace("{pessoaId}", pAddressRequest.pessoaId.ToString())
                                                      .Replace("{logradouro}", pAddressRequest.logradouro)
                                                      .Replace("{numero}", pAddressRequest.numero.ToString())
                                                      .Replace("{bairro}", pAddressRequest.bairro)
                                                      .Replace("{cidade}", pAddressRequest.cidade)
                                                      .Replace("{uf}", pAddressRequest.uf)
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
        public GeneralResult Post([FromBody] AddressRequest pAddressRequest, [FromServices] ObjectDAO pObject)
        {
            var result = new GeneralResult();

            try
            {
                var queryParams = EnderecoQuery.Insert.Replace("{pessoaId}", pAddressRequest.pessoaId.ToString())
                                                      .Replace("{logradouro}", pAddressRequest.logradouro)
                                                      .Replace("{numero}", pAddressRequest.numero.ToString())
                                                      .Replace("{bairro}", pAddressRequest.bairro)
                                                      .Replace("{cidade}", pAddressRequest.cidade)
                                                      .Replace("{uf}", pAddressRequest.uf);

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
