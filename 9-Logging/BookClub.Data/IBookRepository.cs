using BookClub.Entities;
using System.Collections.Generic;

namespace BookClub.Data
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        void SubmitNewBook(Book bookToSubmit, int submitter);
    }
}
