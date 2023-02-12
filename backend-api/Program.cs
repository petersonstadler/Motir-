using backend_api.Data;
using backend_api.Repositories.Implementations;
using backend_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppPrincipalContext>(
    context => context.UseSqlite(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddTransient<IPatrocinadorRepository, PatrocinadorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

AplicarMigrationInicial();

app.UseAuthorization();

app.MapControllers();

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
                    .GetService<AppPrincipalContext>();
                if(serviceDb != null)
                    serviceDb.Database.Migrate();
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}