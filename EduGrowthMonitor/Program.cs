using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EduGrowthMonitor.Data;
using EduGrowthMonitor.Models;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EduGrowthMonitorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EduGrowthMonitorContext") ?? throw new InvalidOperationException("Connection string 'EduGrowthMonitorContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>().AddDefaultTokenProviders()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<EduGrowthMonitorContext>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//Seed
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
