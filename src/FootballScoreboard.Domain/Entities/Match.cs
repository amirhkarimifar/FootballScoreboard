using FootballScoreboard.Domain.Enums;

namespace FootballScoreboard.Domain.Entities;
public class Match(string homeTeam, string awayTeam)
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string HomeTeam { get; private set; } = homeTeam;
    public string AwayTeam { get; private set; } = awayTeam;
    public int HomeScore { get; private set; } = 0;
    public int AwayScore { get; private set; } = 0;
    public DateTime StartTime { get; private set; } = DateTime.UtcNow;
    public MatchStatus Status { get; private set; } = MatchStatus.NotStarted;
    public List<GameEvent> Events { get; set; } = [];

    public MatchResult Result => HomeScore == AwayScore ? MatchResult.Tie :
        HomeScore > AwayScore ? MatchResult.HomeTeamWon : MatchResult.AwayTeamWon;
    public void StartGame()
    {
        if (Status == MatchStatus.NotStarted)
            Status = MatchStatus.FirstHalf;
    }
    public void UpdateMatchStatus(MatchStatus newStatus)
    {
        Status = newStatus;
    }
    public void IncreaseHomeScore() => HomeScore++;
    public void IncreaseAwayScore() => AwayScore++;

    public void AddEvent(GameEvent gameEvent)
    {
        Events.Add(gameEvent);
    }

    public void UpdateScore(int homeScore, int awayScore)
    {
        HomeScore = homeScore;
        AwayScore = awayScore;
    }

    public void RevertGoal(bool isHomeTeam)
    {
        var lastGoal = Events.LastOrDefault(e => e.EventType == GameEventType.Goal && e.IsHomeTeam == isHomeTeam);
        if (lastGoal != null)
        {
            Events.Add(new GameEvent("VAR Decision", GameEventType.RevertGoal, isHomeTeam));

            if (isHomeTeam && HomeScore > 0)
                HomeScore--;
            else if (!isHomeTeam && AwayScore > 0)
                AwayScore--;
        }
    }
}
