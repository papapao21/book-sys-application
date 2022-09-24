using BookSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem.DAL
{
    public class ReviewDB : IReviewDB
    {
        public int AddReview(ReviewInfo review)
        {
            const string query = "INSERT INTO Review(BookId, Review, Rating, ReviewBy) VALUES (@bookid, @review, @rating, @reviewby)";

            var args = new Dictionary<string, object>
            {
                {"@bookid", review.BookId},
                {"@review", review.Review},
                {"@rating", review.Rating},
                {"@reviewby", review.ReviewBy}
            };

            return SQLite.ExecuteWrite(query, args);
        }

        public DataTable GetReviews(int bookId)
        {
            const string query = "SELECT * FROM Review WHERE BookId = @bookid";

            var args = new Dictionary<string, object>
            {
                {"@bookid", bookId}
            };

            return SQLite.ExecuteRead(query, args);
        }

        public DataTable GetReviewsByBookId(ReviewInfo review)
        {
            const string query = "SELECT * FROM Review WHERE BookId = @bookid";

            var args = new Dictionary<string, object>
            {
                {"@bookid", review.BookId}
            };

            return SQLite.ExecuteRead(query, args);
        }
    }
}
