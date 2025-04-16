using api.Application.Commands;
using api.Application.Responses;
using api.Core.Entities;
using api.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Handlers
{
    public class CreateCommandHandler : IRequest<CreateArticleCommand, ArticleResponse>
    {
        private protected readonly IArticleRepository _articleRepository;
        public CreateCommandHandler(IArticleRepository articleRepository)
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
