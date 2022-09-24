using BookSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem.DAL
{
    public class BookDB : IBookDB
    {

        public int AddBook(BookInfo book)
        {
            const string query = "INSERT INTO Book(Title, Author) VALUES (@title, @author)";

            var args = new Dictionary<string, object>
            {
                {"@title", book.Title},
                {"@author", book.Author}
            };

            return SQLite.ExecuteWrite(query, args);
        }

        public DataTable GetBooks()
        {
            const string query = "SELECT * FROM Book";

            return SQLite.ExecuteRead(query);
        }

        public DataTable GetBook(int bookId)
        {
            const string query = "SELECT * FROM Book WHERE BookId = @bookid";

            var args = new Dictionary<string, object>
            {
                {"@bookid", bookId}
            };

            return SQLite.ExecuteRead(query, args);
        }

        public DataTable SearchBooks(string searchKey)
        {
            const string query = "SELECT * FROM Book WHERE Title LIKE @searchKey OR Author LIKE @searchKey";

            var args = new Dictionary<string, object>
            {
                {"@searchKey", $"%{searchKey}%"}
            };

            return SQLite.ExecuteRead(query, args);
        }

        public int UpdateBookBorrower(BookInfo book)
        {
            const string query = "UPDATE Book SET CurrentBorrower = @currentborrower WHERE BookID = @bookid";

            var args = new Dictionary<string, object>
            {
                {"@bookid", book.BookId},
                {"@currentborrower", book.CurrentBorrower}
            };

            return SQLite.ExecuteWrite(query, args);
        }

        public int UpdateAverageRating(BookInfo book)
        {
            const string query = "UPDATE Book SET AverageRating = @averagerating WHERE BookID = @bookid";

            var args = new Dictionary<string, object>
            {
                {"@bookid", book.BookId},
                {"@averagerating", book.AverageRating}
            };

            return SQLite.ExecuteWrite(query, args);
        }

    }
}
