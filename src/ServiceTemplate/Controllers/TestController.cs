using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ServiceTemplate.Data.Abstractions;

namespace Oneview.Inpatient.Logging.ApiDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly ITestRepository _testRepository;

        public TestController(ILogger logger, ITestRepository testRepository)
        {
            _logger = logger;
            _testRepository = testRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.Information("It works");
            var entities = await _testRepository.GetAll();
            return Ok(entities);
        }
    }
}
