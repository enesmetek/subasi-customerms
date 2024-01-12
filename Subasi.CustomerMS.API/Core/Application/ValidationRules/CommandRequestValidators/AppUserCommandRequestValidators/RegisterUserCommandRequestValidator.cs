using FluentValidation;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.UserCommands.Requests;

namespace Subasi.CustomerMS.API.Core.Application.ValidationRules.CommandRequestValidators.AppUserCommandRequestValidators
{
    public class RegisterUserCommandRequestValidator : AbstractValidator<RegisterUserCommandRequest>
    {
        public RegisterUserCommandRequestValidator()
        {
            RuleFor(x => x.Username)
                .NotNull()
                .NotEmpty().WithMessage("Username required.")
                .MinimumLength(3).WithMessage("Username must not be less than 3 characters.")
                .MaximumLength(15).WithMessage("Username must not exceed 15 characters.");

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty().WithMessage("Username required.")
                .MinimumLength(3).WithMessage("Username must not be less than 3 characters.");
        }
    }
}
