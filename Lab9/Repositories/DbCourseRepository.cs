using Lab9.DataObjects;
using System.Data.SqlClient;

namespace Lab9.Repositories
{
    public class DbCourseRepository : ICourseRepository
    {
        private readonly IConfiguration _Config;
        public DbCourseRepository(IConfiguration config)
        {
            _Config = config;
        }

        public Course Get(string term, string crn)
        {
            Course course = new Course();
            string selectCommand = @"SELECT * FROM Course WHERE TERM=@TERM AND CRN=@CRN";
            using SqlConnection connection = new SqlConnection(_Config.GetConnectionString("DB_CourseSchedule"));
            using SqlCommand command = new SqlCommand(selectCommand, connection);
            command.Parameters.AddWithValue("TERM", term);
            command.Parameters.AddWithValue("CRN", crn);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            course.CRN = reader["CRN"].ToString();
            course.Term = reader["TERM"].ToString();
            course.Subject = reader["SUBJCODE"].ToString();
            course.CourseNumber = reader["CRSENUMB"].ToString();
            course.CourseTitle = reader["CRSETITLE"].ToString();
            course.CourseDescription = reader["CRSDESCRIPTION"].ToString();
            course.Instructor = reader["INSTFIRSTNAME"].ToString() + " " + reader["INSTLASTNAME"].ToString();
            return course;
        }

        public IEnumerable<Course> GetList()
        {
            List<Course> courses = new List<Course>();
            string selectCommand = "SELECT * FROM Course";
            using SqlConnection connection = new SqlConnection(_Config.GetConnectionString("DB_CourseSchedule"));
            using SqlCommand command = new SqlCommand(selectCommand, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Course course = new Course();
                course.CRN = reader["CRN"].ToString();
                course.Term = reader["TERM"].ToString();
                course.Subject = reader["SUBJCODE"].ToString();
                course.CourseNumber = reader["CRSENUMB"].ToString();
                course.CourseTitle = reader["CRSETITLE"].ToString();
                course.CourseDescription = reader["CRSDESCRIPTION"].ToString();
                course.Instructor = reader["INSTFIRSTNAME"].ToString() + " " + reader["INSTLASTNAME"].ToString();
                courses.Add(course);
            }
            return courses;
        }
    }
}
