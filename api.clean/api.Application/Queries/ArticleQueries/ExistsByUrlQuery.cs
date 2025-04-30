using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Queries.ArticleQueries
{
    public class ExistsByUrlQuery : IRequest<bool>
    {
        public string Url { get; }
        public ExistsByUrlQuery(string url)
        {
            Url = url;
        }
    }
}
