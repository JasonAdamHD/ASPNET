using Lab3.Objects;

namespace Lab3.Web.Extensions
{
    public static class ChoreWorkforceExtension
    {
        public static void AddLaborer(this ChoreWorkforce choreWorkforce, string Name, int Age, int Difficulty)
        {

            choreWorkforce.Laborers.Add(new ChoreLaborer(){Name=Name, Age=Age, Difficulty=Difficulty});
        }

        public static void AddRandomLaborer(this ChoreWorkforce choreWorkforce)
        {
            string[] names = { "Aaron", "Beth", "Charlie", "Dante", "Eric", "Frank", "Graham", "Harold", "Isaac", "Jacob", "Kyle" };
            Random rnd = new Random();
            int index = rnd.Next(names.Length);
            int difficulty = rnd.Next(1,11);
            if (difficulty == 10)
            {
                choreWorkforce.Laborers.Add(null);
            }
            else
            {
                AddLaborer(choreWorkforce, names[index], rnd.Next(0,19), difficulty);
            }
        }
    }
}