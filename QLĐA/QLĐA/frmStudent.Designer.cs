namespace QLĐA
{
    partial class frmStudent
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudent));
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnLogout = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem4 = new DevExpress.XtraBars.BarStaticItem();
            this.btnTraCuu = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grbThongTinCaNhan = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtKhoa = new System.Windows.Forms.TextBox();
            this.txtLopNienChe = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grbThongTinDoAn = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtNgayBaoVe = new System.Windows.Forms.TextBox();
            this.txtGVPB = new System.Windows.Forms.TextBox();
            this.txtGVHD = new System.Windows.Forms.TextBox();
            this.txtTenDoAn = new System.Windows.Forms.TextBox();
            this.txtMaDoAn = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.grbThongTinCaNhan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grbThongTinDoAn.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 961);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1802, 36);
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnLogout,
            this.btnClose,
            this.barStaticItem1,
            this.barStaticItem2,
            this.barStaticItem3,
            this.barStaticItem4,
            this.btnTraCuu});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 8;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbon.Size = new System.Drawing.Size(1802, 250);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnLogout
            // 
            this.btnLogout.Caption = "Đăng xuất";
            this.btnLogout.Id = 1;
            this.btnLogout.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.ImageOptions.Image")));
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogout_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Thoát";
            this.btnClose.Id = 2;
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnClose.ImageOptions.SvgImage")));
            this.btnClose.Name = "btnClose";
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Xin chào ";
            this.barStaticItem1.Id = 3;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "barStaticItem2";
            this.barStaticItem2.Id = 4;
            this.barStaticItem2.Name = "barStaticItem2";
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.Caption = "Vai trò: ";
            this.barStaticItem3.Id = 5;
            this.barStaticItem3.Name = "barStaticItem3";
            this.barStaticItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barStaticItem3_ItemClick);
            // 
            // barStaticItem4
            // 
            this.barStaticItem4.Caption = "barStaticItem4";
            this.barStaticItem4.Id = 6;
            this.barStaticItem4.Name = "barStaticItem4";
            // 
            // btnTraCuu
            // 
            this.btnTraCuu.Caption = "Tra cứu";
            this.btnTraCuu.Id = 7;
            this.btnTraCuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTraCuu.ImageOptions.Image")));
            this.btnTraCuu.Name = "btnTraCuu";
            this.btnTraCuu.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTraCuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTraCuu_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPage1.ImageOptions.Image")));
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Tài khoản";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLogout);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnClose);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Phiên làm việc";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ribbonPage2.ImageOptions.SvgImage")));
            this.ribbonPage2.ImageOptions.SvgImageSize = new System.Drawing.Size(25, 25);
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Chức năng";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnTraCuu);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Quyền hạn";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // grbThongTinCaNhan
            // 
            this.grbThongTinCaNhan.Controls.Add(this.pictureBox1);
            this.grbThongTinCaNhan.Controls.Add(this.txtEmail);
            this.grbThongTinCaNhan.Controls.Add(this.txtKhoa);
            this.grbThongTinCaNhan.Controls.Add(this.txtLopNienChe);
            this.grbThongTinCaNhan.Controls.Add(this.txtHoTen);
            this.grbThongTinCaNhan.Controls.Add(this.txtMaSV);
            this.grbThongTinCaNhan.Controls.Add(this.label7);
            this.grbThongTinCaNhan.Controls.Add(this.label1);
            this.grbThongTinCaNhan.Controls.Add(this.label2);
            this.grbThongTinCaNhan.Controls.Add(this.label5);
            this.grbThongTinCaNhan.Controls.Add(this.label4);
            this.grbThongTinCaNhan.Font = new System.Drawing.Font("Tahoma", 11F);
            this.grbThongTinCaNhan.Location = new System.Drawing.Point(0, 250);
            this.grbThongTinCaNhan.Name = "grbThongTinCaNhan";
            this.grbThongTinCaNhan.Size = new System.Drawing.Size(914, 713);
            this.grbThongTinCaNhan.TabIndex = 7;
            this.grbThongTinCaNhan.TabStop = false;
            this.grbThongTinCaNhan.Text = "Thông tin cá nhân";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(170, 594);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(524, 34);
            this.txtEmail.TabIndex = 15;
            // 
            // txtKhoa
            // 
            this.txtKhoa.Location = new System.Drawing.Point(170, 527);
            this.txtKhoa.Name = "txtKhoa";
            this.txtKhoa.ReadOnly = true;
            this.txtKhoa.Size = new System.Drawing.Size(524, 34);
            this.txtKhoa.TabIndex = 13;
            // 
            // txtLopNienChe
            // 
            this.txtLopNienChe.Location = new System.Drawing.Point(170, 465);
            this.txtLopNienChe.Name = "txtLopNienChe";
            this.txtLopNienChe.ReadOnly = true;
            this.txtLopNienChe.Size = new System.Drawing.Size(524, 34);
            this.txtLopNienChe.TabIndex = 12;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(170, 404);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.ReadOnly = true;
            this.txtHoTen.Size = new System.Drawing.Size(467, 34);
            this.txtHoTen.TabIndex = 10;
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(170, 340);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.ReadOnly = true;
            this.txtMaSV.Size = new System.Drawing.Size(211, 34);
            this.txtMaSV.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 594);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 27);
            this.label7.TabIndex = 8;
            this.label7.Text = "Email";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 343);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã sinh viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 407);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ tên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 527);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 27);
            this.label5.TabIndex = 5;
            this.label5.Text = "Khoa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 465);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 27);
            this.label4.TabIndex = 4;
            this.label4.Text = "Lớp";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(299, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 174);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // grbThongTinDoAn
            // 
            this.grbThongTinDoAn.Controls.Add(this.label16);
            this.grbThongTinDoAn.Controls.Add(this.textBox1);
            this.grbThongTinDoAn.Controls.Add(this.label15);
            this.grbThongTinDoAn.Controls.Add(this.txtMoTa);
            this.grbThongTinDoAn.Controls.Add(this.lblMoTa);
            this.grbThongTinDoAn.Controls.Add(this.txtNgayBaoVe);
            this.grbThongTinDoAn.Controls.Add(this.txtGVPB);
            this.grbThongTinDoAn.Controls.Add(this.txtGVHD);
            this.grbThongTinDoAn.Controls.Add(this.txtTenDoAn);
            this.grbThongTinDoAn.Controls.Add(this.txtMaDoAn);
            this.grbThongTinDoAn.Controls.Add(this.label13);
            this.grbThongTinDoAn.Controls.Add(this.label10);
            this.grbThongTinDoAn.Controls.Add(this.label9);
            this.grbThongTinDoAn.Controls.Add(this.label8);
            this.grbThongTinDoAn.Font = new System.Drawing.Font("Tahoma", 11F);
            this.grbThongTinDoAn.Location = new System.Drawing.Point(916, 250);
            this.grbThongTinDoAn.Name = "grbThongTinDoAn";
            this.grbThongTinDoAn.Size = new System.Drawing.Size(886, 713);
            this.grbThongTinDoAn.TabIndex = 0;
            this.grbThongTinDoAn.TabStop = false;
            this.grbThongTinDoAn.Text = "Thông tin đồ án tốt nghiệp";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(23, 458);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 27);
            this.label16.TabIndex = 21;
            this.label16.Text = "Năm";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(314, 458);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(108, 34);
            this.textBox1.TabIndex = 20;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 382);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 27);
            this.label15.TabIndex = 19;
            this.label15.Text = "Học kỳ";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(314, 187);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.ReadOnly = true;
            this.txtMoTa.Size = new System.Drawing.Size(467, 34);
            this.txtMoTa.TabIndex = 18;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(23, 190);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(67, 27);
            this.lblMoTa.TabIndex = 17;
            this.lblMoTa.Text = "Mô tả";
            // 
            // txtNgayBaoVe
            // 
            this.txtNgayBaoVe.Location = new System.Drawing.Point(314, 386);
            this.txtNgayBaoVe.Name = "txtNgayBaoVe";
            this.txtNgayBaoVe.ReadOnly = true;
            this.txtNgayBaoVe.Size = new System.Drawing.Size(467, 34);
            this.txtNgayBaoVe.TabIndex = 15;
            // 
            // txtGVPB
            // 
            this.txtGVPB.Location = new System.Drawing.Point(314, 313);
            this.txtGVPB.Name = "txtGVPB";
            this.txtGVPB.ReadOnly = true;
            this.txtGVPB.Size = new System.Drawing.Size(467, 34);
            this.txtGVPB.TabIndex = 13;
            // 
            // txtGVHD
            // 
            this.txtGVHD.Location = new System.Drawing.Point(314, 245);
            this.txtGVHD.Name = "txtGVHD";
            this.txtGVHD.ReadOnly = true;
            this.txtGVHD.Size = new System.Drawing.Size(467, 34);
            this.txtGVHD.TabIndex = 12;
            // 
            // txtTenDoAn
            // 
            this.txtTenDoAn.Location = new System.Drawing.Point(314, 127);
            this.txtTenDoAn.Multiline = true;
            this.txtTenDoAn.Name = "txtTenDoAn";
            this.txtTenDoAn.ReadOnly = true;
            this.txtTenDoAn.Size = new System.Drawing.Size(402, 34);
            this.txtTenDoAn.TabIndex = 11;
            // 
            // txtMaDoAn
            // 
            this.txtMaDoAn.Location = new System.Drawing.Point(314, 71);
            this.txtMaDoAn.Name = "txtMaDoAn";
            this.txtMaDoAn.ReadOnly = true;
            this.txtMaDoAn.Size = new System.Drawing.Size(191, 34);
            this.txtMaDoAn.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 316);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 27);
            this.label13.TabIndex = 5;
            this.label13.Text = "Ngày nộp";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 248);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(226, 27);
            this.label10.TabIndex = 2;
            this.label10.Text = "Giảng viên hướng dẫn";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 27);
            this.label9.TabIndex = 1;
            this.label9.Text = "Tên đề tài";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 27);
            this.label8.TabIndex = 0;
            this.label8.Text = "Mã đồ án";
            // 
            // frmStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1802, 997);
            this.Controls.Add(this.grbThongTinCaNhan);
            this.Controls.Add(this.grbThongTinDoAn);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "frmStudent";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "frmStudent";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.grbThongTinCaNhan.ResumeLayout(false);
            this.grbThongTinCaNhan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grbThongTinDoAn.ResumeLayout(false);
            this.grbThongTinDoAn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox grbThongTinCaNhan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtKhoa;
        private System.Windows.Forms.TextBox txtLopNienChe;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.GroupBox grbThongTinDoAn;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNgayBaoVe;
        private System.Windows.Forms.TextBox txtGVPB;
        private System.Windows.Forms.TextBox txtGVHD;
        private System.Windows.Forms.TextBox txtTenDoAn;
        private System.Windows.Forms.TextBox txtMaDoAn;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem btnLogout;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.BarStaticItem barStaticItem4;
        private DevExpress.XtraBars.BarButtonItem btnTraCuu;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
    }
}