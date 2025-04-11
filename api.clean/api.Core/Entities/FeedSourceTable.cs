using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Core.Entities
{
    public class FeedSourceTable : Entity
    {
        public int FeedSourceId { get; set; }
        public int TopicId { get; set; }
    }
}
