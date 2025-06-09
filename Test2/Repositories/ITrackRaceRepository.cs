using Test2.Models;

namespace Test2.Repositories;

public interface ITrackRaceRepository
{
    Task<TrackRace?> GetByRaceAndTrackAsync(int raceId, int trackId);
    Task<TrackRace> AddAsync(TrackRace trackRace);
    Task UpdateAsync(TrackRace trackRace);
} 