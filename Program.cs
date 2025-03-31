using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;
using DotNetEnv;
using MyMvcApp;
using MyMvcApp.Data;
var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();
string connectionString = Environment.GetEnvironmentVariable("DB_URL") ?? throw new Exception("DB_URL is not set");
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
   {
options.UseNpgsql(connectionString);
   }  );

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
