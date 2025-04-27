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
    public class DeleteArticleByIdHandler : IRequestHandler<DeleteArticleByIdQuery, ArticleResponse>
    {
        public IArticleRepository _articleRepository;
        public DeleteArticleByIdHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<ArticleResponse> Handle(DeleteArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var articleEntity = await _articleRepository.GetByIdAsync(request.ArticleId);
            if (articleEntity == null) return null;

            var deleteArticle = await _articleRepository.Delete(articleEntity);
            var mappedArticle = ArticleMapper.Mapper.Map<ArticleResponse>(deleteArticle);
            return mappedArticle;
        }
    }
}
