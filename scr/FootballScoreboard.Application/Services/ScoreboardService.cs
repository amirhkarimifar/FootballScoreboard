using FootballScoreboard.Application.Interfaces;
using FootballScoreboard.Domain.Entities;
 
namespace FootballScoreboard.Application.Services;
public class ScoreboardService(IInMemoryScoreboardRepository repository) : IScoreboardService
{
    public void StartGame(string homeTeam, string awayTeam)
    {
        if (repository.GetMatch(homeTeam, awayTeam) != null)
            throw new InvalidOperationException("A team is already playing.");

        repository.AddMatch(new Match(homeTeam, awayTeam));
    }

    public void FinishGame(string homeTeam, string awayTeam)
    {
        var match = repository.GetMatch(homeTeam, awayTeam);
        if (match != null)
            repository.RemoveMatch(match);
    }

    public void UpdateScore(string homeTeam, string awayTeam, int homeScore, int awayScore)
    {
        var match = repository.GetMatch(homeTeam, awayTeam);
        if (match != null)
            match.UpdateScore(homeScore, awayScore);
    }

    public List<Match> GetSummary()
    {
        return repository.GetAllMatches()
            .OrderByDescending(m => m.HomeScore + m.AwayScore)
            .ThenByDescending(m => m.StartTime)
            .ToList();
    }
}
