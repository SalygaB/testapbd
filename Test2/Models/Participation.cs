namespace Test2.Models;

public class Participation
{
    public int Id { get; set; }
    public int RacerId { get; set; }
    public int TrackRaceId { get; set; }
    public int Position { get; set; }
    public double FinishTimeInSeconds { get; set; }
    
    public Racer Racer { get; set; } = null!;
    public TrackRace TrackRace { get; set; } = null!;
} 