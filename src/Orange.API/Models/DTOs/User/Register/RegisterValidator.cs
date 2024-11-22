namespace Orange.API.Models.DTOs.User.Register;

using FluentValidation;

public class RegisterValidator : AbstractValidator<RegisterDTO>
{
	public RegisterValidator()
	{
		RuleFor(x => x.FirstName)
			.NotEmpty().WithMessage("First name is required.")
			.MaximumLength(50).WithMessage("First name must be a maximum of 50 characters.");

		RuleFor(x => x.LastName)
			.NotEmpty().WithMessage("Last name is required.")
			.MaximumLength(50).WithMessage("Last name must be a maximum of 50 characters.");

		RuleFor(x => x.AvatarUrl)
			.NotEmpty().WithMessage("A URL do avatar é obrigatória.")
			.MaximumLength(250).WithMessage("Avatar url must be a maximum of 250 characters.")
			.Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
			.WithMessage("Avatar URL is invalid.");

		RuleFor(x => x.Email)
		.NotEmpty().WithMessage("Email is required.")
		.EmailAddress().WithMessage("Email is invalid");

		RuleFor(x => x.Password)
			.NotEmpty().WithMessage("Password is required.")
			.MinimumLength(5).WithMessage("Password must be at least 5 characters long.")
			.Matches(@"[A-Z]").WithMessage("Password must contain at least 1 uppercase letter.")
			.Matches(@"[a-z]").WithMessage("Password must contain at least 1 lowercase letter.")
			.Matches(@"\d").WithMessage("Password must contain at least 1 number.");
	}
}
