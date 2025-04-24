using FluentValidation;
using MetroOne.DTO;

public class CreateTicketRequestValidator : AbstractValidator<CreateTicketRequest>
{
    public CreateTicketRequestValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("UserId must be greater than 0.");

        RuleFor(x => x.TripId)
            .GreaterThan(0).WithMessage("TripId must be greater than 0.");

        RuleFor(x => x.StartStationId)
            .GreaterThan(0).WithMessage("StartStationId must be greater than 0.");

        RuleFor(x => x.EndStationId)
            .GreaterThan(0).WithMessage("EndStationId must be greater than 0.")
            .NotEqual(x => x.StartStationId).WithMessage("Start and End stations cannot be the same.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.");
    }
}
