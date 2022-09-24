using BookSystem.Model;
using System.Data;

namespace BookSystem.DAL
{
    public interface IBookDB
    {
        int AddBook(BookInfo book);
        DataTable GetBooks();
        DataTable GetBook(int bookId);
        DataTable SearchBooks(string searchKey);
        int UpdateBookBorrower(BookInfo book);
        int UpdateAverageRating(BookInfo book);
    }
}