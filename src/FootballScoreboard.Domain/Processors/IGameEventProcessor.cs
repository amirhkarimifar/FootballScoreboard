using FootballScoreboard.Domain.Entities;

namespace FootballScoreboard.Domain.Processors;
public interface IGameEventProcessor
{
    void ProcessEvent(Match match, GameEvent gameEvent);
}
