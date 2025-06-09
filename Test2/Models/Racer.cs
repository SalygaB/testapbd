using System.ComponentModel.DataAnnotations;

namespace Test2.Models;

public class Racer
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; } = null!;
    
    public ICollection<Participation> Participations { get; set; } = new List<Participation>();
} 