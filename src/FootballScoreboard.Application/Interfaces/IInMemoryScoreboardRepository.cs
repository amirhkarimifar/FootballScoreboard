using FootballScoreboard.Domain.Entities;

namespace FootballScoreboard.Application.Interfaces;
public interface IInMemoryScoreboardRepository
{
    void AddMatch(Match match);
    void RemoveMatch(Guid matchId);
    Match GetMatch(string homeTeam, string awayTeam);
    List<Match> GetAllMatches();
    Match? GetById(Guid matchId);
}
