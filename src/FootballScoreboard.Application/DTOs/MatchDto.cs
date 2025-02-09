﻿namespace FootballScoreboard.Application.DTOs;
public class MatchDto
{
    public Guid MatchId { get; set; }
    public string? HomeTeam { get; set; }
    public string? AwayTeam { get; set; }
    public int HomeScore { get; set; }
    public int AwayScore { get; set; }
    public string? Status { get; set; }  
    public List<GameEventDto> Events { get; set; } = [];
}
