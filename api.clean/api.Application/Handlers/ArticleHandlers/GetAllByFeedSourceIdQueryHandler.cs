using api.Application.Mappers.ArticleMappers;
using api.Application.Queries.ArticleQueries;
using api.Application.Responses;
using api.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Handlers.ArticleHandlers
{
    public class GetAllByFeedSourceIdQueryHandler : IRequestHandler<GetAllByFeedSourceIdQuery, IReadOnlyList<ArticleResponse>>
    {
        private protected readonly IArticleRepository _articleRepository;
        public GetAllByFeedSourceIdQueryHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        //CQRS (Command Query Responsibility Segregation) pattern
        public async Task<IReadOnlyList<ArticleResponse>> Handle(GetAllByFeedSourceIdQuery request, CancellationToken cancellationToken)
        {
            // TODO: add try catch in the repository directory
            var articleList = await _articleRepository.GetAllByFeedSourceIdAsync(request.FeedSourceId);
            var mappedArticleList = ArticleMapper.Mapper.Map<IReadOnlyList<ArticleResponse>>(articleList);
            return mappedArticleList;
        }
    }
}
