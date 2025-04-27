using FluentValidation;
using MetroOne.DTO.Requests;

namespace MetroOne.Api.Validators;

public class CreateTrainRequestValidator : AbstractValidator<CreateTrainRequest>
{
    public CreateTrainRequestValidator()
    {
        RuleFor(x => x.TrainName)
            .NotEmpty().WithMessage("Train name is required.")
            .MaximumLength(100).WithMessage("Train name must be at most 100 characters.");

        RuleFor(x => x.Capacity)
            .InclusiveBetween(50, 500)
            .WithMessage("Capacity must be between 50 and 500.");

        RuleFor(x => x.EstimatedTime)
            .NotNull().WithMessage("Estimated time is required.");

        RuleFor(x => x.RouteLocationId)
            .GreaterThan(0)
            .WithMessage("RouteLocationId must be a positive number.");
    }
}
