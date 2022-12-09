using Lab9.DataObjects;

namespace Lab9.Repositories
{
    public interface ICourseRepository
    {
        public IEnumerable<Course> GetList();
        public Course Get(string term, string crn);
    }
}
