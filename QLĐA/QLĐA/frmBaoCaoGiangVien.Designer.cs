namespace QLĐA
{
    partial class frmBaoCaoGiangVien
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
            this.pnTitile = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnFilter = new System.Windows.Forms.Panel();
            this.btnInBaoCao = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.chkAllGiangVien = new System.Windows.Forms.CheckBox();
            this.cboGiangVien = new System.Windows.Forms.ComboBox();
            this.lblGiangVien = new System.Windows.Forms.Label();
            this.pnResult = new System.Windows.Forms.Panel();
            this.dgvBaoCaoGV = new System.Windows.Forms.DataGridView();
            this.pnTitile.SuspendLayout();
            this.pnFilter.SuspendLayout();
            this.pnResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoGV)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTitile
            // 
            this.pnTitile.BackColor = System.Drawing.Color.SteelBlue;
            this.pnTitile.Controls.Add(this.lblTitle);
            this.pnTitile.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitile.Location = new System.Drawing.Point(0, 0);
            this.pnTitile.Name = "pnTitile";
            this.pnTitile.Size = new System.Drawing.Size(1031, 60);
            this.pnTitile.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(285, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Báo cáo đề tài theo giảng viên";
            // 
            // pnFilter
            // 
            this.pnFilter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFilter.Controls.Add(this.btnInBaoCao);
            this.pnFilter.Controls.Add(this.btnDong);
            this.pnFilter.Controls.Add(this.btnXemBaoCao);
            this.pnFilter.Controls.Add(this.chkAllGiangVien);
            this.pnFilter.Controls.Add(this.cboGiangVien);
            this.pnFilter.Controls.Add(this.lblGiangVien);
            this.pnFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnFilter.Location = new System.Drawing.Point(0, 60);
            this.pnFilter.Name = "pnFilter";
            this.pnFilter.Size = new System.Drawing.Size(1031, 120);
            this.pnFilter.TabIndex = 1;
            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao.Location = new System.Drawing.Point(729, 25);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.Size = new System.Drawing.Size(110, 30);
            this.btnInBaoCao.TabIndex = 11;
            this.btnInBaoCao.Text = "In Báo cáo";
            this.btnInBaoCao.UseVisualStyleBackColor = true;
            this.btnInBaoCao.Click += new System.EventHandler(this.btnInBaoCao_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(909, 73);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 30);
            this.btnDong.TabIndex = 10;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.Location = new System.Drawing.Point(548, 25);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(110, 30);
            this.btnXemBaoCao.TabIndex = 9;
            this.btnXemBaoCao.Text = "Xem báo cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = true;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // chkAllGiangVien
            // 
            this.chkAllGiangVien.AutoSize = true;
            this.chkAllGiangVien.Location = new System.Drawing.Point(425, 32);
            this.chkAllGiangVien.Name = "chkAllGiangVien";
            this.chkAllGiangVien.Size = new System.Drawing.Size(68, 23);
            this.chkAllGiangVien.TabIndex = 2;
            this.chkAllGiangVien.Text = "Tất cả ";
            this.chkAllGiangVien.UseVisualStyleBackColor = true;
            this.chkAllGiangVien.CheckedChanged += new System.EventHandler(this.chkAllGiangVien_CheckedChanged);
            // 
            // cboGiangVien
            // 
            this.cboGiangVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGiangVien.FormattingEnabled = true;
            this.cboGiangVien.Location = new System.Drawing.Point(195, 30);
            this.cboGiangVien.Name = "cboGiangVien";
            this.cboGiangVien.Size = new System.Drawing.Size(220, 25);
            this.cboGiangVien.TabIndex = 1;
            // 
            // lblGiangVien
            // 
            this.lblGiangVien.AutoSize = true;
            this.lblGiangVien.Location = new System.Drawing.Point(95, 34);
            this.lblGiangVien.Name = "lblGiangVien";
            this.lblGiangVien.Size = new System.Drawing.Size(83, 19);
            this.lblGiangVien.TabIndex = 0;
            this.lblGiangVien.Text = "Giảng viên :";
            // 
            // pnResult
            // 
            this.pnResult.BackColor = System.Drawing.Color.White;
            this.pnResult.Controls.Add(this.dgvBaoCaoGV);
            this.pnResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnResult.Location = new System.Drawing.Point(0, 180);
            this.pnResult.Name = "pnResult";
            this.pnResult.Size = new System.Drawing.Size(1031, 554);
            this.pnResult.TabIndex = 2;
            // 
            // dgvBaoCaoGV
            // 
            this.dgvBaoCaoGV.AllowUserToAddRows = false;
            this.dgvBaoCaoGV.AllowUserToDeleteRows = false;
            this.dgvBaoCaoGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCaoGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCaoGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBaoCaoGV.Location = new System.Drawing.Point(0, 0);
            this.dgvBaoCaoGV.Name = "dgvBaoCaoGV";
            this.dgvBaoCaoGV.ReadOnly = true;
            this.dgvBaoCaoGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaoCaoGV.Size = new System.Drawing.Size(1031, 554);
            this.dgvBaoCaoGV.TabIndex = 0;
            // 
            // frmBaoCaoGiangVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 734);
            this.Controls.Add(this.pnResult);
            this.Controls.Add(this.pnFilter);
            this.Controls.Add(this.pnTitile);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmBaoCaoGiangVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo đề tài theo giảng viên";
            this.Load += new System.EventHandler(this.frmBaoCaoGiangVien_Load);
            this.pnTitile.ResumeLayout(false);
            this.pnTitile.PerformLayout();
            this.pnFilter.ResumeLayout(false);
            this.pnFilter.PerformLayout();
            this.pnResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTitile;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnFilter;
        private System.Windows.Forms.Label lblGiangVien;
        private System.Windows.Forms.CheckBox chkAllGiangVien;
        private System.Windows.Forms.ComboBox cboGiangVien;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Panel pnResult;
        private System.Windows.Forms.DataGridView dgvBaoCaoGV;
        private System.Windows.Forms.Button btnInBaoCao;
    }
}
