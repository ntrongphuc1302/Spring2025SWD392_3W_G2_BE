using FluentValidation;
using MetroOne.DTO.Requests;

namespace MetroOne.Api.Validators;


public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("User ID must be greater than 0.");

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name is required.")
            .MinimumLength(3).WithMessage("Full name must be at least 3 characters.")
            .MaximumLength(100).WithMessage("Full name must be at most 100 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Permission)
            .NotEmpty().WithMessage("Permission is required.")
            .Must(role => role == "Admin" || role == "Passenger")
            .WithMessage("Role must be either Admin or Passenger.");

        RuleFor(x => x.Status)
            .Must(status => status == "Active" || status == "Deactivated" || status == null)
            .WithMessage("Status must be Active or Deactivated.");
    }
}
