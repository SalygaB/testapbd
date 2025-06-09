using Test2.Dtos;

namespace Test2.Services;

public interface IRacerService
{
    Task<RacerParticipationDto?> GetParticipationsAsync(int racerId);
    Task AddParticipationsAsync(AddParticipationsRequest request);
} 