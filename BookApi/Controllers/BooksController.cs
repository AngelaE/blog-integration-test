using BookApi.Models;
using BookApi.OpenApi;
using BookApi.Store;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes(contentType: ContentTypes.APPLICATION_JSON)]
    [Produces(contentType: ContentTypes.APPLICATION_JSON)]
    public class BooksController : ControllerBase
    {
        private IBookStore _bookStore;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookStore bookStore, ILogger<BooksController> logger)
        {
            _bookStore = bookStore;
            _logger = logger;
        }

        /// <summary>
        /// Get the list of all books
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _bookStore.GetBooks();
        }
    }
}
