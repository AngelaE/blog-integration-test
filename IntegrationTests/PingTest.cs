using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace BookApi.IntegrationTests
{
    public class PingTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public PingTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Ping_returns_success()
        {
            // this test proves that the service is up and running

            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/service/ping");

            // Assert
            response.EnsureSuccessStatusCode(); 
        }
    }
}
