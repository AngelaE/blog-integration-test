using BookApi.Store;
using FluentAssertions;
using IntegrationTests;
using IntegrationTests.Clients;
using IntegrationTests.Clients.Models;
using Microsoft.Rest;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using Xunit;
using Xunit.Abstractions;
using Type = IntegrationTests.Clients.Models.Type;

namespace BookApi.IntegrationTests
{
    public class BookControllerWireMockTests : IClassFixture<DefaultTestWebApplicationFactory<Startup>>
    {
        private readonly DefaultTestWebApplicationFactory<Startup> _factory;
        private ITestOutputHelper _outputHelper;

        public BookControllerWireMockTests(DefaultTestWebApplicationFactory<Startup> factory, ITestOutputHelper outputHelper)
        {
            _factory = factory;
            _outputHelper = outputHelper;
            _factory.TestOutputHelper = outputHelper;
        }

        [Fact]
        public async Task Get_Books_returns_Book_Without_Stats()
        {
            var client = _factory.CreateClient();
            var bookApiClient = new BookApiClient(client, false);
            var createdBook = await AddBook();
            _factory.BookStats.Reset();

            // Act
            var book = await bookApiClient.Books.GetAsync(createdBook.Id);

            // Assert
            book.Should().NotBeNull();
            book.CopiesSold.Should().BeNull();
        }

        [Fact]
        public async Task Get_Books_returns_Book_With_Stats_if_wiremock_is_started()
        {
            var client = _factory.CreateClient();
            var bookApiClient = new BookApiClient(client, false);
            var createdBook = await AddBook();
            _factory.BookStats.Reset();
            _factory.BookStats.Given(
                Request.Create().WithPath("/bookstat/1").UsingGet())
              .RespondWith(
                Response.Create()
                .WithBodyAsJson(new BookStats.Autorest.Models.BookStatsModel { BookId = 1, CopiesSold = 99 })
                .WithStatusCode(200));

            // Act
            var book = await bookApiClient.Books.GetAsync(createdBook.Id);

            // Assert
            book.Should().NotBeNull();
            book.CopiesSold.Should().NotBeNull();
            book.CopiesSold.Value.Should().Be(99);
        }

        private async Task<BookApi.Models.Book> AddBook()
        {
            var bookStore = _factory.Services.GetService(typeof(IBookStore)) as IBookStore;
            var book = new BookApi.Models.Book
            {
                Id = 1,
                Title = "my new book",
                Author = "a great author",
                Summary = "my summary is short",
                Type = BookApi.Models.Type.eBook,
            };

            await bookStore.AddBook(book);
            return book;
        }
    }
}
