using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommandValidator: AbstractValidator<CreateTechnologyCommand>
    {
        public CreateTechnologyCommandValidator()
        {
            RuleFor(t=>t.ProgrammingLanguageId).NotNull().NotEmpty();
            RuleFor(t=>t.Name).NotNull().NotEmpty().MinimumLength(1);
        }
    }
}
