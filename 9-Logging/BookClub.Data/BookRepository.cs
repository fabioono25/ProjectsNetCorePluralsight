using System.Collections.Generic;
using System.Data;
using System.Linq;
using BookClub.Entities;
using Dapper;
using Microsoft.Extensions.Logging;

namespace BookClub.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbConnection _db;
        //private readonly ILogger<BookRepository> _logger;
        private readonly ILogger _logger;

        public BookRepository(IDbConnection db, ILoggerFactory logger)
        {
            _db = db;
            _logger = logger.CreateLogger("Database");
        }

        public List<Book> GetAllBooks()
        {
            _logger.LogInformation("Inside the repository about to call GetAllBooks.");
            _logger.LogDebug(DataEvents.GetMany, "Debugging info for stored proc {ProcName}", "GetAllBooks");
            var books = _db.Query<Book>("GetAllBooks", commandType: CommandType.StoredProcedure)
                .ToList();
            return books;
        }

        public void SubmitNewBook(Book bookToSubmit, int submitter)
        {
            _db.Execute("InsertBook", new {
                bookToSubmit.Title,
                bookToSubmit.Author,
                Classification = bookToSubmit.Category,
                bookToSubmit.Genre,
                bookToSubmit.Isbn,
                submitter
            }, commandType: CommandType.StoredProcedure);
        }
    }
}
