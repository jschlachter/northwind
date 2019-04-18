using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Northwind.Web.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        readonly ILogger _logger;

        public BaseApiController(ILogger logger)
        {
            _logger = logger;
        }

        public ILogger Logger => _logger;
    }
}
