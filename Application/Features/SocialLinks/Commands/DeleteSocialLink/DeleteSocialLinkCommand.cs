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

namespace Application.Features.SocialLinks.Commands.DeleteSocialLink
{
    public class DeleteSocialLinkCommand: IRequest<DeletedSocialLinkDto>
    {
        public int Id { get; set; }

        public class DeleteSocialLinkCommandHandler : IRequestHandler<DeleteSocialLinkCommand, DeletedSocialLinkDto>
        {
            private readonly IMapper _mapper;
            private readonly ISocialLinkRepository _socialLinkRepository;

            public DeleteSocialLinkCommandHandler(IMapper mapper, ISocialLinkRepository socialLinkRepository)
            {
                _mapper = mapper;
                _socialLinkRepository = socialLinkRepository;
            }

            public async Task<DeletedSocialLinkDto> Handle(DeleteSocialLinkCommand request, CancellationToken cancellationToken)
            {
                SocialLink socialLink = _mapper.Map<SocialLink>(request);
                SocialLink deletedSocialLink = await _socialLinkRepository.DeleteAsync(socialLink);
                DeletedSocialLinkDto mappedSocialLink = _mapper.Map<DeletedSocialLinkDto>(deletedSocialLink);
                return mappedSocialLink;
            }
        }
    }
}
