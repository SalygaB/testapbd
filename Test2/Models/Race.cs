using System.ComponentModel.DataAnnotations;

namespace Test2.Models;

public class Race
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = null!;
    
    [Required]
    [StringLength(100)]
    public string Location { get; set; } = null!;
    
    [Required]
    public DateTime Date { get; set; }
    
    public ICollection<TrackRace> TrackRaces { get; set; } = new List<TrackRace>();
} 