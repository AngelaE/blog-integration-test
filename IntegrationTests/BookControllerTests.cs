using FluentAssertions;
using IntegrationTests.Clients;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace BookApi.IntegrationTests
{
    public class BookControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public BookControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_Books_returns_empty_list()
        {
            var client = _factory.CreateClient();
            var bookApiClient = new BookApiClient(client, false);

            // Act
            var books = await bookApiClient.Books.GetAsync();

            // Assert
            books.Should().NotBeNull();
            books.Count.Should().Be(0);
        }
    }
}
