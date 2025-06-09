using Microsoft.EntityFrameworkCore;
using Test2.Data;
using Test2.Models;

namespace Test2.Repositories;

public class ParticipationRepository : IParticipationRepository
{
    private readonly GrandPrixContext _context;
    
    public ParticipationRepository(GrandPrixContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Participation>> GetByTrackRaceAsync(int trackRaceId)
    {
        return await _context.Participations
            .Include(p => p.Racer)
            .Include(p => p.TrackRace)
            .ThenInclude(tr => tr.Race)
            .Include(p => p.TrackRace)
            .ThenInclude(tr => tr.Track)
            .Where(p => p.TrackRaceId == trackRaceId)
            .ToListAsync();
    }
    
    public async Task<Participation> AddAsync(Participation participation)
    {
        await _context.Participations.AddAsync(participation);
        await _context.SaveChangesAsync();
        return participation;
    }
    
    public async Task UpdateAsync(Participation participation)
    {
        _context.Participations.Update(participation);
        await _context.SaveChangesAsync();
    }
} 