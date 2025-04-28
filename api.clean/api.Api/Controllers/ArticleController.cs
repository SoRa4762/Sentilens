using api.Api.Controllers.Base; // without inheriting this class, the controller won't be recognized as a controller, you also get the error: non-invokable member Ok called as a method
using api.Application.Commands.ArticleCommands;
using api.Application.Mappers.ArticleMappers;
using api.Application.Queries.ArticleQueries;
using api.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace api.Api.Controllers
{
    public class ArticleController : ApiController
    {
        private readonly IMediator _mediator;
        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // if you added this too, you will get two data displayed: 1. for the 200OK, 2. for the 404NotFound
        public async Task<ActionResult<IReadOnlyList<ArticleResponse>>> GetAllAsync()
        {
            /*  
             *  I don't have a query for this... should I create one?
             *  April 20: query for what actually?
             *  April 22: query from MediatR it seems like
             *  cuz even without one I can still work like this
             */

            /*
             * you could do this as well, but why do it even eh ?
             * let's just follow CQRS eh?
             * var articles = await _articleRepo.GetAllAsync();
             * return Ok(articles);
             */

            var query = new GetAllArticlesQuery();
            var articles = await _mediator.Send(query);
            return Ok(articles);
        }

        [HttpGet("{feedSourceId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // IActionResult cannot be used with a type arguments
        public async Task<ActionResult<IReadOnlyList<ArticleResponse>>> GetAllByFeedSourceIdAsync(int feedSourceId)
        {
            var query = new GetAllByFeedSourceIdQuery(feedSourceId);
            var articles = await _mediator.Send(query);
            return Ok(articles);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ArticleResponse>> CreateArticleAsync([FromBody] CreateArticleCommand command)
        {
            Console.WriteLine($"FeedSourceId: {command.FeedSourceId}");
            var article = await _mediator.Send(command);
            //return CreatedAtAction(nameof(GetAllByFeedSourceIdAsync), new { feedSourceId = article.FeedSourceId }, article);
            return Ok(article);
        }

        [HttpDelete("{articleId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ArticleResponse>> DeleteArticleById(int articleId)
        {
            // remember to create query before you send it to mediator mate... damn
            var query = new DeleteArticleByIdQuery(articleId);
            var articleDto = await _mediator.Send(query);
            if (articleDto == null) return NotFound("Article Not Found!");
            return Ok(articleDto);
        }

        [HttpPut("{articleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ArticleResponse>> UpdateArticleAsync(int articleId, [FromBody] UpdateArticleCommand command)
        {
            var article = await _mediator.Send(command);
            return Ok(article);
        }

    }
}
