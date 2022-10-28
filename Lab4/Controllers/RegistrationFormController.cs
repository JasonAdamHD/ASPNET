using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Validation
{
    [Route("Registration")]
    public class RegistrationFormController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            RegistrationFormModel model = new RegistrationFormModel();
            model.StateList = GetStates();
            return View(model);
        }
        [HttpPost]
        [Route("")]
        public IActionResult Index(RegistrationFormModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            return View("Success");
        }
        private List<USState> GetStates()
        {
            return new List<USState>(){
                new USState(){Abbreviation = "OR", Name = "Oregon"},
                new USState(){Abbreviation = "CA", Name = "California"},
                new USState(){Abbreviation = "WA", Name = "Washington"},
                new USState(){Abbreviation = "TX", Name = "Texas"},
                new USState(){Abbreviation = "TN", Name = "Tennessee"}
            };
        }
    }
}