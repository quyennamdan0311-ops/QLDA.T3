namespace QLĐA
{
    partial class frmTraCuu
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
            this.label1 = new System.Windows.Forms.Label();
            this.grpDoiTuongTraCuu = new System.Windows.Forms.GroupBox();
            this.rdoDoAn = new System.Windows.Forms.RadioButton();
            this.rdoGiangVien = new System.Windows.Forms.RadioButton();
            this.rdoSinhVien = new System.Windows.Forms.RadioButton();
            this.grpTieuChiTraCuu = new System.Windows.Forms.GroupBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTieuChi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grpDoiTuongTraCuu.SuspendLayout();
            this.grpTieuChiTraCuu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(684, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tra cứu thông tin";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // grpDoiTuongTraCuu
            // 
            this.grpDoiTuongTraCuu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grpDoiTuongTraCuu.Controls.Add(this.rdoDoAn);
            this.grpDoiTuongTraCuu.Controls.Add(this.rdoGiangVien);
            this.grpDoiTuongTraCuu.Controls.Add(this.rdoSinhVien);
            this.grpDoiTuongTraCuu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDoiTuongTraCuu.Location = new System.Drawing.Point(387, 101);
            this.grpDoiTuongTraCuu.Name = "grpDoiTuongTraCuu";
            this.grpDoiTuongTraCuu.Size = new System.Drawing.Size(868, 100);
            this.grpDoiTuongTraCuu.TabIndex = 1;
            this.grpDoiTuongTraCuu.TabStop = false;
            this.grpDoiTuongTraCuu.Text = "Đối tượng tra cứu";
            // 
            // rdoDoAn
            // 
            this.rdoDoAn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoDoAn.AutoSize = true;
            this.rdoDoAn.Location = new System.Drawing.Point(678, 49);
            this.rdoDoAn.Name = "rdoDoAn";
            this.rdoDoAn.Size = new System.Drawing.Size(143, 36);
            this.rdoDoAn.TabIndex = 2;
            this.rdoDoAn.Text = "📋 Đồ án";
            this.rdoDoAn.UseVisualStyleBackColor = true;
            this.rdoDoAn.CheckedChanged += new System.EventHandler(this.rdoDoAn_CheckedChanged);
            // 
            // rdoGiangVien
            // 
            this.rdoGiangVien.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rdoGiangVien.AutoSize = true;
            this.rdoGiangVien.Location = new System.Drawing.Point(360, 49);
            this.rdoGiangVien.Name = "rdoGiangVien";
            this.rdoGiangVien.Size = new System.Drawing.Size(193, 36);
            this.rdoGiangVien.TabIndex = 1;
            this.rdoGiangVien.Text = "👨‍🏫 Giảng viên";
            this.rdoGiangVien.UseVisualStyleBackColor = true;
            this.rdoGiangVien.CheckedChanged += new System.EventHandler(this.rdoGiangVien_CheckedChanged);
            // 
            // rdoSinhVien
            // 
            this.rdoSinhVien.AutoSize = true;
            this.rdoSinhVien.Checked = true;
            this.rdoSinhVien.Location = new System.Drawing.Point(68, 49);
            this.rdoSinhVien.Name = "rdoSinhVien";
            this.rdoSinhVien.Size = new System.Drawing.Size(178, 36);
            this.rdoSinhVien.TabIndex = 0;
            this.rdoSinhVien.TabStop = true;
            this.rdoSinhVien.Text = "👨‍🎓 Sinh viên";
            this.rdoSinhVien.UseVisualStyleBackColor = true;
            this.rdoSinhVien.CheckedChanged += new System.EventHandler(this.rdoSinhVien_CheckedChanged);
            // 
            // grpTieuChiTraCuu
            // 
            this.grpTieuChiTraCuu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grpTieuChiTraCuu.Controls.Add(this.btnTimKiem);
            this.grpTieuChiTraCuu.Controls.Add(this.txtTuKhoa);
            this.grpTieuChiTraCuu.Controls.Add(this.label3);
            this.grpTieuChiTraCuu.Controls.Add(this.cboTieuChi);
            this.grpTieuChiTraCuu.Controls.Add(this.label2);
            this.grpTieuChiTraCuu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTieuChiTraCuu.Location = new System.Drawing.Point(389, 250);
            this.grpTieuChiTraCuu.Name = "grpTieuChiTraCuu";
            this.grpTieuChiTraCuu.Size = new System.Drawing.Size(1053, 172);
            this.grpTieuChiTraCuu.TabIndex = 2;
            this.grpTieuChiTraCuu.TabStop = false;
            this.grpTieuChiTraCuu.Text = "Tiêu chí tra cứu";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(878, 111);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(155, 39);
            this.btnTimKiem.TabIndex = 6;
            this.btnTimKiem.Text = "🔍Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Location = new System.Drawing.Point(165, 111);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(670, 39);
            this.txtTuKhoa.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "Từ khóa:";
            // 
            // cboTieuChi
            // 
            this.cboTieuChi.FormattingEnabled = true;
            this.cboTieuChi.Location = new System.Drawing.Point(165, 49);
            this.cboTieuChi.Name = "cboTieuChi";
            this.cboTieuChi.Size = new System.Drawing.Size(670, 40);
            this.cboTieuChi.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tiêu chí:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(50, 453);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1618, 551);
            this.dataGridView1.TabIndex = 3;
            // 
            // frmTraCuu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1707, 990);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.grpTieuChiTraCuu);
            this.Controls.Add(this.grpDoiTuongTraCuu);
            this.Controls.Add(this.label1);
            this.Name = "frmTraCuu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tra cứu";
            this.grpDoiTuongTraCuu.ResumeLayout(false);
            this.grpDoiTuongTraCuu.PerformLayout();
            this.grpTieuChiTraCuu.ResumeLayout(false);
            this.grpTieuChiTraCuu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpDoiTuongTraCuu;
        private System.Windows.Forms.RadioButton rdoSinhVien;
        private System.Windows.Forms.RadioButton rdoDoAn;
        private System.Windows.Forms.RadioButton rdoGiangVien;
        private System.Windows.Forms.GroupBox grpTieuChiTraCuu;
        private System.Windows.Forms.ComboBox cboTieuChi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}