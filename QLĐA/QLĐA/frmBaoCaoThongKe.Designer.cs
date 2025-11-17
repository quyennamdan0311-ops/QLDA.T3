namespace QLĐA
{
    partial class frmBaoCaoThongKe
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
            this.pnResult = new System.Windows.Forms.Panel();
            this.dgvBaoCaoTK = new System.Windows.Forms.DataGridView();
            this.pnFilter = new System.Windows.Forms.Panel();
            this.chkAllNam = new System.Windows.Forms.CheckBox();
            this.cboNam = new System.Windows.Forms.ComboBox();
            this.lblNam = new System.Windows.Forms.Label();
            this.chkAllHocKy = new System.Windows.Forms.CheckBox();
            this.btnInBaoCao = new System.Windows.Forms.Button();
            this.cboHocKy = new System.Windows.Forms.ComboBox();
            this.lblKyHoc = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.chkAllChuyenNganh = new System.Windows.Forms.CheckBox();
            this.cboChuyenNganh = new System.Windows.Forms.ComboBox();
            this.lblChuyenNganh = new System.Windows.Forms.Label();
            this.pnTitile = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoTK)).BeginInit();
            this.pnFilter.SuspendLayout();
            this.pnTitile.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnResult
            // 
            this.pnResult.BackColor = System.Drawing.Color.White;
            this.pnResult.Controls.Add(this.dgvBaoCaoTK);
            this.pnResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnResult.Location = new System.Drawing.Point(0, 180);
            this.pnResult.Name = "pnResult";
            this.pnResult.Size = new System.Drawing.Size(1032, 524);
            this.pnResult.TabIndex = 5;
            // 
            // dgvBaoCaoTK
            // 
            this.dgvBaoCaoTK.AllowUserToAddRows = false;
            this.dgvBaoCaoTK.AllowUserToDeleteRows = false;
            this.dgvBaoCaoTK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaoCaoTK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCaoTK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBaoCaoTK.Location = new System.Drawing.Point(0, 0);
            this.dgvBaoCaoTK.Name = "dgvBaoCaoTK";
            this.dgvBaoCaoTK.ReadOnly = true;
            this.dgvBaoCaoTK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaoCaoTK.Size = new System.Drawing.Size(1032, 524);
            this.dgvBaoCaoTK.TabIndex = 0;
            // 
            // pnFilter
            // 
            this.pnFilter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnFilter.Controls.Add(this.chkAllNam);
            this.pnFilter.Controls.Add(this.cboNam);
            this.pnFilter.Controls.Add(this.lblNam);
            this.pnFilter.Controls.Add(this.chkAllHocKy);
            this.pnFilter.Controls.Add(this.btnInBaoCao);
            this.pnFilter.Controls.Add(this.cboHocKy);
            this.pnFilter.Controls.Add(this.lblKyHoc);
            this.pnFilter.Controls.Add(this.btnDong);
            this.pnFilter.Controls.Add(this.btnXemBaoCao);
            this.pnFilter.Controls.Add(this.chkAllChuyenNganh);
            this.pnFilter.Controls.Add(this.cboChuyenNganh);
            this.pnFilter.Controls.Add(this.lblChuyenNganh);
            this.pnFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnFilter.Location = new System.Drawing.Point(0, 60);
            this.pnFilter.Name = "pnFilter";
            this.pnFilter.Size = new System.Drawing.Size(1032, 120);
            this.pnFilter.TabIndex = 4;
            // 
            // chkAllNam
            // 
            this.chkAllNam.AutoSize = true;
            this.chkAllNam.Location = new System.Drawing.Point(430, 75);
            this.chkAllNam.Name = "chkAllNam";
            this.chkAllNam.Size = new System.Drawing.Size(60, 17);
            this.chkAllNam.TabIndex = 14;
            this.chkAllNam.Text = "Tất cả ";
            this.chkAllNam.UseVisualStyleBackColor = true;
            // 
            // cboNam
            // 
            this.cboNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNam.FormattingEnabled = true;
            this.cboNam.Location = new System.Drawing.Point(358, 73);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(66, 21);
            this.cboNam.TabIndex = 13;
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(306, 77);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(35, 13);
            this.lblNam.TabIndex = 12;
            this.lblNam.Text = "Năm :";
            // 
            // chkAllHocKy
            // 
            this.chkAllHocKy.AutoSize = true;
            this.chkAllHocKy.Location = new System.Drawing.Point(219, 75);
            this.chkAllHocKy.Name = "chkAllHocKy";
            this.chkAllHocKy.Size = new System.Drawing.Size(60, 17);
            this.chkAllHocKy.TabIndex = 5;
            this.chkAllHocKy.Text = "Tất cả ";
            this.chkAllHocKy.UseVisualStyleBackColor = true;
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
            // cboHocKy
            // 
            this.cboHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHocKy.FormattingEnabled = true;
            this.cboHocKy.Location = new System.Drawing.Point(147, 74);
            this.cboHocKy.Name = "cboHocKy";
            this.cboHocKy.Size = new System.Drawing.Size(66, 21);
            this.cboHocKy.TabIndex = 4;
            // 
            // lblKyHoc
            // 
            this.lblKyHoc.AutoSize = true;
            this.lblKyHoc.Location = new System.Drawing.Point(95, 77);
            this.lblKyHoc.Name = "lblKyHoc";
            this.lblKyHoc.Size = new System.Drawing.Size(46, 13);
            this.lblKyHoc.TabIndex = 3;
            this.lblKyHoc.Text = "Kỳ học :";
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
            // chkAllChuyenNganh
            // 
            this.chkAllChuyenNganh.AutoSize = true;
            this.chkAllChuyenNganh.Location = new System.Drawing.Point(425, 32);
            this.chkAllChuyenNganh.Name = "chkAllChuyenNganh";
            this.chkAllChuyenNganh.Size = new System.Drawing.Size(60, 17);
            this.chkAllChuyenNganh.TabIndex = 2;
            this.chkAllChuyenNganh.Text = "Tất cả ";
            this.chkAllChuyenNganh.UseVisualStyleBackColor = true;
            // 
            // cboChuyenNganh
            // 
            this.cboChuyenNganh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChuyenNganh.FormattingEnabled = true;
            this.cboChuyenNganh.Location = new System.Drawing.Point(195, 30);
            this.cboChuyenNganh.Name = "cboChuyenNganh";
            this.cboChuyenNganh.Size = new System.Drawing.Size(220, 21);
            this.cboChuyenNganh.TabIndex = 1;
            // 
            // lblChuyenNganh
            // 
            this.lblChuyenNganh.AutoSize = true;
            this.lblChuyenNganh.Location = new System.Drawing.Point(95, 34);
            this.lblChuyenNganh.Name = "lblChuyenNganh";
            this.lblChuyenNganh.Size = new System.Drawing.Size(84, 13);
            this.lblChuyenNganh.TabIndex = 0;
            this.lblChuyenNganh.Text = "Chuyên Ngành :";
            // 
            // pnTitile
            // 
            this.pnTitile.BackColor = System.Drawing.Color.SteelBlue;
            this.pnTitile.Controls.Add(this.lblTitle);
            this.pnTitile.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitile.Location = new System.Drawing.Point(0, 0);
            this.pnTitile.Name = "pnTitile";
            this.pnTitile.Size = new System.Drawing.Size(1032, 60);
            this.pnTitile.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(293, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Báo cáo đề tài theo năm, kỳ học";
            // 
            // frmBaoCaoThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 704);
            this.Controls.Add(this.pnResult);
            this.Controls.Add(this.pnFilter);
            this.Controls.Add(this.pnTitile);
            this.Name = "frmBaoCaoThongKe";
            this.Text = "frmBaoCaoThongKe";
            this.Load += new System.EventHandler(this.frmBaoCaoThongKe_Load);
            this.pnResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoTK)).EndInit();
            this.pnFilter.ResumeLayout(false);
            this.pnFilter.PerformLayout();
            this.pnTitile.ResumeLayout(false);
            this.pnTitile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnResult;
        private System.Windows.Forms.DataGridView dgvBaoCaoTK;
        private System.Windows.Forms.Panel pnFilter;
        private System.Windows.Forms.CheckBox chkAllNam;
        private System.Windows.Forms.ComboBox cboNam;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.CheckBox chkAllHocKy;
        private System.Windows.Forms.Button btnInBaoCao;
        private System.Windows.Forms.ComboBox cboHocKy;
        private System.Windows.Forms.Label lblKyHoc;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.CheckBox chkAllChuyenNganh;
        private System.Windows.Forms.ComboBox cboChuyenNganh;
        private System.Windows.Forms.Label lblChuyenNganh;
        private System.Windows.Forms.Panel pnTitile;
        private System.Windows.Forms.Label lblTitle;
    }
}