using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Northwind.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseApiController : Controller
    {
        readonly ILogger _logger;

        public BaseApiController(ILogger logger)
        {
            _logger = logger;
        }

        public ILogger Logger => _logger;
    }
}
