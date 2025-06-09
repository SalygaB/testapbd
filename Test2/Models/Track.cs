using System.ComponentModel.DataAnnotations;

namespace Test2.Models;

public class Track
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = null!;
    
    [Required]
    [Range(0.1, double.MaxValue)]
    public double LengthInKm { get; set; }
    
    public ICollection<TrackRace> TrackRaces { get; set; } = new List<TrackRace>();
} 