using api.Application.Commands.FeedSourceCommands;
using api.Application.Responses;
using api.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Mappers.FeedSourceMapper
{
    public class FeedSourceMappingProfile : Profile
    {
        public FeedSourceMappingProfile()
        {
            CreateMap<FeedSource, FeedSourceResponse>().ReverseMap();
            CreateMap<FeedSource, CreateFeedSourceCommand>().ReverseMap();
        }
    }
}
