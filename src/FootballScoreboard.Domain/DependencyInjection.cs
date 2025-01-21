using FootballScoreboard.Domain.Processors;
using Microsoft.Extensions.DependencyInjection;

namespace FootballScoreboard.Domain;
public static class DependencyInjection
{
    public static void AddDomainServices(this IServiceCollection service)
    {
        service.AddTransient<IGameEventProcessor, GameEventProcessor>();
    }
}
