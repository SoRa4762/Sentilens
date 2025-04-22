using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Mappers.FeedSourceMapper
{
    public static class FeedSourceMapper
    {
        public static IMapper Mapper => Lazy.Value;
        private static readonly Lazy<IMapper> Lazy = new(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FeedSourceMappingProfile>();
            });
            return config.CreateMapper();
        });
    }
}
