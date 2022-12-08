using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Lab7.Data;
using Lab7.Areas.Identity.Data;
using Lab7.Services;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Lab7ContextConnection") ?? throw new InvalidOperationException("Connection string 'Lab7ContextConnection' not found.");

builder.Services.AddAuthorization();

builder.Services.AddDbContext<Lab7Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Lab7User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Lab7Context>();

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.Configure<SendGridMessageSenderOptions>(builder.Configuration);


var app = builder.Build();


app.UseStaticFiles();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
