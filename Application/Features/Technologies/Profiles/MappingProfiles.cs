﻿using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.DeleteTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            //GetListTechnoloy mappings
            CreateMap<Technology, TechnologyListDto>().ForMember(m=>m.ProgrammingLanguageName, opt=>opt.MapFrom(c=>c.ProgrammingLanguage.Name)).ReverseMap();
            CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();

            //CreateTechnology mappings
            CreateMap<CreateTechnologyDto, Technology>().ReverseMap();
            CreateMap<CreateTechnologyCommand, Technology>().ReverseMap();

            //UpdateTechnology mappings
            CreateMap<UpdateTechnologyDto, Technology>().ReverseMap();
            CreateMap<UpdateTechnologyCommand, Technology>().ReverseMap();

            //DeleteTechnology mappings
            CreateMap<DeleteTechnologyDto, Technology>().ReverseMap();
            CreateMap<DeleteTechnologyCommand, Technology>().ReverseMap();
        }
    }
}
