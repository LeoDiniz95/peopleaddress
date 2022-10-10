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
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [Route("Auth")]
        [AllowAnonymous]
        public GeneralResult Auth(UserRequest user, [FromServices] IUnitOfWork unitOfWork, [FromServices] User userrepo)
        {
            var result = new GeneralResult();

            try
            {
                unitOfWork.BeginTransaction();
                result = userrepo.Get(user);

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
        [Route("Insert")]
        [AllowAnonymous]
        public GeneralResult Insert(UserRequest user, [FromServices] IUnitOfWork unitOfWork, [FromServices] User userrepo)
        {
            var result = new GeneralResult();

            try
            {
                unitOfWork.BeginTransaction();
                result = userrepo.Insert(user);

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
