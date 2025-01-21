using FootballScoreboard.Application.Interfaces;
using FootballScoreboard.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace FootballScoreboard.Infrastructure;
public static class DependencyInjection 
{
    public static void AddInfrastructureServices(this IServiceCollection service)
    {
        service.AddSingleton<IInMemoryScoreboardRepository, InMemoryScoreboardRepository>();
    }
}
