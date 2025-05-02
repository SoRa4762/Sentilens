using api.Application.Commands.UserCommands;
using api.Application.Responses;
using api.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Mappers.UserMapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<User, RegisterUserCommand>().ReverseMap();
            CreateMap<User, LoginUserCommand>().ReverseMap();

            // Update User - Later
            //CreateMap<UpdateUserCommand, User>()
            //    .ForMember(dest => dest.Id, opt => opt.Ignore())
            //    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
            //    srcMember != null
            //    ));
        }
    }
}
