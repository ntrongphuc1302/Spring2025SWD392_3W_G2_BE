using FluentValidation;
using MetroOne.DTO.Requests;

namespace MetroOne.Api.Validators;

public class UpdateTrainRequestValidator : AbstractValidator<UpdateTrainRequest>
{
    public UpdateTrainRequestValidator()
    {
        RuleFor(x => x.TrainId)
            .NotEmpty().WithMessage("Train ID is required.")
            .GreaterThan(0).WithMessage("Train ID must be a positive number.");

        RuleFor(x => x.TrainName)
            .MaximumLength(100).WithMessage("Train name must be at most 100 characters.");

        RuleFor(x => x.Capacity)
            .InclusiveBetween(50, 500)
            .When(x => x.Capacity.HasValue)
            .WithMessage("Capacity must be between 50 and 500.");

        RuleFor(x => x.EstimatedTime)
            .NotNull().WithMessage("Estimated time is required.")
            .When(x => x.EstimatedTime.HasValue);

        RuleFor(x => x.RouteLocationId)
            .GreaterThan(0)
            .When(x => x.RouteLocationId.HasValue)
            .WithMessage("RouteLocationId must be a positive number.");
    }
}
