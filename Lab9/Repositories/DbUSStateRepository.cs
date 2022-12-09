using Lab9.DataObjects;
using Lab9.Repositories;
using System.Data.SqlClient;

public class DbUSStateRepository : IUSStateRepository
{
    private readonly IConfiguration _Config;
    public DbUSStateRepository(IConfiguration config)
    {
        _Config = config;
    }
    public IEnumerable<USState> GetAll()
    {
        List<USState> states = new List<USState>();
        string selectCommand = "SELECT * FROM USStates";
        using SqlConnection connection = new SqlConnection(_Config.GetConnectionString("DB_CourseSchedule"));
        using SqlCommand command = new SqlCommand(selectCommand, connection);
        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            USState state = new USState();
            state.ID = (int)reader["ID"];
            state.Abbreviation = reader["Abbreviation"].ToString();
            state.Name = reader["Name"].ToString();
            states.Add(state);
        }
        return states;
    }
}