using FootballScoreboard.Domain.Enums;

namespace FootballScoreboard.Application.DTOs;
public record GameEventDto
{
    public string? Player { get; init; }
    public GameEventType EventType { get; init; }
    public bool IsHomeTeam { get; init; }
}
