using FluentValidation;
using MetroOne.DTO.Requests;

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

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^(\+?\d{1,3})?[- ]?\d{10}$").WithMessage("Invalid phone number format.")
            .MaximumLength(20);

        RuleFor(x => x.Status)
            .Must(s => s == "Active" || s == "Deactivated" || s == null)
            .WithMessage("Status must be Active or Deactivated.");
    }
}
