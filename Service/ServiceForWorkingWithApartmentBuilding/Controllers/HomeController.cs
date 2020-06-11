using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceForWorkingWithApartmentBuilding.Controllers
{
    public class ValuesController : Controller
    {
        [HttpGet("/GetLogin")]
        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }
    }
}
