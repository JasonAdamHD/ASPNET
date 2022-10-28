using Microsoft.AspNetCore.Mvc;
using System;

namespace Lab4
{

    [Route("")]
    [Route("Home")]
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("Index2")]
        public IActionResult Index2()
        {
            throw new Exception("Oh No!  The site is broken!");
        }
    }
}