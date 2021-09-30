using ApiBlog.Dtos;
using AutoMapper;
using Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBlog.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Roles, RolesResponseDto>()
                .ForMember(x => x.Nombre, y => y.MapFrom(z => z.Rol));

            CreateMap<RolesAddDto, Roles>();
            CreateMap<RolesUpdateDto, Roles>();
        }
    }
}
