using FluentAssertions;
using IntegrationTests;
using IntegrationTests.Clients;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace BookApi.IntegrationTests
{
    public class BookControllerTests : IClassFixture<DefaultTestWebApplicationFactory<Startup>>
    {
        private readonly DefaultTestWebApplicationFactory<Startup> _factory;

        public BookControllerTests(DefaultTestWebApplicationFactory<Startup> factory, ITestOutputHelper outputHelper)
        {
            _factory = factory;
            _factory.TestOutputHelper = outputHelper;
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
