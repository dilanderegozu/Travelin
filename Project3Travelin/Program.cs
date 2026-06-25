using AspNetCore.Identity.MongoDbCore.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Project3Travelin.Entities;  // AppUser, AppRole buradan gelecek
using Project3Travelin.Services.CategoryServices;
using Project3Travelin.Services.CommentServices;
using Project3Travelin.Services.ReservationServices;
using Project3Travelin.Services.TourServices;
using Project3Travelin.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { "tr", "en" };
    options.SetDefaultCulture("tr")
           .AddSupportedCultures(supportedCultures)
           .AddSupportedUICultures(supportedCultures);
});
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITourService, TourService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddMongoDbStores<AppUser, AppRole, Guid>(
        builder.Configuration["DatabaseSettings:ConnectionString"],
        builder.Configuration["DatabaseSettings:DatabaseName"]
    )
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromDays(7);
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

    // Rolleri oluştur
    if (!await roleManager.RoleExistsAsync("Admin"))
        await roleManager.CreateAsync(new AppRole { Name = "Admin" });

    if (!await roleManager.RoleExistsAsync("User"))
        await roleManager.CreateAsync(new AppRole { Name = "User" });

    // Admin kullanıcı yoksa oluştur
    if (await userManager.FindByNameAsync("admin") == null)
    {
        var admin = new AppUser
        {
            UserName = "admin",
            Email = "admin@travelin.com",
            FirstName = "Admin",
            LastName = "Travelin"
        };

        var result = await userManager.CreateAsync(admin, "Admin123!");
        if (result.Succeeded)
            await userManager.AddToRoleAsync(admin, "Admin");
    }
}
app.UseRequestLocalization();
app.Run();