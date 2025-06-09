using Test2.Models;

namespace Test2.Repositories;

public interface ITrackRepository
{
    Task<Track?> GetByNameAsync(string name);
    Task<IEnumerable<Track>> GetAllAsync();
    Task<Track> AddAsync(Track track);
} 