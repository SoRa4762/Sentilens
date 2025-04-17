using api.Application.Mappers;
using api.Application.Queries;
using api.Application.Responses;
using api.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Handlers
{
    public class GetAllByFeedSourceIdHandler : IRequestHandler<GetAllByFeedSourceIdQuery, IReadOnlyList<ArticleResponse>>
    {
        private protected readonly IArticleRepository _articleRepository;
        public GetAllByFeedSourceIdHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        //CQRS (Command Query Responsibility Segregation) pattern
        public async Task<IReadOnlyList<ArticleResponse>> Handle(GetAllByFeedSourceIdQuery request, CancellationToken cancellationToken)
        {
            var articleList = await _articleRepository.GetAllByFeedSourceIdAsync(request.FeedSourceId);
            var mappedArticleList = ArticleMapper.Mapper.Map<IReadOnlyList<ArticleResponse>>(articleList);
            return mappedArticleList;
        }
    }
}
