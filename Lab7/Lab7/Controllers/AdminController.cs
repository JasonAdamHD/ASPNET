using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab7.Controllers
{
    
    [Route("Admin")]
    [Authorize]
    public class AdminController : Controller
    {
        [Route("")]
        [Route("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
