using Application.Features.SocialLinks.Commands.DeleteSocialLink;
using Application.Features.SocialLinks.Commands.UpdateSocialLink;
using Application.Features.SocialLinks.Dtos;
using Application.Features.SocialLinks.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialLinks.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            //GetListSocialLink
            CreateMap<SocialLink, SocialLinkListDto>().ForMember(m=>m.UserName, opt=>opt.MapFrom(m=>m.User.FirstName)).ReverseMap();
            CreateMap<IPaginate<SocialLink>, SocialLinkListModel>();

            //CreateSocialLink
            CreateMap<SocialLink, CreateSocialLinkDto>().ReverseMap();
            CreateMap<SocialLink, CreatedSocialLinkDto>().ReverseMap();

            //UpdateSocialLink
            CreateMap<SocialLink, UpdateSocialLinkDto>().ReverseMap();
            CreateMap<SocialLink, UpdateSocialLinkCommand>().ReverseMap();

            //DeleteSocialLink
            CreateMap<DeleteSocialLinkCommand, SocialLink>().ReverseMap();
            CreateMap<SocialLink, DeletedSocialLinkDto>().ReverseMap();
        }
    }
}
