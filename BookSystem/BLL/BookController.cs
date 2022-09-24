using BookSystem.DAL;
using BookSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem.BLL
{
    public class BookController
    {
        private IBookDB Book;
        private IBorrowerDB Borrower;

        public BookController()
        {
            Book = new BookDB();
            Borrower = new BorrowerDB();
        }

        public int Add(BookInfo book)
        {
            return Book.AddBook(book);
        }

        public List<BookInfo> GetAll()
        {
            List<BookInfo> books = new();

            DataTable dt = Book.GetBooks();

            books = (from DataRow row in dt.Rows
                       select new BookInfo
                       {
                           BookId = Convert.ToInt32(row["BookID"]),
                           Title = row["Title"].ToString(),
                           Author = row["Author"].ToString(),
                           AverageRating = row["AverageRating"].ToString(),
                           CurrentBorrower = row["CurrentBorrower"].ToString()
                       }).ToList();

            return books;
        }

        public List<BorrowerInfo> GetBorrowers(string bookId)
        {
            List<BorrowerInfo> borrowers = new();

            DataTable dt = Borrower.GetBorrower(Convert.ToInt32(bookId));

            borrowers = (from DataRow row in dt.Rows
                         select new BorrowerInfo
                         {
                             Borrower = row["Borrower"].ToString(),
                             BorrowDate = DateTime.Parse(row["BorrowDate"].ToString())
                         }).ToList();

            return borrowers;
        }

        public List<BookInfo> GetBook(string bookId)
        {
            List<BookInfo> books = new();

            DataTable dt = Book.GetBook(Convert.ToInt32(bookId));

            books = (from DataRow row in dt.Rows
                     select new BookInfo
                     {
                         BookId = Convert.ToInt32(row["BookID"]),
                         Title = row["Title"].ToString(),
                         Author = row["Author"].ToString(),
                         AverageRating = row["AverageRating"].ToString(),
                         CurrentBorrower = row["CurrentBorrower"].ToString()
                     }).ToList();

            return books;
        }

        public List<BookInfo> Search(string searchKey)
        {
            List<BookInfo> books = new();

            DataTable dt = Book.SearchBooks(searchKey);

            books = (from DataRow row in dt.Rows
                     select new BookInfo
                     {
                         BookId = Convert.ToInt32(row["BookID"]),
                         Title = row["Title"].ToString(),
                         Author = row["Author"].ToString(),
                         AverageRating = row["AverageRating"].ToString(),
                         CurrentBorrower = row["CurrentBorrower"].ToString()
                     }).ToList();

            return books;
        }

        public int CheckOut(string bookId)
        {
            BookInfo bookInfo = new()
            {
                BookId = Convert.ToInt32(bookId),
                CurrentBorrower = Environment.UserName
            };

            Borrower.AddBorrower(bookInfo);

            return Book.UpdateBookBorrower(bookInfo);
        }

        public int Return(string bookId)
        {
            BookInfo bookInfo = new()
            {
                BookId = Convert.ToInt32(bookId),
                CurrentBorrower = string.Empty
            };

            return Book.UpdateBookBorrower(bookInfo);
        }
    }
}
