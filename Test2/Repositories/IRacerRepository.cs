using Test2.Models;

namespace Test2.Repositories;

public interface IRacerRepository
{
    Task<Racer?> GetByIdAsync(int id);
    Task<IEnumerable<Racer>> GetAllAsync();
    Task<bool> ExistsAsync(int id);
} 