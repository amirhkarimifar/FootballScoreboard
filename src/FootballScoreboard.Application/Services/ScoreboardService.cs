using FluentValidation;
using FootballScoreboard.Application.DTOs;
using FootballScoreboard.Application.Interfaces;
using FootballScoreboard.Application.Mappings;
using FootballScoreboard.Domain.Entities;
using FootballScoreboard.Domain.Enums;
using FootballScoreboard.Domain.Processors;

namespace FootballScoreboard.Application.Services;
public class ScoreboardService(IInMemoryScoreboardRepository repository,
    IGameEventProcessor gameEventProcessor,
    IValidator<StartGameDto> validator
    ) : IScoreboardService
{

    public void StartGame(StartGameDto startGameDto)
    {
        var validationResult = validator.Validate(startGameDto);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var match = new Match(startGameDto.HomeTeam!, startGameDto.AwayTeam!);
        match.StartGame();
        repository.AddMatch(match);
    }

    public void FinishGame(Guid matchId)
    {
        repository.RemoveMatch(matchId);
    }

    public void UpdateScore(Guid matchId, int homeScore, int awayScore)
    {
        var match = repository.GetById(matchId);
        match?.UpdateScore(homeScore, awayScore);
    }

    public void UpdateMatchStatus(Guid matchId, MatchStatus status)
    {
        var match = repository.GetById(matchId);
        match?.UpdateMatchStatus(status);
    }

    public void AddGameEvent(GameEventDto gameEventDto, Guid matchId)
    {
        var match = repository.GetById(matchId);
        if (match == null) return;

        if (gameEventDto is null)
        {
            throw new ArgumentNullException(nameof(gameEventDto));
        }

        var gameEvent = new GameEvent(gameEventDto.Player, gameEventDto.EventType, gameEventDto.IsHomeTeam);
        gameEventProcessor.ProcessEvent(match, gameEvent);
    }
    public void RevertGoal(Guid matchId, bool isHomeTeam)
    {
        var match = repository.GetById(matchId);
        if (match == null) return;

        var gameEvent = new GameEvent("VAR Decision", GameEventType.RevertGoal, isHomeTeam);
        gameEventProcessor.ProcessEvent(match, gameEvent);
    }
    public List<MatchDto> GetSummary()
    {
        var matches = repository.GetAllMatches()
            .OrderByDescending(m => m.HomeScore + m.AwayScore) // Sort by total score
            .ThenByDescending(m => m.Id) // Then by most recently added
            .ToList();

        return matches.Select(MatchMapper.ToDto).ToList();
    }
}
