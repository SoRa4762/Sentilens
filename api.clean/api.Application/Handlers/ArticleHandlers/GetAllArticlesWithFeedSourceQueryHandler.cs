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
    public class GetAllArticlesWithFeedSourceQueryHandler : IRequestHandler<GetAllArticlesWithFeedSourceQuery, IReadOnlyList<ArticleResponse>>
    {
        private protected readonly IArticleRepository _articleRepository;
        public GetAllArticlesWithFeedSourceQueryHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public async Task<IReadOnlyList<ArticleResponse>> Handle(GetAllArticlesWithFeedSourceQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var articlesFeedSource = await _articleRepository.GetAllArticlesWithFeedSource();
                return ArticleMapper.Mapper.Map<IReadOnlyList<ArticleResponse>>(articlesFeedSource);
            } catch (Exception ex)
            {
                throw new Exception("Error while getting all articles with feed source", ex);
            }
        }
    }
}
