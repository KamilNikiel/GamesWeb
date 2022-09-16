using AutoMapper;
using GamesWeb.Dtos;
using GamesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamesWeb.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<IdentityModels, IdentityModelsDto>();
            Mapper.CreateMap<Game, GameDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<Order, OrderDto>();


            // Dto to Domain
            Mapper.CreateMap<IdentityModelsDto, IdentityModels>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<GameDto, Game>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}