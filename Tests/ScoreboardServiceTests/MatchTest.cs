using FootballScoreboard.Application.Interfaces;
using FootballScoreboard.Application.Services;
using Moq;
using Match = FootballScoreboard.Domain.Entities.Match;

namespace ScoreboardServiceTests;

public class MatchTest
{
    private readonly Mock<IInMemoryScoreboardRepository> _repositoryMock;
    private readonly ScoreboardService _service;

    public MatchTest()
    {
        _repositoryMock = new Mock<IInMemoryScoreboardRepository>();
        _service = new ScoreboardService(_repositoryMock.Object);
    }

    [Fact]
    public void StartGame_ShouldAddNewMatch()
    {
        _service.StartGame("Spain", "Germany");
        _repositoryMock.Verify(r => r.AddMatch(It.IsAny<Match>()), Times.Once);
    }

    [Fact]
    public void FinishGame_ShouldRemoveMatch()
    {
        var match = new Match("Spain", "Germany");
        _repositoryMock.Setup(r => r.GetMatch("Spain", "Germany")).Returns(match);

        _service.FinishGame("Spain", "Germany");

        _repositoryMock.Verify(r => r.RemoveMatch(match), Times.Once);
    }

    [Fact]
    public void UpdateScore_ShouldModifyMatchScore()
    {
        var match = new Match("Spain", "Germany");
        _repositoryMock.Setup(r => r.GetMatch("Spain", "Germany")).Returns(match);

        _service.UpdateScore("Spain", "Germany", 2, 3);

        Assert.Equal(2, match.HomeScore);
        Assert.Equal(3, match.AwayScore);
    }
}