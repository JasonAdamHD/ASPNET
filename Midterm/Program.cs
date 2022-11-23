using Midterm;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//TODO: Add loading of JSON/Sample.json configuration file here (will change to actual Midterm.json file later)


//TODO: Register configuration mapping of "MidtermExam" section in configuration to a MidtermExam object
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile(@"JSON\Midterm.json", false, reloadOnChange: true);
});

builder.Services.Configure<MidtermExam>(builder.Configuration.GetSection("MidTermExam"));

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();

app.Run();
