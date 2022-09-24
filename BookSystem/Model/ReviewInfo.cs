using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSystem.Model
{
    public class ReviewInfo
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
        public string ReviewBy { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
