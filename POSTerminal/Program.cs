using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PhoneEdit.Data;
using POSTerminal.Data;
using POSTerminal.Services;
using Westwind.AspNetCore.Markdown;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseStaticWebAssets();

// Add services to the container.
var identityConnectionString = builder.Configuration.GetConnectionString("IdentityConnection") ??
                               throw new InvalidOperationException("Connection string 'IdentityConnection' not found.");

var applicationDbConnectionString = builder.Configuration.GetConnectionString("ApplicationDbConnection") ??
                                    throw new InvalidOperationException("Connection string 'ApplicationDbConnection' not found.");

builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlite(identityConnectionString));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("ApplicationDbConnection"),
        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseSqlite(applicationDbConnectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<IdentityContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IJobsService, JobsService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IShortcutService, ShortcutService>();
builder.Services.AddScoped<IInstructionsService, InstructionsService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<IMuseumService, MuseumService>();
builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "sidebarState";
    options.IdleTimeout = TimeSpan.FromSeconds(3600);
    options.Cookie.IsEssential = true;
});

builder.Services.Configure<DefaultUserOptions>(builder.Configuration);

builder.Services.AddMarkdown();

builder.Services.AddRazorPages();

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

app.UseMarkdown();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    "Viewer",
    "/Viewer/{searchString}",
    new { controller = "Viewer", action = "Index" }
);

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}"
);

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var identityContext = scope.ServiceProvider.GetRequiredService<IdentityContext>();
    var pendingIdentityContextMigrations = identityContext.Database.GetPendingMigrations().ToList();

    var appDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var pendingAppDbContextMigrations = appDbContext.Database.GetPendingMigrations().ToList();

    if (pendingIdentityContextMigrations.Count > 0)
    {
        identityContext.Database.Migrate();
    }
    
    if (pendingAppDbContextMigrations.Count > 0)
    {
        appDbContext.Database.Migrate();
    }
    
    await SampleData.CreateDefaultUser(scope.ServiceProvider);
}

app.UseSession();
app.Run();