using api.Core.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Queries.UserTopicQueries
{
    public record DeleteUserTopicQuery(string userId, int topicId) : IRequest<Result<bool>>;
}
