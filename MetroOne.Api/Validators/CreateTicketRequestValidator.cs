using FluentValidation;
using MetroOne.DTO.Requests;

namespace MetroOne.Api.Validators;

public class CreateTicketRequestValidator : AbstractValidator<CreateTicketRequest>
{
    public CreateTicketRequestValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("UserId must be greater than 0.");

        RuleFor(x => x.TripId)
            .GreaterThan(0).WithMessage("TripId must be greater than 0.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.");

        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("Status is required.")
            .Must(status => status == "Active" || status == "Expired")
            .WithMessage("Status must be either Pending, Paid, or Expired.");
        
        RuleFor(x => x.ValidTo)
            .NotEmpty().WithMessage("ValidTo is required.")
            .Must(validTo => validTo > DateTime.UtcNow)
            .WithMessage("ValidTo must be in the future.");

    }
}
