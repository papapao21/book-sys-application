using BookSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookSystem
{
    public partial class frmLeaveReview : Form
    {
        public delegate void PostReviewHandler(object obj, ReviewInfo reviewArgs);
        public event PostReviewHandler OnPostReviewEvent;

        private string BookID;

        public frmLeaveReview(string bookId)
        {
            InitializeComponent();
            BookID = bookId;
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtReview.Text))
            {
                ReviewInfo reviewInfo = new()
                {
                    BookId = Convert.ToInt32(BookID),
                    Review = txtReview.Text.Trim(),
                    Rating = Convert.ToInt32(nudAverageRating.Value),
                    ReviewBy = Environment.UserName
                };

                OnPostReviewEvent(this, reviewInfo);
                this.Close();
            }
            else
                MessageBox.Show("Please fill-out all fields!");
        }
    }
}
