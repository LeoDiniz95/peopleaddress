using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using peopleaddress.General;
using peopleaddress.GeneralData;
using peopleaddress.Repository;
using peopleaddress.Request;

namespace peopleaddress.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {

        [HttpGet("{enderecoId}")]
        [Authorize]
        public GeneralResult Get(int enderecoId, [FromServices] IUnitOfWork unitOfWork, [FromServices] Endereco endereco)
        {
            var result = new GeneralResult();

            try
            {
                unitOfWork.BeginTransaction();
                result = endereco.Get(enderecoId);

                if (result.failure)
                    unitOfWork.Rollback();
                else
                    unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }
            return result;
        }

        [HttpPut("{enderecoId}")]
        [Authorize]
        public GeneralResult Put(int enderecoId, [FromBody] AddressRequest addressRequest, [FromServices] IUnitOfWork unitOfWork, [FromServices] Endereco endereco)
        {
            var result = new GeneralResult();

            try
            {
                unitOfWork.BeginTransaction();
                result = endereco.Put(enderecoId, addressRequest);

                if (result.failure)
                    unitOfWork.Rollback();
                else
                    unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        [HttpDelete("{enderecoId}")]
        [Authorize]
        public GeneralResult Delete(int enderecoId, [FromServices] IUnitOfWork unitOfWork, [FromServices] Endereco endereco)
        {
            var result = new GeneralResult();

            try
            {
                unitOfWork.BeginTransaction();
                result = endereco.Delete(enderecoId);

                if (result.failure)
                    unitOfWork.Rollback();
                else
                    unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        [HttpPost]
        [Authorize]
        public GeneralResult Post([FromBody] AddressRequest addressRequest, [FromServices] IUnitOfWork unitOfWork, [FromServices] Endereco endereco)
        {
            var result = new GeneralResult();

            try
            {
                unitOfWork.BeginTransaction();
                result = endereco.Insert(addressRequest);

                if (result.failure)
                    unitOfWork.Rollback();
                else
                    unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }

        [HttpGet("GetAll/{pessoaId}")]
        [Authorize]
        public GeneralResult GetAll(int pessoaId, [FromServices] IUnitOfWork unitOfWork, [FromServices] Endereco endereco)
        {
            var result = new GeneralResult();

            try
            {
                unitOfWork.BeginTransaction();
                result = endereco.GetAll(pessoaId);

                if (result.failure)
                    unitOfWork.Rollback();
                else
                    unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                result.AddError(ex);
            }

            return result;
        }
    }
}
