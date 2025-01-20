using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballScoreboard.Domain.Entities;

namespace FootballScoreboard.Application.Interfaces;
public interface IScoreboardService
{
    void StartGame(string homeTeam, string awayTeam);
    void FinishGame(string homeTeam, string awayTeam);
    void UpdateScore(string homeTeam, string awayTeam, int homeScore, int awayScore);
    List<Match> GetSummary();
}
