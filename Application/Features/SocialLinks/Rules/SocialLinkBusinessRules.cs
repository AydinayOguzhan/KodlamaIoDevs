using Application.Features.SocialLinks.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialLinks.Rules
{
    public class SocialLinkBusinessRules
    {
        private readonly ISocialLinkRepository _socialLinkRepository;

        public SocialLinkBusinessRules(ISocialLinkRepository socialLinkRepository)
        {
            _socialLinkRepository = socialLinkRepository;
        }

        public async Task SocialLinkNameCanNotBeDuplicatedWhenInserted(string name, int userId)
        {
            IPaginate<SocialLink> socialLinks = await _socialLinkRepository.GetListAsync(l => l.Name == name && l.UserId == userId);
            if (socialLinks.Items.Any()) throw new BusinessException(SocialLinkConstants.SocialLinkNameAlreadyExists);
        }

        public async Task SocialLinkUrlCanNotBeDuplicatedWhenInserted(string url, int userId)
        {
            IPaginate<SocialLink> socialLinks = await _socialLinkRepository.GetListAsync(l => l.Url == url && l.UserId == userId);
            if (socialLinks.Items.Any()) throw new BusinessException(SocialLinkConstants.SocialLinkUrlAlreadyExists);
        }
    }
}
