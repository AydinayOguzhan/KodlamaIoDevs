using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialLinks.Commands.DeleteSocialLink
{
    public class DeleteSocialLinkCommandValidator: AbstractValidator<DeleteSocialLinkCommand>
    {
        public DeleteSocialLinkCommandValidator()
        {
            RuleFor(l=>l.Id).NotEmpty().NotNull();
        }
    }
}
