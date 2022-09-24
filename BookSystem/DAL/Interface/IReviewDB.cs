using BookSystem.Model;
using System.Data;

namespace BookSystem.DAL
{
    public interface IReviewDB
    {
        int AddReview(ReviewInfo review);
        DataTable GetReviews(int bookId);
        DataTable GetReviewsByBookId(ReviewInfo review);
    }
}