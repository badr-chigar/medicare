using MediCare.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// EF Core + SQL Server
builder.Services.AddDbContext<MediCareContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS pour le frontend React
builder.Services.AddCors(o => o.AddPolicy("front", p =>
    p.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

// Création + alimentation de la base au démarrage (démo)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MediCareContext>();
    db.Database.EnsureCreated();
    DbSeeder.Seed(db);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("front");
app.MapControllers();
app.Run();
