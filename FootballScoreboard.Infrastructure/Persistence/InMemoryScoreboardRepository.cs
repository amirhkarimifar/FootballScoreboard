﻿using FootballScoreboard.Application.Interfaces;
using FootballScoreboard.Domain.Entities;

namespace FootballScoreboard.Infrastructure.Persistence;
public class InMemoryScoreboardRepository : IInMemoryScoreboardRepository
{
    private readonly List<Match> _matches = [];

    public void AddMatch(Match match) => _matches.Add(match);
    public void RemoveMatch(Match match) => _matches.Remove(match);
    public Match GetMatch(string homeTeam, string awayTeam) => 
        _matches.FirstOrDefault(m => m.HomeTeam == homeTeam && m.AwayTeam == awayTeam)!;
    public List<Match> GetAllMatches() => _matches;
}
