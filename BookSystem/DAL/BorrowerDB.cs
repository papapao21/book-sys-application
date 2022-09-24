using BookSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem.DAL
{
    public class BorrowerDB : IBorrowerDB
    {
        public int AddBorrower(BookInfo review)
        {
            const string query = "INSERT INTO Borrower(BookId, Borrower) VALUES (@bookid, @borrower)";

            var args = new Dictionary<string, object>
            {
                {"@bookid", review.BookId},
                {"@borrower", review.CurrentBorrower}
            };

            return SQLite.ExecuteWrite(query, args);
        }

        public DataTable GetBorrower(int bookId)
        {
            const string query = "SELECT * FROM Borrower WHERE BookId = @bookId";

            var args = new Dictionary<string, object>
            {
                {"@bookId", bookId}
            };

            return SQLite.ExecuteRead(query, args);
        }
    }
}
