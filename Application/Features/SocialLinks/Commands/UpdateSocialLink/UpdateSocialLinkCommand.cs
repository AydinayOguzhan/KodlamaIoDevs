using Application.Features.SocialLinks.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialLinks.Commands.UpdateSocialLink
{
    public class UpdateSocialLinkCommand: IRequest<UpdateSocialLinkDto>
    {
        public UpdateSocialLinkDto UpdateUserLinkDto { get; set; }

        public class UpdateSocialLinkCommandHandler : IRequestHandler<UpdateSocialLinkCommand, UpdateSocialLinkDto>
        {
            private readonly IMapper _mapper;
            private readonly ISocialLinkRepository _socialLinkRepository;

            public UpdateSocialLinkCommandHandler(IMapper mapper, ISocialLinkRepository socialLinkRepository)
            {
                _mapper = mapper;
                _socialLinkRepository = socialLinkRepository;
            }

            public async Task<UpdateSocialLinkDto> Handle(UpdateSocialLinkCommand request, CancellationToken cancellationToken)
            {
                SocialLink socialLink = _mapper.Map<SocialLink>(request.UpdateUserLinkDto);
                SocialLink updatedSocialLink = await _socialLinkRepository.UpdateAsync(socialLink);
                UpdateSocialLinkDto mappedSocialLink = _mapper.Map<UpdateSocialLinkDto>(updatedSocialLink);
                return mappedSocialLink;
            }
        }
    }
}
