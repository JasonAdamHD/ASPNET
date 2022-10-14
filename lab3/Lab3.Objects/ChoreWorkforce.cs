using System.Collections.Generic;
namespace Lab3.Objects
{
    public class ChoreWorkforce
    {
        public List<ChoreLaborer> Laborers{get;} = new List<ChoreLaborer>();
        public void AddLaborer(string Name, int Age, int Difficulty)
        {
            Laborers.Add(new ChoreLaborer(){Name=Name, Age=Age, Difficulty=Difficulty});
        }
    }
}