using Lab9.DataObjects;
using Lab9.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class USStateController : ControllerBase
    {
        private readonly IUSStateRepository _USStateRepo;

        public USStateController(IUSStateRepository usStateRepo)
        {
            _USStateRepo = usStateRepo;
        }

        [HttpGet("")]
        public IEnumerable<USState> GetList()
        {
            return _USStateRepo.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<USState> Get(int id)
        {
            if(id <= 0 || id >= 52)
            {
                return NotFound();
            }
            IEnumerable<USState> allStates = _USStateRepo.GetAll();
            return allStates.ElementAt(id-1);
        }
    }
}
