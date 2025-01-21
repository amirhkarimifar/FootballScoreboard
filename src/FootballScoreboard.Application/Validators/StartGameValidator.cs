using FluentValidation;
using FootballScoreboard.Application.DTOs;

namespace FootballScoreboard.Application.Validators;
public class StartGameValidator : AbstractValidator<StartGameDto>, IDtoValidator
{
    public StartGameValidator()
    {
        RuleFor(x => x.HomeTeam).NotEmpty().WithMessage("Home team cannot be empty.");
        RuleFor(x => x.AwayTeam).NotEmpty().WithMessage("Away team cannot be empty.");
    }
}