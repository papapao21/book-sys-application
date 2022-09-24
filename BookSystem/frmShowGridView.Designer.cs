
namespace BookSystem
{
    partial class frmShowGridView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvShowInfo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvShowInfo
            // 
            this.dgvShowInfo.AllowUserToAddRows = false;
            this.dgvShowInfo.AllowUserToDeleteRows = false;
            this.dgvShowInfo.AllowUserToResizeRows = false;
            this.dgvShowInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShowInfo.Location = new System.Drawing.Point(6, 6);
            this.dgvShowInfo.Name = "dgvShowInfo";
            this.dgvShowInfo.RowTemplate.Height = 25;
            this.dgvShowInfo.Size = new System.Drawing.Size(621, 438);
            this.dgvShowInfo.TabIndex = 0;
            // 
            // frmShowGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 450);
            this.Controls.Add(this.dgvShowInfo);
            this.Name = "frmShowGridView";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Text = "frmShowGridView";
            this.Load += new System.EventHandler(this.frmShowGridView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShowInfo;
    }
}