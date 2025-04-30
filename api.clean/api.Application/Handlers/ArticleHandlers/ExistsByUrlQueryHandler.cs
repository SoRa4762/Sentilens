using api.Application.Queries.ArticleQueries;
using api.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Handlers.ArticleHandlers
{
    public class ExistsByUrlQueryHandler : IRequestHandler<ExistsByUrlQuery, bool>
    {
        private readonly IArticleRepository _articleRepository;
        public ExistsByUrlQueryHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<bool> Handle(ExistsByUrlQuery request, CancellationToken cancellationToken)
        {
            var exists = await _articleRepository.ExistsByUrlAsync(request.Url);
            return exists;
        }
    }
}
