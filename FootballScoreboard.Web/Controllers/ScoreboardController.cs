using FootballScoreboard.Application.Interfaces;
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
        scoreboardService.StartGame(homeTeam, awayTeam);
        return Json(new { success = true, matches = scoreboardService.GetSummary() });
    }

    [HttpPost]
    public IActionResult FinishGame(string homeTeam, string awayTeam)
    {
        scoreboardService.FinishGame(homeTeam, awayTeam);
        return Json(new { success = true, matches = scoreboardService.GetSummary() });
    }

    [HttpPost]
    public IActionResult UpdateScore(string homeTeam, string awayTeam, int homeScore, int awayScore)
    {
        scoreboardService.UpdateScore(homeTeam, awayTeam, homeScore, awayScore);
        return Json(new { success = true, matches = scoreboardService.GetSummary() });
    }
}
