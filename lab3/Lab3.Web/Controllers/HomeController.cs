using Microsoft.AspNetCore.Mvc;
using Lab3.Objects;
using Lab3.Web.Extensions;
public class HomeController : Controller
{
    public ActionResult Index()
    {
        return View();
    }

    public ActionResult Laborers()
    {
        ChoreWorkforce myWorkforce = new ChoreWorkforce();
        myWorkforce.Laborers.Add(new ChoreLaborer(){   Name = "Bob", Age = 7, Difficulty = 1 });
        myWorkforce.Laborers.Add(new ChoreLaborer(){   Name = "Tim", Age = 11, Difficulty = 2 });
        myWorkforce.Laborers.Add(new ChoreLaborer(){   Name = "Alex", Age = 13, Difficulty = 3 });
        myWorkforce.Laborers.Add(new ChoreLaborer(){   Name = "John", Age = 17, Difficulty = 4 });
        for (int i = 0; i < 30; i++)
        {
            ChoreWorkforceExtension.AddRandomLaborer(myWorkforce);
        }

        ChoreWorkforce youngWorkforce = new ChoreWorkforce();
        foreach (var laborer in myWorkforce.Laborers.Where(l => ((l?.Age?? -1) > 3 && l?.Age < 10)).OrderBy(l => l.Name))
        {
            youngWorkforce.AddLaborer(laborer.Name, laborer.Age, laborer.Difficulty);
        }
        return View(youngWorkforce);
        /*
        ChoreWorkforce sortedWorkforce = new ChoreWorkforce();
        foreach (var laborer in youngWorkforce.Laborers.OrderBy(l => l.Name))
        {
            sortedWorkforce.AddLaborer(laborer.Name, laborer.Age, laborer.Difficulty);
        }
        return View(sortedWorkforce);
        */
    }
}