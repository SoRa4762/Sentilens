using api.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Queries.ArticleQueries
{
    public class DeleteArticleByIdQuery : IRequest<ArticleResponse>
    {
        public int ArticleId { get; set; }
        public DeleteArticleByIdQuery(int articleId)
        {
            ArticleId = articleId;
        }
    }
}
