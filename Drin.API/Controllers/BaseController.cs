using Drin.Core.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Drin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]//Swaggerda gözüküyor bunu yazmazsak. Kendi içimizde kullanıyoruz. bir endpoint değil
        public IActionResult CreateActionResult(ServiceResponse response)
        {
            if (response.StatusCode == 2004)
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };

            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
