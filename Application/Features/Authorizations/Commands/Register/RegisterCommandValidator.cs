using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authorizations.Commands.Register
{
    public class RegisterCommandValidator: AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(r=>r.UserForRegisterDto.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(r=>r.UserForRegisterDto.Password).NotNull().NotEmpty().MinimumLength(4);
            RuleFor(r=>r.UserForRegisterDto.FirstName).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(r => r.UserForRegisterDto.LastName).NotNull().NotEmpty().MinimumLength(2);
        }
    }
}
