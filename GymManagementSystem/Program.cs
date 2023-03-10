using Microsoft.EntityFrameworkCore;
using GymManagementSystem.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using GymManagementSystem.Controllers;
using Newtonsoft.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddMvcCore().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

builder.Services.AddDbContext<GymDatabaseContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Server=PSL-6957XM3;Database=GymDatabase;Trusted_Connection=True;Encrypt=false;"))

);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseSession();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
