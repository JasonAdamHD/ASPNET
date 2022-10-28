using System;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Lab5
{
    [Route("")]
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly IConfiguration _Config;
        public HomeController(IConfiguration configuration)
        {
            _Config = configuration;
        }
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.Title = "Lab 5";
            var conString = _Config["ConnectionStrings:DB_BlogPosts"];

            return View((object)conString);
        }
        
    }
}