using api.Application.Commands.FeedSourceCommands;
using api.Application.Commands.TopicCommands;
using api.Application.Responses;
using api.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Mappers.TopicMapper
{
    public class TopicMappingProfile : Profile
    {
        public TopicMappingProfile()
        {
            CreateMap<Topic, TopicResponse>().ReverseMap();
            CreateMap<Topic, CreateTopicCommand>().ReverseMap();
            CreateMap<UpdateTopicCommand, Topic>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                srcMember != null
                ));
        }
    }
}
