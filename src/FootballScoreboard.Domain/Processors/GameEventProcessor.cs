using FootballScoreboard.Domain.Entities;
using FootballScoreboard.Domain.Enums;

namespace FootballScoreboard.Domain.Processors;
public class GameEventProcessor : IGameEventProcessor
{
    public void ProcessEvent(Match match, GameEvent gameEvent)
    {
        match.AddEvent(gameEvent);  

        if (gameEvent.EventType == GameEventType.Goal)
        {
            if (gameEvent.IsHomeTeam)
                match.IncreaseHomeScore();
            else
                match.IncreaseAwayScore();
        }
        else if (gameEvent.EventType == GameEventType.RevertGoal)
        {
            match.RevertGoal(gameEvent.IsHomeTeam);
        }
    }
}
