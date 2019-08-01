using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace oracle.api.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class BaseController : Controller
    {

        [NonAction]
        protected string CurrentUserId()
        {
            return HttpContext.User.FindFirstValue("Id");
        }
    }
}