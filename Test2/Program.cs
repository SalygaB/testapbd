using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Test2.Data;
using Test2.Repositories;
using Test2.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Grand Prix Racer API",
        Version = "v1"
    });
});

builder.Services.AddDbContext<GrandPrixContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRacerRepository, RacerRepository>();
builder.Services.AddScoped<IRaceRepository, RaceRepository>();
builder.Services.AddScoped<ITrackRepository, TrackRepository>();
builder.Services.AddScoped<ITrackRaceRepository, TrackRaceRepository>();
builder.Services.AddScoped<IParticipationRepository, ParticipationRepository>();

builder.Services.AddScoped<IRacerService, RacerService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run("http://localhost:5300");