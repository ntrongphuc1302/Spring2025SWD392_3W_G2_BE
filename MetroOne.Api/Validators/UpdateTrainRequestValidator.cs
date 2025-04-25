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
            .NotEmpty().WithMessage("Train name is required.")
            .MaximumLength(100).WithMessage("Train name must be at most 100 characters.");

        RuleFor(x => x.StartStationId)
            .GreaterThan(0).WithMessage("Start station ID must be a positive number.");

        RuleFor(x => x.EndStationId)
            .GreaterThan(0).WithMessage("End station ID must be a positive number.")
            .NotEqual(x => x.StartStationId).WithMessage("Start and end stations must be different.");

        RuleFor(x => x.Capacity)
            .InclusiveBetween(50, 500)
            .WithMessage("Capacity must be between 50 and 500.");

        RuleFor(x => x.EstimatedTime)
            .NotNull().WithMessage("Estimated time is required.");
    }
}
