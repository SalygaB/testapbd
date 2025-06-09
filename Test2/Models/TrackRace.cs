namespace Test2.Models;

public class TrackRace
{
    public int Id { get; set; }
    public int RaceId { get; set; }
    public int TrackId { get; set; }
    public double? BestTimeInSeconds { get; set; }
    
    public Race Race { get; set; } = null!;
    public Track Track { get; set; } = null!;
    public ICollection<Participation> Participations { get; set; } = new List<Participation>();
} 