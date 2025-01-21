using FootballScoreboard.Application.DTOs;
using FootballScoreboard.Application.Interfaces;
using FootballScoreboard.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FootballScoreboard.Web.Controllers;
public class ScoreboardController(IScoreboardService scoreboardService) : Controller
{
    public IActionResult Index()
    {
        var matches = scoreboardService.GetSummary();
        return View(matches);
    }

    [HttpPost]
    public IActionResult StartGame(string homeTeam, string awayTeam)
    {
        scoreboardService.StartGame(new StartGameDto {AwayTeam = awayTeam , HomeTeam = homeTeam});
        return Json(new { success = true, matches = scoreboardService.GetSummary() });
    }

    [HttpPost]
    public IActionResult FinishGame(Guid matchId)
    {
        scoreboardService.FinishGame(matchId);
        return Json(new { success = true, matches = scoreboardService.GetSummary() });
    }

    [HttpPost]
    public IActionResult UpdateScore(Guid matchId, int homeScore, int awayScore)
    {
        scoreboardService.UpdateScore(matchId, homeScore, awayScore);
        return Json(new { success = true, matches = scoreboardService.GetSummary() });
    }
   
    public IActionResult GetMatches()
    {
        var matches = scoreboardService.GetSummary();
        return Ok(matches);
    }

    [HttpPost]
    public IActionResult UpdateMatchStatus(Guid matchId, MatchStatus status)
    {
        scoreboardService.UpdateMatchStatus(matchId, status);
        return Json(new { success = true, matches = scoreboardService.GetSummary() });
    }

    [HttpPost]
    public IActionResult AddGameEvent(Guid matchId, string player, GameEventType eventType, bool isHomeTeam)
    {
        scoreboardService.AddGameEvent(new GameEventDto { EventType = eventType, IsHomeTeam = isHomeTeam, Player = player }, matchId);
        return Json(new { success = true, matches = scoreboardService.GetSummary() });
    }
}
