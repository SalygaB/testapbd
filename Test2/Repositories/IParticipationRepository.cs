using Test2.Models;

namespace Test2.Repositories;

public interface IParticipationRepository
{
    Task<IEnumerable<Participation>> GetByTrackRaceAsync(int trackRaceId);
    Task<Participation> AddAsync(Participation participation);
    Task UpdateAsync(Participation participation);
} 