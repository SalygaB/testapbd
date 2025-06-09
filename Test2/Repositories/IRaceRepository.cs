using Test2.Models;

namespace Test2.Repositories;

public interface IRaceRepository
{
    Task<Race?> GetByNameAsync(string name);
    Task<IEnumerable<Race>> GetAllAsync();
    Task<Race> AddAsync(Race race);
} 