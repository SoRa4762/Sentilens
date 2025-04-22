using api.Application.Responses;
using api.Core.Entities;
using api.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api.Application.Mappers.ArticleMappers;
using api.Application.Commands.ArticleCommands;

namespace api.Application.Handlers.ArticleHandlers
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, ArticleResponse>
    {
        private protected readonly IArticleRepository _articleRepository;
        public CreateArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<ArticleResponse> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var articleEntity = ArticleMapper.Mapper.Map<Article>(request);
            if(articleEntity == null)
            {
                throw new ApplicationException("Mapping failed");
            }

            var newArticle = await _articleRepository.AddAsync(articleEntity);
            var articleResponse = ArticleMapper.Mapper.Map<ArticleResponse>(newArticle);
            return articleResponse;
        }

    }
}
