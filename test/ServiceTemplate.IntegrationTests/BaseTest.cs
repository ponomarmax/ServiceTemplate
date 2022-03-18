using System.Net.Http;
using Xunit;

namespace ServiceTemplate.IntegrationTests
{
    [Collection("Sequential")]
    public class BaseTest : IClassFixture<SUTFactory>
    {
        protected readonly HttpClient _sutApi;
        private SUTFactory _factory;

        public BaseTest(SUTFactory factory)
        {
            _factory = factory;
            _sutApi = _factory.WithWebHostBuilder(builder => { }).CreateClient();
        }
    }
}
