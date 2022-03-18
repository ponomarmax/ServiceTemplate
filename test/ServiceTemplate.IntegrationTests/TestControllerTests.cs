using System.Threading.Tasks;
using Xunit;

namespace ServiceTemplate.IntegrationTests
{
    public class TestControllerTests : BaseTest
    {
        public TestControllerTests(SUTFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task Given_Get_When_SimpleCall_Returns200()
        {
            // Arrange

            // Act
            var result = await _sutApi.GetAsync("test");

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, result.StatusCode);
        }
    }
}

