using frontend_sistema.Data;
using frontend_sistema.Repositories;
using frontend_sistema.Repositories.Implementations;
using frontend_sistema.Services;
using frontend_sistema.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => {
            options.SignIn.RequireConfirmedAccount = false;
            options.User.AllowedUserNameCharacters = string.Empty;
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
        })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddTransient<IPatrocinadorRepository, PatrocinadorRepository>();
builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRolesInitital>();

var app = builder.Build();

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

AplicarMigrationInicial();
CriarPerfisUsuariosInitials(app);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

void AplicarMigrationInicial()
{
    try
    {
        if(app != null)
        {
            using (var serviceScope = app.Services.CreateScope())
            {
                var serviceDb = serviceScope.ServiceProvider
                    .GetService<AppDbContext>();
                if (serviceDb != null)
                    serviceDb.Database.MigrateAsync();
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

void CriarPerfisUsuariosInitials(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    if (scopedFactory != null)
    {
        using (var scope = scopedFactory.CreateScope())
        {
            var service = scope.ServiceProvider.GetService<ISeedUserRoleInitial>();
            if (service != null)
            {
                service.SeedRoles();
                service.SeedUsers();
            }
        }
    }
}