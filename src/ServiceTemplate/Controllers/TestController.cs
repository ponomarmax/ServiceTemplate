using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Oneview.Inpatient.Logging.ApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {

        private readonly ILogger _logger;

        public TestController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.Information("It workds");
            return Ok();
        }
    }
}
