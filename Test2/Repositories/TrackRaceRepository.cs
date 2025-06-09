using Microsoft.EntityFrameworkCore;
using Test2.Data;
using Test2.Models;

namespace Test2.Repositories;

public class TrackRaceRepository : ITrackRaceRepository
{
    private readonly GrandPrixContext _context;
    
    public TrackRaceRepository(GrandPrixContext context)
    {
        _context = context;
    }
    
    public async Task<TrackRace?> GetByRaceAndTrackAsync(int raceId, int trackId)
    {
        return await _context.TrackRaces
            .Include(tr => tr.Race)
            .Include(tr => tr.Track)
            .Include(tr => tr.Participations)
            .FirstOrDefaultAsync(tr => tr.RaceId == raceId && tr.TrackId == trackId);
    }
    
    public async Task<TrackRace> AddAsync(TrackRace trackRace)
    {
        await _context.TrackRaces.AddAsync(trackRace);
        await _context.SaveChangesAsync();
        return trackRace;
    }
    
    public async Task UpdateAsync(TrackRace trackRace)
    {
        _context.TrackRaces.Update(trackRace);
        await _context.SaveChangesAsync();
    }
} 