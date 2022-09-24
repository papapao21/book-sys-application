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
    public partial class frmShowGridView : Form
    {
        public BindingList<BorrowerInfo> SourceBorrower;
        public BindingList<ReviewInfo> SourceReview;

        private string BookTitle;
        private ShowInfoType InfoType;
        public frmShowGridView(string bookTitle, ShowInfoType infoType)
        {
            InitializeComponent();
            BookTitle = bookTitle;
            InfoType = infoType;
        }

        private void frmShowGridView_Load(object sender, EventArgs e)
        {
            switch (InfoType)
            {
                case ShowInfoType.Borrower:
                    this.Text = $"{BookTitle} Borrower History";
                    dgvShowInfo.DataSource = SourceBorrower;

                    dgvShowInfo.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvShowInfo.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvShowInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    break;
                case ShowInfoType.Review:
                    this.Text = $"{BookTitle} Reviews";
                    dgvShowInfo.DataSource = SourceReview;

                    dgvShowInfo.Columns[0].Visible = false;
                    dgvShowInfo.Columns[1].Visible = false;
                    dgvShowInfo.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvShowInfo.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvShowInfo.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvShowInfo.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvShowInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    break;
                default:
                    break;
            }
        }
    }
}
