using BookSystem.BLL;
using BookSystem.Enum;
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
    public partial class frmBookSystem : Form
    {
        private BookController BookController = new();
        private ReviewController ReviewController = new();

        private DataGridView.HitTestInfo hitTestInfo;
        private BindingList<BookInfo> Books;

        public frmBookSystem()
        {
            InitializeComponent();
            InitializeBook();

            //CreateDB.GenerateDB();
            //CreateDB.DropReview();
            //CreateDB.CreateReview();
        }

        private void InitializeBook()
        {
            Books = new BindingList<BookInfo>(BookController.GetAll());

            dgvBooks.DataSource = Books;
            dgvBooks.Columns[1].HeaderText = "Title";
            dgvBooks.Columns[2].HeaderText = "Author";
            dgvBooks.Columns[3].HeaderText = "Average Rating";
            dgvBooks.Columns[4].HeaderText = "Current Borrower";

            dgvBooks.Columns[0].Visible = false;
            dgvBooks.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvBooks.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvBooks.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvBooks.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            cbxSortBy.Items.AddRange(new string[] { dgvBooks.Columns[1].HeaderText, dgvBooks.Columns[2].HeaderText, dgvBooks.Columns[3].HeaderText});
            //cbxSortBy.SelectedIndex = 0;
            cbxSortDirection.Items.AddRange(new string[] { "ASC", "DESC" });
            cbxSortDirection.SelectedIndex = 0;
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            frmAddBook frm = new();
            frm.OnAddBookEvent += Frm_OnAddBookEvent;
            frm.ShowDialog();
        }

        private void Frm_OnAddBookEvent(object sender, BookInfo bookInfo)
        {
            BookController.Add(bookInfo);
            Books.Add(bookInfo);
        }

        private void dgvBooks_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                hitTestInfo = dgvBooks.HitTest(e.X, e.Y);
                dgvBooks.ClearSelection();
                dgvBooks.Rows[hitTestInfo.RowIndex].Selected = true;

                bool isBorrowed = !string.IsNullOrWhiteSpace(dgvBooks.Rows[hitTestInfo.RowIndex].Cells[4].Value.ToString());

                ContextMenuStrip menuStrip = new();

                if (!isBorrowed) menuStrip.Items.Add("Check Out", null, OnCheckOut_Click);
                else menuStrip.Items.Add("Return", null, OnReturn_Click);
                menuStrip.Items.Add("Leave Review", null, OnLeaveReview_Click);
                menuStrip.Items.Add("Show All Reviews", null, OnShowAllReviews_Click);
                menuStrip.Items.Add("Show Borrowing History", null, OnShowBorrowingHistory_Click);

                menuStrip.Show(dgvBooks, new Point(e.X, e.Y));
            }
        }

        private void OnShowBorrowingHistory_Click(object sender, EventArgs e)
        {
            string bookId = dgvBooks.Rows[hitTestInfo.RowIndex].Cells[0].Value.ToString();
            string bookTitle = dgvBooks.Rows[hitTestInfo.RowIndex].Cells[1].Value.ToString();

            frmShowGridView frm = new(bookTitle, ShowInfoType.Borrower);
            frm.SourceBorrower = new BindingList<BorrowerInfo>(BookController.GetBorrowers(bookId));
            frm.ShowDialog();
        }

        private void OnShowAllReviews_Click(object sender, EventArgs e)
        {
            string bookId = dgvBooks.Rows[hitTestInfo.RowIndex].Cells[0].Value.ToString();
            string bookTitle = dgvBooks.Rows[hitTestInfo.RowIndex].Cells[1].Value.ToString();

            frmShowGridView frm = new(bookTitle, ShowInfoType.Review);
            frm.SourceReview = new BindingList<ReviewInfo>(ReviewController.GetReviewByBookId(bookId));
            frm.ShowDialog();
        }

        private void OnLeaveReview_Click(object sender, EventArgs e)
        {
            string bookId = dgvBooks.Rows[hitTestInfo.RowIndex].Cells[0].Value.ToString();
            frmLeaveReview frm = new(bookId);
            frm.OnPostReviewEvent += Frm_OnPostReviewEvent;
            frm.ShowDialog();
        }

        private void Frm_OnPostReviewEvent(object obj, ReviewInfo reviewArgs)
        {
            Books[hitTestInfo.RowIndex].AverageRating = ReviewController.Add(reviewArgs);
            dgvBooks.Refresh();
        }

        private void OnReturn_Click(object sesnder, EventArgs e)
        {
            string bookId = dgvBooks.Rows[hitTestInfo.RowIndex].Cells[0].Value.ToString();
            BookController.Return(bookId);
            Books[hitTestInfo.RowIndex].CurrentBorrower = string.Empty;

            dgvBooks.Refresh();
        }

        private void OnCheckOut_Click(object sender, EventArgs e)
        {
            string bookId = dgvBooks.Rows[hitTestInfo.RowIndex].Cells[0].Value.ToString();
            BookController.CheckOut(bookId);
            Books[hitTestInfo.RowIndex].CurrentBorrower = Environment.UserName;
           
            dgvBooks.Refresh();
        }

        private void cbxSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortBooks();
        }

        private void cbxSortDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortBooks();
        }

        private void SortBooks()
        {
            if (cbxSortBy.SelectedIndex != -1 && cbxSortDirection.SelectedIndex != -1)
            {
                BindingList<BookInfo> SortedBooks = null;

                switch (cbxSortBy.SelectedIndex)
                {
                    case 0:
                        if (cbxSortDirection.SelectedIndex == 0)
                            SortedBooks = new BindingList<BookInfo>(Books.OrderBy(x => x.Title).ToList());
                        else
                            SortedBooks = new BindingList<BookInfo>(Books.OrderByDescending(x => x.Title).ToList());
                        break;
                    case 1:
                        if (cbxSortDirection.SelectedIndex == 0)
                            SortedBooks = new BindingList<BookInfo>(Books.OrderBy(x => x.Author).ToList());
                        else
                            SortedBooks = new BindingList<BookInfo>(Books.OrderByDescending(x => x.Author).ToList());
                        break;
                    case 2:
                        if (cbxSortDirection.SelectedIndex == 0)
                            SortedBooks = new BindingList<BookInfo>(Books.OrderBy(x => x.AverageRating).ToList());
                        else
                            SortedBooks = new BindingList<BookInfo>(Books.OrderByDescending(x => x.AverageRating).ToList());
                        break;
                    default:
                        break;
                }

                Books = new BindingList<BookInfo>(SortedBooks);
                dgvBooks.DataSource = Books;
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!string.IsNullOrWhiteSpace(txtSearch.Text.Trim()))
                    Books = new BindingList<BookInfo>(BookController.Search(txtSearch.Text.Trim()));
                else
                    Books = new BindingList<BookInfo>(BookController.GetAll());

                dgvBooks.DataSource = Books;
            }
        }
    }
}
