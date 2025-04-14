using api.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Core.Entities
{
    public class FeedSourceTopic : Entity
    {
        // Composite Primary Key
        public int FeedSourceId { get; set; }
        public int TopicId { get; set; }

        // Navigation Properties (one to one)
        public FeedSource? FeedSource { get; set; }
        public Topic? Topic { get; set; }
    }
}
