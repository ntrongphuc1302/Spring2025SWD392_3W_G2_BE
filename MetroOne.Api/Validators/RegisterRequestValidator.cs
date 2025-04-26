using FluentValidation;
using MetroOne.DTO.Requests;

namespace MetroOne.Api.Validators;


public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name is required.")
            .MaximumLength(100);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.")
            .MaximumLength(100);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters.")
            .MaximumLength(100);

        RuleFor(x => x.Status)
            .Must(s => s == "Active" || s == "Deactivated" || s == null)
            .WithMessage("Status must be Active or Deactivated.");

        RuleFor(x => x.Permission)
            .Must(s => s == "Passenger" || s == "Admin" || s == null)
            .WithMessage("Permission must be Passenger or Admin.");
    }
}
