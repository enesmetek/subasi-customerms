using FluentValidation;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.CustomerCommands;
using System.Text.RegularExpressions;

namespace Subasi.CustomerMS.API.Core.Application.ValidationRules.CommandRequestValidators.CustomerCommandRequestValidators
{
    public class UpdateCustomerComandRequestValidator : AbstractValidator<UpdateCustomerCommandRequest>
    {
        public UpdateCustomerComandRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty().WithMessage("Firstname required.")
                .MinimumLength(2).WithMessage("Firstname must not be less than 2 characters.")
                .MaximumLength(50).WithMessage("Firstname must not exceed 50 characters.");

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty().WithMessage("Lastname required.")
                .MinimumLength(2).WithMessage("Lastname must not be less than 2 characters.")
                .MaximumLength(50).WithMessage("Lastname must not exceed 50 characters.");

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty().WithMessage("Email address required.")
                .EmailAddress().WithMessage("A valid email address is required.")
                .MinimumLength(8).WithMessage("Email address must not be less than 8 characters.")
                .MaximumLength(50).WithMessage("Emaill address must not exceed 50 characters.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .NotNull().WithMessage("Phone Number is required.")
                .MinimumLength(10).WithMessage("Phone Number must not be less than 10 characters.")
                .MaximumLength(20).WithMessage("Phone Number must not exceed 50 characters.")
                .Matches(new Regex("^(\\+90|0)?\\s*(\\(\\d{3}\\)[\\s-]*\\d{3}[\\s-]*\\d{2}[\\s-]*\\d{2}|\\(\\d{3}\\)[\\s-]*\\d{3}[\\s-]*\\d{4}|\\(\\d{3}\\)[\\s-]*\\d{7}|\\d{3}[\\s-]*\\d{3}[\\s-]*\\d{4}|\\d{3}[\\s-]*\\d{3}[\\s-]*\\d{2}[\\s-]*\\d{2})$")).WithMessage("Phone Number is not valid.");
        }
    }
}
