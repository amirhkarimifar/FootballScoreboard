namespace FootballScoreboard.Domain.Entities;
public class Match(string homeTeam, string awayTeam)
{
    public string HomeTeam { get; private set; } = homeTeam;
    public string AwayTeam { get; private set; } = awayTeam;
    public int HomeScore { get; private set; } = 0;
    public int AwayScore { get; private set; } = 0;
    public DateTime StartTime { get; private set; } = DateTime.UtcNow;

    public void UpdateScore(int homeScore, int awayScore)
    {
        HomeScore = homeScore;
        AwayScore = awayScore;
    }
}
