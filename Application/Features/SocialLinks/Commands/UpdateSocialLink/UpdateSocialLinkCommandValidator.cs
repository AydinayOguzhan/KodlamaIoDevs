using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialLinks.Commands.UpdateSocialLink
{
    public class UpdateSocialLinkCommandValidator: AbstractValidator<UpdateSocialLinkCommand>
    {
        public UpdateSocialLinkCommandValidator()
        {
            RuleFor(l=>l.UpdateUserLinkDto.Id).NotNull().NotEmpty();
            RuleFor(l=>l.UpdateUserLinkDto.UserId).NotNull().NotEmpty();
            RuleFor(l=>l.UpdateUserLinkDto.Name).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(l => l.UpdateUserLinkDto.Url).NotNull().NotEmpty();
        }
    }
}
