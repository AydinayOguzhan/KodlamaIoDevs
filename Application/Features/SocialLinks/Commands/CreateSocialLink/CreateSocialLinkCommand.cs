﻿using Application.Features.SocialLinks.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialLinks.Commands.CreateSocialLink
{
    public class CreateSocialLinkCommand: IRequest<CreatedSocialLinkDto>
    {
        public CreateSocialLinkDto CreateSocialLinkDto { get; set; }

        public class CreateSocialLinkCommandHandler : IRequestHandler<CreateSocialLinkCommand, CreatedSocialLinkDto>
        {
            private readonly IMapper _mapper;
            private readonly ISocialLinkRepository _socialLinkRepository;

            public CreateSocialLinkCommandHandler(IMapper mapper, ISocialLinkRepository socialLinkRepository)
            {
                _mapper = mapper;
                _socialLinkRepository = socialLinkRepository;
            }

            public async Task<CreatedSocialLinkDto> Handle(CreateSocialLinkCommand request, CancellationToken cancellationToken)
            {
                SocialLink socialLink = _mapper.Map<SocialLink>(request.CreateSocialLinkDto);
                SocialLink addedSocialLink = await _socialLinkRepository.AddAsync(socialLink);
                CreatedSocialLinkDto mappedSocialLink = _mapper.Map<CreatedSocialLinkDto>(addedSocialLink);
                return mappedSocialLink;
            }
        }
    }
}
