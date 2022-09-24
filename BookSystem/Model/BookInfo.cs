using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem.Model
{
    public class BookInfo
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string AverageRating { get; set; }
        public string CurrentBorrower { get; set; }
    }
}
