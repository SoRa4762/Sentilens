using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace api.Api.Controllers.Base
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")] // don't add spaces between "version:apiVersion"
    [ApiController]
    public class ApiController : ControllerBase
    {

    }
}
