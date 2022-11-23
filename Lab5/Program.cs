using Lab5;
using System.Data.Common;
using Lab5.Code.DataModels;
using Lab5.Code.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IDataEntityRepository<BlogPost>, BlogDBRepository>();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();

app.Run();