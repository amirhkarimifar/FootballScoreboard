using FootballScoreboard.Domain.Enums;

namespace FootballScoreboard.Domain.Entities;
public class GameEvent(string? playerName, GameEventType eventType , bool isHomeTeam)
{
    public string? PlayerName { get; } = playerName;
    public GameEventType EventType { get; } = eventType;
    public DateTime Time { get; } = DateTime.UtcNow;
    public bool IsHomeTeam { get; set; } = isHomeTeam;
}
