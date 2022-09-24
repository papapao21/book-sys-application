using BookSystem.BLL;
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
    public partial class frmAddBook : Form
    {
        public delegate void AddBookHandler(object obj, BookInfo bookArgs);
        public event AddBookHandler OnAddBookEvent;

        public frmAddBook()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTitle.Text) && !string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                BookInfo bookInfo = new()
                {
                    Title = txtTitle.Text.Trim(),
                    Author = txtAuthor.Text.Trim()
                };

                OnAddBookEvent(this, bookInfo);
                this.Close();
            }
            else
                MessageBox.Show("Please fill-out all fields!");
        }
    }
}
