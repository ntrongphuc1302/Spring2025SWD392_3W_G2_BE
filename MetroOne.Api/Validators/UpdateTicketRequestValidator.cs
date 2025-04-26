using FluentValidation;
using MetroOne.DTO.Requests;

namespace MetroOne.Api.Validators;

public class UpdateTicketRequestValidator : AbstractValidator<UpdateTicketRequest>
{
    public UpdateTicketRequestValidator()
    {
        RuleFor(x => x.TicketId)
            .GreaterThan(0).WithMessage("TicketId must be greater than 0.");

        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("UserId must be greater than 0.");

        RuleFor(x => x.TripId)
            .GreaterThan(0).WithMessage("TripId must be greater than 0.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.");

        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("Status cannot be empty.")
            .Must(status => status == "Active" || status == "Expired")
            .WithMessage("Status must be either 'Active' or 'Expired'.");

        RuleFor(x => x.ValidTo)
            .Must(validTo => validTo == null || validTo > DateTime.UtcNow)
            .WithMessage("ValidTo must be in the future or null.");
    }
}
