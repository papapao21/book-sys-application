using BookSystem.Model;
using System.Data;

namespace BookSystem.DAL
{
    public interface IBorrowerDB
    {
        int AddBorrower(BookInfo review);
        DataTable GetBorrower(int bookId);
    }
}