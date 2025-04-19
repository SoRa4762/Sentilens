using api.Api.Controllers.Base; // without inheriting this class, the controller won't be recognized as a controller, you also get the error: non-invokable member Ok called as a method
using api.Application.Queries;
using api.Application.Responses;
using api.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace api.Api.Controllers
{
    public class ArticleController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IArticleRepository _articleRepo;
        public ArticleController(IMediator mediator, IArticleRepository articleRepo)
        {
            _mediator = mediator;
            _articleRepo = articleRepo;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)] // if you added this too, you will get two data displayed: 1. for the 200OK, 2. for the 404NotFound
        public async Task<ActionResult<IReadOnlyList<ArticleResponse>>> GetAllAsync()
        {
            /*  
             *  I don't have a query for this... should I create one?
             *  cuz even without one I can still work like this
             */
            var articles = await _articleRepo.GetAllAsync();
            return Ok(articles);
        }

        [HttpGet("{feedSourceId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        // IActionResult cannot be used with a type arguments
        public async Task<ActionResult<IReadOnlyList<ArticleResponse>>> GetAllByFeedSourceIdAsync(int feedSourceId)
        {
            var query = new GetAllByFeedSourceIdQuery(feedSourceId);
            var articles = await _mediator.Send(query);
            return Ok(articles);
        }


    }
}
