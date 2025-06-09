using Test2.Dtos;
using Test2.Models;
using Test2.Repositories;

namespace Test2.Services;

public class RacerService : IRacerService
{
    private readonly IRacerRepository _racerRepository;
    private readonly IRaceRepository _raceRepository;
    private readonly ITrackRepository _trackRepository;
    private readonly ITrackRaceRepository _trackRaceRepository;
    private readonly IParticipationRepository _participationRepository;
    
    public RacerService(
        IRacerRepository racerRepository,
        IRaceRepository raceRepository,
        ITrackRepository trackRepository,
        ITrackRaceRepository trackRaceRepository,
        IParticipationRepository participationRepository)
    {
        _racerRepository = racerRepository;
        _raceRepository = raceRepository;
        _trackRepository = trackRepository;
        _trackRaceRepository = trackRaceRepository;
        _participationRepository = participationRepository;
    }
    
    public async Task<RacerParticipationDto?> GetParticipationsAsync(int racerId)
    {
        var racer = await _racerRepository.GetByIdAsync(racerId);
        if (racer == null)
            return null;
            
        return new RacerParticipationDto
        {
            RacerId = racer.Id,
            RacerName = racer.Name,
            Participations = racer.Participations.Select(p => new ParticipationDto
            {
                RaceName = p.TrackRace.Race.Name,
                TrackName = p.TrackRace.Track.Name,
                Position = p.Position,
                FinishTimeInSeconds = p.FinishTimeInSeconds
            }).ToList()
        };
    }
    
    public async Task AddParticipationsAsync(AddParticipationsRequest request)
    {
        var race = await _raceRepository.GetByNameAsync(request.RaceName);
        if (race == null)
            throw new KeyNotFoundException($"Race '{request.RaceName}' not found");
            
        var track = await _trackRepository.GetByNameAsync(request.TrackName);
        if (track == null)
            throw new KeyNotFoundException($"Track '{request.TrackName}' not found");
            
        var trackRace = await _trackRaceRepository.GetByRaceAndTrackAsync(race.Id, track.Id);
        if (trackRace == null)
        {
            trackRace = new TrackRace
            {
                RaceId = race.Id,
                TrackId = track.Id,
                BestTimeInSeconds = null
            };
            trackRace = await _trackRaceRepository.AddAsync(trackRace);
        }
        
        foreach (var participationRequest in request.Participations)
        {
            var racer = await _racerRepository.GetByIdAsync(participationRequest.RacerId);
            if (racer == null)
                throw new KeyNotFoundException($"Racer with ID {participationRequest.RacerId} not found");
                
            var participation = new Participation
            {
                RacerId = racer.Id,
                TrackRaceId = trackRace.Id,
                Position = participationRequest.Position,
                FinishTimeInSeconds = participationRequest.FinishTimeInSeconds
            };
            
            await _participationRepository.AddAsync(participation);
            
            if (trackRace.BestTimeInSeconds == null || participationRequest.FinishTimeInSeconds < trackRace.BestTimeInSeconds)
            {
                trackRace.BestTimeInSeconds = participationRequest.FinishTimeInSeconds;
                await _trackRaceRepository.UpdateAsync(trackRace);
            }
        }
    }
} 