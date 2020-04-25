using Books.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Api.Controllers
{
    [Route("api/synchronousbooks")]
    [ApiController]
    public class SynchronousBooksController : ControllerBase
    {
        private IBooksRepository _booksRepository;

        public SynchronousBooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository ?? 
                throw new ArgumentNullException(nameof(booksRepository));
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            //            var bookEntities = _booksRepository.GetBooks();
            var bookEntities = _booksRepository.GetBooksAsync().Result; //blocking Async Code - not good

            //_booksRepository.GetBooksAsync().Wait(); -- blocking async code

            return Ok(bookEntities);
        }
    }
}
