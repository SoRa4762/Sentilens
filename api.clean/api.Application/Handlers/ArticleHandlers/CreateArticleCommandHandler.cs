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
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
            Console.WriteLine($"ForeignKey FeedSource ID: {request.FeedSourceId}");
            if(articleEntity == null)
            {
                throw new ApplicationException("Mapping failed");
            }

            // You should not get errors mate - add DbException on the repository level
            try
            {
                var newArticle = await _articleRepository.AddAsync(articleEntity);
                var articleResponse = ArticleMapper.Mapper.Map<ArticleResponse>(newArticle);
                return articleResponse;
            }
            catch (AutoMapperMappingException ex)
            {
                throw new ApplicationException("An error occurred while mapping the article response.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred.", ex);
            }

        }

    }
}
