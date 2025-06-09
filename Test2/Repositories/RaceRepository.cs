using Microsoft.EntityFrameworkCore;
using Test2.Data;
using Test2.Models;

namespace Test2.Repositories;

public class RaceRepository : IRaceRepository
{
    private readonly GrandPrixContext _context;
    
    public RaceRepository(GrandPrixContext context)
    {
        _context = context;
    }
    
    public async Task<Race?> GetByNameAsync(string name)
    {
        return await _context.Races
            .Include(r => r.TrackRaces)
            .ThenInclude(tr => tr.Track)
            .FirstOrDefaultAsync(r => r.Name == name);
    }
    
    public async Task<IEnumerable<Race>> GetAllAsync()
    {
        return await _context.Races
            .Include(r => r.TrackRaces)
            .ThenInclude(tr => tr.Track)
            .ToListAsync();
    }
    
    public async Task<Race> AddAsync(Race race)
    {
        await _context.Races.AddAsync(race);
        await _context.SaveChangesAsync();
        return race;
    }
} 