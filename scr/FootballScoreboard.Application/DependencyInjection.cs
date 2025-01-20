using FootballScoreboard.Application.Interfaces;
using FootballScoreboard.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FootballScoreboard.Application;
public static class DependencyInjection
{
    public static void AddServices(this IServiceCollection service)
    {
        service.AddTransient<IScoreboardService, ScoreboardService>();
    }
}
