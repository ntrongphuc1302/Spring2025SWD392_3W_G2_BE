using FluentValidation;
using MetroOne.DTO.Requests;

namespace MetroOne.Api.Validators;


public class UpdateStationRequestValidator : AbstractValidator<UpdateStationRequest>
{
    public UpdateStationRequestValidator()
    {
        RuleFor(x => x.StationName)
            .MaximumLength(100).WithMessage("Station name must be at most 100 characters.");

        //RuleFor(x => x.StationCode)
        //    .NotEmpty().WithMessage("Station code is required.")
        //    .MaximumLength(20).WithMessage("Station code must be at most 20 characters.");

        //RuleFor(x => x.Location)
        //    .NotEmpty().WithMessage("Location is required.")
        //    .MaximumLength(255).WithMessage("Location must be at most 255 characters.");

        //RuleFor(x => x.OrderInRoute)
        //    .NotNull().WithMessage("Order in route is required.")
        //    .GreaterThan(0).WithMessage("Order in route must be a positive number.");
    }
}
