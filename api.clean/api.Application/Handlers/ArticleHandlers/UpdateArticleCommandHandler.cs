using api.Application.Commands.ArticleCommands;
using api.Application.Mappers.ArticleMappers;
using api.Application.Responses;
using api.Core.Entities;
using api.Core.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Handlers.ArticleHandlers
{
    public  class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, ArticleResponse>
    {
        private protected readonly IArticleRepository _articleRepository;
        private protected readonly IMapper _mapper;
        public UpdateArticleCommandHandler(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<ArticleResponse> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            // check if article exists
            var existingArticle = await _articleRepository.GetByIdAsync(request.ArticleId);
            if(existingArticle == null)
            {
                throw new KeyNotFoundException($"Article with ID {request.ArticleId} not found.");
            }

            // map and turn request DTO to entity
            ArticleMapper.Mapper.Map(request, existingArticle);
            var updatedEntity = await _articleRepository.UpdateAsync(existingArticle);

            // turn Entity to Response DTO
            return ArticleMapper.Mapper.Map<ArticleResponse>(updatedEntity);
        }
    }
}
