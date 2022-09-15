using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.UpdateTechnology
{
    internal class UpdateTechnologyCommandValidator: AbstractValidator<UpdateTechnologyCommand>
    {
        public UpdateTechnologyCommandValidator()
        {
            RuleFor(t => t.Id).NotNull().NotEmpty();
            RuleFor(t => t.ProgrammingLanguageId).NotNull().NotEmpty();
            RuleFor(t => t.Name).NotNull().NotEmpty().MinimumLength(1);

        }
    }
}
