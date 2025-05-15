using api.Application.Responses;
using api.Core.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Queries.UserTopicQueries
{
    public record GetUserTopicsByUserIdQuery(string userId) : IRequest<Result<IReadOnlyList<UserTopicResponse>>>;
}
