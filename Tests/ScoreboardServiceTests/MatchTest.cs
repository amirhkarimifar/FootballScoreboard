using FluentValidation;
using FluentValidation.Results;
using FootballScoreboard.Application.DTOs;
using FootballScoreboard.Application.Interfaces;
using FootballScoreboard.Application.Services;
using FootballScoreboard.Application.Validators;
using FootballScoreboard.Domain.Entities;
using FootballScoreboard.Domain.Enums;
using FootballScoreboard.Domain.Processors;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Match = FootballScoreboard.Domain.Entities.Match;

namespace ScoreboardServiceTests;

public class MatchTest
{
    private readonly Mock<IInMemoryScoreboardRepository> _repositoryMock;
    private readonly Mock<IGameEventProcessor> _gameEventProcessorMock;
    private readonly Mock<IValidator<StartGameDto>> _validationMock;
    private readonly ScoreboardService _service;

    public MatchTest()
    {
        _repositoryMock = new Mock<IInMemoryScoreboardRepository>();
        _gameEventProcessorMock = new Mock<IGameEventProcessor>();
        _validationMock = new Mock<IValidator<StartGameDto>>();
        _service = new ScoreboardService(_repositoryMock.Object, _gameEventProcessorMock.Object, _validationMock.Object);
    }

    [Fact]
    public void StartGame_ShouldAddNewMatch()
    {
        var dto = new StartGameDto { AwayTeam = "Germany", HomeTeam = "Spain" };
        
        var validationResult = new ValidationResult();  
        _validationMock.Setup(v => v.Validate(dto)).Returns(validationResult);

        _service.StartGame(dto);

        _repositoryMock.Verify(r => r.AddMatch(It.IsAny<Match>()), Times.Once);
    }
    [Fact]
    public void AddGameEvent_ShouldProcessEvent()
    {
        var match = new Match("Spain", "Germany");
        var gameEventDto = new GameEventDto
        {
            Player = "Player1",
            EventType = GameEventType.Goal,
            IsHomeTeam = true
        };
        _repositoryMock.Setup(r => r.GetById(match.Id)).Returns(match);

        _service.AddGameEvent(gameEventDto, match.Id);
        _gameEventProcessorMock.Verify(g => g.ProcessEvent(match, It.IsAny<GameEvent>()), Times.Once);
    }

    [Fact]
    public void RevertGoal_ShouldProcessRevertEvent()
    {
        var match = new Match("Spain", "Germany");
        _repositoryMock.Setup(r => r.GetById(match.Id)).Returns(match);

        _service.RevertGoal(match.Id, true);

        _gameEventProcessorMock.Verify(g => g.ProcessEvent(match, It.Is<GameEvent>(e => e.EventType == GameEventType.RevertGoal && e.IsHomeTeam)), Times.Once);
    }

    [Fact]
    public void UpdateMatchStatus_ShouldChangeStatus()
    {
        var match = new Match("Spain", "Germany");
        _repositoryMock.Setup(r => r.GetById(match.Id)).Returns(match);

        _service.UpdateMatchStatus(match.Id, MatchStatus.Finished);

        Assert.Equal(MatchStatus.Finished, match.Status);
    }

}