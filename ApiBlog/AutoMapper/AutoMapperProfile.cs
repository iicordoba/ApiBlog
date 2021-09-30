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

            CreateMap<Users, UsersResponseDto>();

            CreateMap<UsersAddDto, Users>()
                .ForMember(x => x.Rol, y => y.Ignore());

            CreateMap<UsersUpdateDto, Users>()
                .ForMember(x => x.Rol, y => y.Ignore());

            CreateMap<Comments, CommentsResponseDto>();

            CreateMap<CommentsAddDto, Comments>()
                .ForMember(x => x.Post, y => y.Ignore());
        }
    }
}
