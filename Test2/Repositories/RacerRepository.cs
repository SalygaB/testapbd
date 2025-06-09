using Microsoft.EntityFrameworkCore;
using Test2.Data;
using Test2.Models;

namespace Test2.Repositories;

public class RacerRepository : IRacerRepository
{
    private readonly GrandPrixContext _context;
    
    public RacerRepository(GrandPrixContext context)
    {
        _context = context;
    }
    
    public async Task<Racer?> GetByIdAsync(int id)
    {
        return await _context.Racers
            .Include(r => r.Participations)
            .ThenInclude(p => p.TrackRace)
            .ThenInclude(tr => tr.Race)
            .Include(r => r.Participations)
            .ThenInclude(p => p.TrackRace)
            .ThenInclude(tr => tr.Track)
            .FirstOrDefaultAsync(r => r.Id == id);
    }
    
    public async Task<IEnumerable<Racer>> GetAllAsync()
    {
        return await _context.Racers
            .Include(r => r.Participations)
            .ThenInclude(p => p.TrackRace)
            .ThenInclude(tr => tr.Race)
            .Include(r => r.Participations)
            .ThenInclude(p => p.TrackRace)
            .ThenInclude(tr => tr.Track)
            .ToListAsync();
    }
    
    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Racers.AnyAsync(r => r.Id == id);
    }
} 