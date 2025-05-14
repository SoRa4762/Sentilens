using api.Core.Entities;
using api.Core.Interfaces;
using api.Infrastructure.Data;
using api.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Infrastructure.Repositories
{
    public class TopicRepository : Repository<Topic>, ITopicRepository
    {
        public TopicRepository(AppDbContext context) : base(context)
        {
        }
    }
}
