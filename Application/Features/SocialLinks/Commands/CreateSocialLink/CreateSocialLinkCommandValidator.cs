using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialLinks.Commands.CreateSocialLink
{
    public class CreateSocialLinkCommandValidator: AbstractValidator<CreateSocialLinkCommand>
    {
        public CreateSocialLinkCommandValidator()
        {
            RuleFor(l=>l.CreateSocialLinkDto.UserId).NotNull().NotEmpty();
            RuleFor(l=>l.CreateSocialLinkDto.Name).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(l=>l.CreateSocialLinkDto.Url).NotNull().NotEmpty();
        }
    }
}
