using FootballScoreboard.Application.DTOs;
using FootballScoreboard.Domain.Entities;

namespace FootballScoreboard.Application.Mappings;
public static class MatchMapper
{
    public static MatchDto ToDto(Match match)
    {
        return new MatchDto
        {
            MatchId = match.Id,
            HomeTeam = match.HomeTeam,
            AwayTeam = match.AwayTeam,
            HomeScore = match.HomeScore,
            AwayScore = match.AwayScore,
            Status = match.Status.ToString(),
            Events = match.Events.Select(ToDto).ToList()
        };
    }

    private static GameEventDto ToDto(GameEvent gameEvent)
    {
        return new GameEventDto
        {
            Player = gameEvent.PlayerName,
            EventType = gameEvent.EventType,
            IsHomeTeam = gameEvent.IsHomeTeam
        };
    }
}
