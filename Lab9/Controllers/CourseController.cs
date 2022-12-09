using Lab9.DataObjects;
using Lab9.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepo;

        public CourseController(ICourseRepository courseRepo)
        {
            _courseRepo = courseRepo;
        }
        [HttpGet("{term}")]
        public IEnumerable<Course> GetList(string term)
        {
            List<Course> filteredCourses = new List<Course>();
            IEnumerable<Course> allCourses = _courseRepo.GetList();
            foreach (var course in allCourses)
            {
                if (course.Term == term)
                {
                    filteredCourses.Add(course);
                }
            }
            return filteredCourses;
        }

        [HttpGet("{term}/{crn}")]
        public ActionResult<Course> Get(string term, string crn)
        {
            return _courseRepo.Get(term, crn);
        }
    }
}
