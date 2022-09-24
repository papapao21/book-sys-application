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
    public class ReviewController
    {
        private IReviewDB Review;
        private IBookDB Book;

        public ReviewController()
        {
            Review = new ReviewDB();
            Book = new BookDB();
        }

        public string Add(ReviewInfo reviewInfo)
        {
            Review.AddReview(reviewInfo);

            BookInfo bookInfo = new()
            {
                BookId = reviewInfo.BookId,
                AverageRating = $"{GetAverageRating(reviewInfo):0.0} out of 5"
            };

            Book.UpdateAverageRating(bookInfo);

            return bookInfo.AverageRating;
        }

        public List<ReviewInfo> GetReviewByBookId(string bookId)
        {
            List<ReviewInfo> reviews = new();

            DataTable dt = Review.GetReviews(Convert.ToInt32(bookId));

            reviews = (from DataRow row in dt.Rows
                         select new ReviewInfo
                         {
                             Id = Convert.ToInt32(row["ID"]),
                             BookId = Convert.ToInt32(row["BookID"]),
                             Review = row["Review"].ToString(),
                             Rating = Convert.ToInt32(row["Rating"].ToString()),
                             ReviewBy = row["ReviewBy"].ToString(),
                             ReviewDate = DateTime.Parse(row["ReviewDate"].ToString())
                         }).ToList();

            return reviews;
        }

        public double GetAverageRating(ReviewInfo reviewInfo)
        {
            List<int> reviewsRating = new();

            DataTable dt = Review.GetReviewsByBookId(reviewInfo);

            foreach (DataRow row in dt.Rows)
                reviewsRating.Add(Convert.ToInt32(row["Rating"].ToString()));

            return reviewsRating.Average();
        }
    }
}
