using System.ComponentModel.DataAnnotations;

namespace Test2.Dtos;

public class AddParticipationsRequest
{
    [Required]
    public string RaceName { get; set; } = null!;
    
    [Required]
    public string TrackName { get; set; } = null!;
    
    [Required]
    public List<ParticipationRequest> Participations { get; set; } = new();
}

public class ParticipationRequest
{
    [Required]
    public int RacerId { get; set; }
    
    [Required]
    [Range(1, int.MaxValue)]
    public int Position { get; set; }
    
    [Required]
    [Range(1, int.MaxValue)]
    public int FinishTimeInSeconds { get; set; }
} 