using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Mappers
{
    public class ArticleMapper
    {
        // Lazy initialization so the mapper is created only once (thread-safe)
        public static readonly Lazy<IMapper> Lazy = new(() =>
        {
            // 1st: Configure AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                // Rule: Map properties if their getters are public or internal
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                // Add all mapping profiles
                cfg.AddProfile<ArticleMappingProfile>();
            });
            // 2nd: Create the mapper instance
            var mapper = config.CreateMapper();
            return mapper;
        });

        // Expose the mapper instance via static property
        public static IMapper Mapper => Lazy.Value;
    }
}
