using Microsoft.EntityFrameworkCore;
using Test2.Data;
using Test2.Models;

namespace Test2.Repositories;

public class TrackRepository : ITrackRepository
{
    private readonly GrandPrixContext _context;
    
    public TrackRepository(GrandPrixContext context)
    {
        _context = context;
    }
    
    public async Task<Track?> GetByNameAsync(string name)
    {
        return await _context.Tracks
            .Include(t => t.TrackRaces)
            .ThenInclude(tr => tr.Race)
            .FirstOrDefaultAsync(t => t.Name == name);
    }
    
    public async Task<IEnumerable<Track>> GetAllAsync()
    {
        return await _context.Tracks
            .Include(t => t.TrackRaces)
            .ThenInclude(tr => tr.Race)
            .ToListAsync();
    }
    
    public async Task<Track> AddAsync(Track track)
    {
        await _context.Tracks.AddAsync(track);
        await _context.SaveChangesAsync();
        return track;
    }
} 