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
    public class PessoasController : ControllerBase
    {
        [HttpGet("{pessoaId}")]
        [Authorize]
        public GeneralResult Get(int pessoaId, [FromServices] IUnitOfWork unitOfWork, [FromServices] Pessoas pessoas)
        {
            var result = new GeneralResult();

            try
            {
                unitOfWork.BeginTransaction();
                result = pessoas.Get(pessoaId);

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

        [HttpPut("{pessoaId}")]
        [Authorize]
        public GeneralResult Put(int pessoaId, [FromBody] PeopleRequest peopleRequest, [FromServices] IUnitOfWork unitOfWork, [FromServices] Pessoas pessoas)
        {
            var result = new GeneralResult();

            try
            {
                unitOfWork.BeginTransaction();
                result = pessoas.Put(pessoaId, peopleRequest);

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

        [HttpDelete("{pessoaId}")]
        [Authorize]
        public GeneralResult Delete(int pessoaId, [FromServices] IUnitOfWork unitOfWork, [FromServices] Pessoas pessoas)
        {
            var result = new GeneralResult();

            try
            {
                unitOfWork.BeginTransaction();
                result = pessoas.Delete(pessoaId);

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
        public GeneralResult Post([FromBody] PeopleRequest peopleRequest, [FromServices] IUnitOfWork unitOfWork, [FromServices] Pessoas pessoas)
        {
            var result = new GeneralResult();

            try
            {
                result = pessoas.Insert(peopleRequest);

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

        [HttpGet("GetAll")]
        [Authorize]
        public GeneralResult GetAll([FromServices] IUnitOfWork unitOfWork, [FromServices] Pessoas pessoas)
        {
            var result = new GeneralResult();

            try
            {
                unitOfWork.BeginTransaction();
                result = pessoas.GetAll();

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
