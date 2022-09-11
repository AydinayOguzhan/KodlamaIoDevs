using Application.Features.SocialLinks.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialLinks.Queries.GetListSocialLink
{
    public class GetListSocialLinkQuery: IRequest<SocialLinkListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListSocialLinkQueryHandler : IRequestHandler<GetListSocialLinkQuery, SocialLinkListModel>
        {
            private readonly IMapper _mapper;
            private readonly ISocialLinkRepository _socialLinkRepository;

            public GetListSocialLinkQueryHandler(IMapper mapper, ISocialLinkRepository socialLinkRepository)
            {
                _mapper = mapper;
                _socialLinkRepository = socialLinkRepository;
            }

            public async Task<SocialLinkListModel> Handle(GetListSocialLinkQuery request, CancellationToken cancellationToken)
            {
                IPaginate<SocialLink> socialLinks = await _socialLinkRepository.GetListAsync(include:
                                                    k=>k.Include(k=>k.User),
                                                    index:request.PageRequest.Page,
                                                    size:request.PageRequest.PageSize);

                SocialLinkListModel mappedSocialLinks = _mapper.Map<SocialLinkListModel>(socialLinks);
                return mappedSocialLinks;
            }
        }
    }
}
