using Microsoft.EntityFrameworkCore;
using Test2.Models;

namespace Test2.Data;

public class GrandPrixContext : DbContext
{
    public GrandPrixContext(DbContextOptions<GrandPrixContext> options) : base(options)
    {
    }
    
    public DbSet<Racer> Racers { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<TrackRace> TrackRaces { get; set; }
    public DbSet<Participation> Participations { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<TrackRace>()
            .HasKey(tr => tr.Id);
            
        modelBuilder.Entity<Participation>()
            .HasKey(p => p.Id);
            
        modelBuilder.Entity<Participation>()
            .HasOne(p => p.TrackRace)
            .WithMany(tr => tr.Participations)
            .HasForeignKey(p => p.TrackRaceId);
            
        SeedData(modelBuilder);
    }
    
    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Racer>().HasData(
            new Racer { Id = 1, Name = "Lewis Hamilton" },
            new Racer { Id = 2, Name = "Max Verstappen" }
        );
        
        modelBuilder.Entity<Race>().HasData(
            new Race { Id = 1, Name = "Monaco Grand Prix", Location = "Monte Carlo", Date = new DateTime(2025, 5, 26) },
            new Race { Id = 2, Name = "British Grand Prix", Location = "Silverstone", Date = new DateTime(2025, 7, 7) }
        );
        
        modelBuilder.Entity<Track>().HasData(
            new Track { Id = 1, Name = "Monaco Circuit", LengthInKm = 3.337 },
            new Track { Id = 2, Name = "Silverstone Circuit", LengthInKm = 5.891 }
        );
        
        modelBuilder.Entity<TrackRace>().HasData(
            new TrackRace { Id = 1, RaceId = 1, TrackId = 1, BestTimeInSeconds = 5460 },
            new TrackRace { Id = 2, RaceId = 2, TrackId = 2, BestTimeInSeconds = 5550 }
        );
        
        modelBuilder.Entity<Participation>().HasData(
            new Participation 
            { 
                Id = 1,
                RacerId = 1, 
                TrackRaceId = 1,
                Position = 1, 
                FinishTimeInSeconds = 5460 
            },
            new Participation 
            { 
                Id = 2,
                RacerId = 2, 
                TrackRaceId = 1,
                Position = 2, 
                FinishTimeInSeconds = 5550 
            }
        );
    }
} 