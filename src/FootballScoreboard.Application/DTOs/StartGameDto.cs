namespace FootballScoreboard.Application.DTOs;
public record StartGameDto
{
    public string? HomeTeam { get; init; }
    public string? AwayTeam { get; init; }
}
