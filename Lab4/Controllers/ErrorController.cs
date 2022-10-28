using Microsoft.AspNetCore.Mvc;
using System;

namespace Lab4
{

    [Route("Error")]
    public class ErrorController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            int statusCode = HttpContext.Response.StatusCode;
            ViewBag.statusCode = statusCode;
            return View();
        }
    }
}