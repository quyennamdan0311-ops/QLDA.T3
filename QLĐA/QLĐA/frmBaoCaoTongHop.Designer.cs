namespace QLĐA
{
    partial class uctDanhSachBaoCao
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnList = new System.Windows.Forms.Panel();
            this.pnContainer = new System.Windows.Forms.Panel();
            this.pnBCNamKy = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBCNamKy = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnBCGiangVien = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBCGiangVien = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnBCChuyenNganh = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBCChuyenNganh = new System.Windows.Forms.Label();
            this.picCN = new System.Windows.Forms.PictureBox();
            this.pnHeader.SuspendLayout();
            this.pnList.SuspendLayout();
            this.pnContainer.SuspendLayout();
            this.pnBCNamKy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnBCGiangVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnBCChuyenNganh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCN)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.SteelBlue;
            this.pnHeader.Controls.Add(this.lblTitle);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1030, 70);
            this.pnHeader.TabIndex = 0;
            this.pnHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnHeader_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(350, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Danh sách báo cáo đồ án";
            // 
            // pnList
            // 
            this.pnList.Controls.Add(this.pnContainer);
            this.pnList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnList.Location = new System.Drawing.Point(0, 70);
            this.pnList.Name = "pnList";
            this.pnList.Size = new System.Drawing.Size(1030, 530);
            this.pnList.TabIndex = 1;
            // 
            // pnContainer
            // 
            this.pnContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnContainer.BackColor = System.Drawing.Color.White;
            this.pnContainer.Controls.Add(this.pnBCNamKy);
            this.pnContainer.Controls.Add(this.pnBCGiangVien);
            this.pnContainer.Controls.Add(this.pnBCChuyenNganh);
            this.pnContainer.Location = new System.Drawing.Point(160, 60);
            this.pnContainer.Name = "pnContainer";
            this.pnContainer.Size = new System.Drawing.Size(800, 400);
            this.pnContainer.TabIndex = 0;
            // 
            // pnBCNamKy
            // 
            this.pnBCNamKy.BackColor = System.Drawing.Color.LightBlue;
            this.pnBCNamKy.Controls.Add(this.label4);
            this.pnBCNamKy.Controls.Add(this.lblBCNamKy);
            this.pnBCNamKy.Controls.Add(this.pictureBox2);
            this.pnBCNamKy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnBCNamKy.Location = new System.Drawing.Point(20, 200);
            this.pnBCNamKy.Name = "pnBCNamKy";
            this.pnBCNamKy.Size = new System.Drawing.Size(760, 70);
            this.pnBCNamKy.TabIndex = 3;
            this.pnBCNamKy.Click += new System.EventHandler(this.pnBCNamKy_Click);
            this.pnBCNamKy.Paint += new System.Windows.Forms.PaintEventHandler(this.pnBCNamKy_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.SlateGray;
            this.label4.Location = new System.Drawing.Point(80, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(287, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "( Thống kê số lượng đề tài theo khóa, năm, học kỳ)";
            // 
            // lblBCNamKy
            // 
            this.lblBCNamKy.AutoSize = true;
            this.lblBCNamKy.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBCNamKy.Location = new System.Drawing.Point(80, 15);
            this.lblBCNamKy.Name = "lblBCNamKy";
            this.lblBCNamKy.Size = new System.Drawing.Size(320, 20);
            this.lblBCNamKy.TabIndex = 1;
            this.lblBCNamKy.Text = "BÁO CÁO ĐỀ TÀI TỔNG HỢP THEO NĂM/KỲ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(20, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pnBCGiangVien
            // 
            this.pnBCGiangVien.BackColor = System.Drawing.Color.LightBlue;
            this.pnBCGiangVien.Controls.Add(this.label2);
            this.pnBCGiangVien.Controls.Add(this.lblBCGiangVien);
            this.pnBCGiangVien.Controls.Add(this.pictureBox1);
            this.pnBCGiangVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnBCGiangVien.Location = new System.Drawing.Point(20, 110);
            this.pnBCGiangVien.Name = "pnBCGiangVien";
            this.pnBCGiangVien.Size = new System.Drawing.Size(760, 70);
            this.pnBCGiangVien.TabIndex = 3;
            this.pnBCGiangVien.Click += new System.EventHandler(this.pnBCGiangVien_Click);
            this.pnBCGiangVien.Paint += new System.Windows.Forms.PaintEventHandler(this.pnBCGiangVien_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.SlateGray;
            this.label2.Location = new System.Drawing.Point(80, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "( Xem danh sách đề tài mà mỗi giảng viên hướng dẫn)";
            // 
            // lblBCGiangVien
            // 
            this.lblBCGiangVien.AutoSize = true;
            this.lblBCGiangVien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBCGiangVien.Location = new System.Drawing.Point(80, 15);
            this.lblBCGiangVien.Name = "lblBCGiangVien";
            this.lblBCGiangVien.Size = new System.Drawing.Size(263, 20);
            this.lblBCGiangVien.TabIndex = 1;
            this.lblBCGiangVien.Text = "BÁO CÁO ĐỀ TÀI THEO GIẢNG VIÊN";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(20, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnBCChuyenNganh
            // 
            this.pnBCChuyenNganh.BackColor = System.Drawing.Color.LightBlue;
            this.pnBCChuyenNganh.Controls.Add(this.label1);
            this.pnBCChuyenNganh.Controls.Add(this.lblBCChuyenNganh);
            this.pnBCChuyenNganh.Controls.Add(this.picCN);
            this.pnBCChuyenNganh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnBCChuyenNganh.Location = new System.Drawing.Point(20, 20);
            this.pnBCChuyenNganh.Name = "pnBCChuyenNganh";
            this.pnBCChuyenNganh.Size = new System.Drawing.Size(760, 70);
            this.pnBCChuyenNganh.TabIndex = 0;
            this.pnBCChuyenNganh.Click += new System.EventHandler(this.pnBCChuyenNganh_Click);
            this.pnBCChuyenNganh.Paint += new System.Windows.Forms.PaintEventHandler(this.pnBCChuyenNganh_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.SlateGray;
            this.label1.Location = new System.Drawing.Point(80, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "( Xem danh sách đề tài theo từng chuyên ngành)";
            // 
            // lblBCChuyenNganh
            // 
            this.lblBCChuyenNganh.AutoSize = true;
            this.lblBCChuyenNganh.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBCChuyenNganh.Location = new System.Drawing.Point(80, 15);
            this.lblBCChuyenNganh.Name = "lblBCChuyenNganh";
            this.lblBCChuyenNganh.Size = new System.Drawing.Size(295, 20);
            this.lblBCChuyenNganh.TabIndex = 1;
            this.lblBCChuyenNganh.Text = "BÁO CÁO ĐỀ TÀI THEO CHUYÊN NGÀNH";
            // 
            // picCN
            // 
            this.picCN.Location = new System.Drawing.Point(20, 15);
            this.picCN.Name = "picCN";
            this.picCN.Size = new System.Drawing.Size(40, 40);
            this.picCN.TabIndex = 0;
            this.picCN.TabStop = false;
            // 
            // uctDanhSachBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.pnList);
            this.Controls.Add(this.pnHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "uctDanhSachBaoCao";
            this.Size = new System.Drawing.Size(1030, 600);
            this.Load += new System.EventHandler(this.uctDanhSachBaoCao_Load);
            this.pnHeader.ResumeLayout(false);
            this.pnHeader.PerformLayout();
            this.pnList.ResumeLayout(false);
            this.pnContainer.ResumeLayout(false);
            this.pnBCNamKy.ResumeLayout(false);
            this.pnBCNamKy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnBCGiangVien.ResumeLayout(false);
            this.pnBCGiangVien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnBCChuyenNganh.ResumeLayout(false);
            this.pnBCChuyenNganh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnList;
        private System.Windows.Forms.Panel pnContainer;
        private System.Windows.Forms.Panel pnBCChuyenNganh;
        private System.Windows.Forms.PictureBox picCN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBCChuyenNganh;
        private System.Windows.Forms.Panel pnBCNamKy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBCNamKy;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pnBCGiangVien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBCGiangVien;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
