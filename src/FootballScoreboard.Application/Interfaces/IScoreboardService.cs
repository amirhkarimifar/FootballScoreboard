using FootballScoreboard.Application.DTOs;
using FootballScoreboard.Domain.Enums;

namespace FootballScoreboard.Application.Interfaces;
public interface IScoreboardService
{
    void StartGame(StartGameDto startGameDto);
    void FinishGame(Guid matchId);
    void UpdateScore(Guid matchId, int homeScore, int awayScore);
    void UpdateMatchStatus(Guid matchId, MatchStatus status);
    void AddGameEvent(GameEventDto gameEventDto, Guid matchId);
    void RevertGoal(Guid matchId, bool isHomeTeam);
    List<MatchDto> GetSummary();
}
