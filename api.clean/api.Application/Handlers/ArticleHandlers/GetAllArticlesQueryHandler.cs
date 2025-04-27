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
    public class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, IReadOnlyList<ArticleResponse>>
    {
        private readonly IArticleRepository _articleRepo;
        public GetAllArticlesQueryHandler(IArticleRepository articleRepo)
        {
            _articleRepo = articleRepo;
        }

        public async Task<IReadOnlyList<ArticleResponse>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {
            var articleLists = await _articleRepo.GetAllAsync();
            var mappedArticleLists = ArticleMapper.Mapper.Map<IReadOnlyList<ArticleResponse>>(articleLists);
            return mappedArticleLists;
        }
    }
}
