using api.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Queries.ArticleQueries
{
    // if your ArticleResponse does not have this <IReadOnlyList> Type to it you will get error when Implementing it in the handler
    public class GetAllArticlesQuery : IRequest<IReadOnlyList<ArticleResponse>>
    {
        /* This class is empty because we are using MediatR's IRequest interface
         * to define a query without any parameters.
         * Can add properties here if you need to pass parameters to the query.
         * For example, filters, pagination articles by a specific property,
         * such properies can be added here.
         */
    }
}
