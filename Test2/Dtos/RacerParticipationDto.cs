namespace Test2.Dtos;

public class RacerParticipationDto
{
    public int RacerId { get; set; }
    public string RacerName { get; set; } = null!;
    public List<ParticipationDto> Participations { get; set; } = new();
}

public class ParticipationDto
{
    public string RaceName { get; set; } = null!;
    public string TrackName { get; set; } = null!;
    public int Position { get; set; }
    public double FinishTimeInSeconds { get; set; }
}

public class ParticipationDetailDto
{
    public RaceDto Race { get; set; } = null!;
    public TrackDto Track { get; set; } = null!;
    public int Laps { get; set; }
    public int FinishTimeInSeconds { get; set; }
    public int Position { get; set; }
}

public class RaceDto
{
    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
    public DateTime Date { get; set; }
}

public class TrackDto
{
    public string Name { get; set; } = null!;
    public double LengthInKm { get; set; }
} 