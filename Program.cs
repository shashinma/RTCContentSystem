using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using POSTerminalWebApp.Services;
using POSTerminalWebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var identityConnectionString = builder.Configuration.GetConnectionString("IdentityConnection") ?? 
    throw new InvalidOperationException("Connection string 'IdentityConnection' not found.");

var applicationDbConnectionString = 
    builder.Configuration.GetConnectionString("ApplicationDbConnection") ?? 
    throw new InvalidOperationException("Connection string 'ApplicationDbConnection' not found.");

builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlite(identityConnectionString));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(applicationDbConnectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<IdentityContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<INewsService, NewsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=News}/{action=News}/{id?}");
app.MapRazorPages();

app.Run();