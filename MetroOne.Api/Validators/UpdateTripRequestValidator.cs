using FluentValidation;
using MetroOne.DTO.Requests;

namespace MetroOne.Api.Validators;
public class UpdateTripRequestValidator : AbstractValidator<UpdateTripRequest>
{
    public UpdateTripRequestValidator()
    {
        RuleFor(x => x.TripId)
            .NotEmpty().WithMessage("Trip ID is required.")
            .GreaterThan(0).WithMessage("Trip ID must be a positive number.");

        RuleFor(x => x.TrainId)
            .GreaterThan(0)
            .WithMessage("TrainId must be greater than 0.");

        RuleFor(x => x.DepartureTime)
            .NotNull().WithMessage("DepartureTime is required.")
            .LessThan(x => x.ArrivalTime)
            .WithMessage("DepartureTime must be before ArrivalTime.")
            .When(x => x.ArrivalTime.HasValue);

        RuleFor(x => x.ArrivalTime)
            .NotNull().WithMessage("ArrivalTime is required.")
            .GreaterThan(x => x.DepartureTime)
            .WithMessage("ArrivalTime must be after DepartureTime.")
            .When(x => x.DepartureTime.HasValue);
    }
}
