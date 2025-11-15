namespace Project_QLDA
{
    partial class frmDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.btnTraCuuGiangVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnTraCuuDoAn = new DevExpress.XtraBars.BarButtonItem();
            this.btnTraCuuSinhVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogIn = new DevExpress.XtraBars.BarButtonItem();
            this.barUser = new DevExpress.XtraBars.BarStaticItem();
            this.barTimer = new DevExpress.XtraBars.BarStaticItem();
            this.barClock = new DevExpress.XtraBars.BarStaticItem();
            this.btnDangNhap = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnTraCuu = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.BackColor = System.Drawing.Color.White;
            this.ribbon.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(67);
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barButtonItem1,
            this.btnExit,
            this.barButtonItem3,
            this.btnTraCuuGiangVien,
            this.btnTraCuuDoAn,
            this.btnTraCuuSinhVien,
            this.btnLogIn,
            this.barUser,
            this.barTimer,
            this.barClock,
            this.btnDangNhap,
            this.barButtonItem2,
            this.btnTraCuu,
            this.barButtonItem4,
            this.barButtonItem5});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ribbon.MaxItemId = 23;
            this.ribbon.Name = "ribbon";
            this.ribbon.OptionsMenuMinWidth = 742;
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1700, 260);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Click += new System.EventHandler(this.ribbon_Click);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick_1);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Thoát";
            this.btnExit.Id = 4;
            this.btnExit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExit.ImageOptions.SvgImage")));
            this.btnExit.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnExit.ItemAppearance.Normal.Options.UseFont = true;
            this.btnExit.ItemInMenuAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnExit.ItemInMenuAppearance.Normal.Options.UseFont = true;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 5;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // btnTraCuuGiangVien
            // 
            this.btnTraCuuGiangVien.Caption = "Tra cứu giảng viên";
            this.btnTraCuuGiangVien.Id = 10;
            this.btnTraCuuGiangVien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTraCuuGiangVien.ImageOptions.Image")));
            this.btnTraCuuGiangVien.Name = "btnTraCuuGiangVien";
            this.btnTraCuuGiangVien.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTraCuuGiangVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTraCuuGiangVien_ItemClick);
            // 
            // btnTraCuuDoAn
            // 
            this.btnTraCuuDoAn.Caption = "Tra cứu đồ án";
            this.btnTraCuuDoAn.Id = 11;
            this.btnTraCuuDoAn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTraCuuDoAn.ImageOptions.Image")));
            this.btnTraCuuDoAn.Name = "btnTraCuuDoAn";
            this.btnTraCuuDoAn.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTraCuuDoAn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTraCuuDoAn_ItemClick);
            // 
            // btnTraCuuSinhVien
            // 
            this.btnTraCuuSinhVien.Caption = "Tra cứu sinh viên";
            this.btnTraCuuSinhVien.Id = 12;
            this.btnTraCuuSinhVien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTraCuuSinhVien.ImageOptions.Image")));
            this.btnTraCuuSinhVien.Name = "btnTraCuuSinhVien";
            this.btnTraCuuSinhVien.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTraCuuSinhVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick_1);
            // 
            // btnLogIn
            // 
            this.btnLogIn.Id = 18;
            this.btnLogIn.Name = "btnLogIn";
            // 
            // barUser
            // 
            this.barUser.Caption = "Người dùng: Khách";
            this.barUser.Id = 14;
            this.barUser.Name = "barUser";
            // 
            // barTimer
            // 
            this.barTimer.Id = 15;
            this.barTimer.Name = "barTimer";
            this.barTimer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barTimer_ItemClick);
            // 
            // barClock
            // 
            this.barClock.Caption = "barStaticItem1";
            this.barClock.Id = 16;
            this.barClock.Name = "barClock";
            this.barClock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barClock_ItemClick);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Caption = "Đăng nhập";
            this.btnDangNhap.Id = 17;
            this.btnDangNhap.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDangNhap.ImageOptions.Image")));
            this.btnDangNhap.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnDangNhap.ItemAppearance.Normal.Options.UseFont = true;
            this.btnDangNhap.ItemInMenuAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnDangNhap.ItemInMenuAppearance.Normal.Options.UseFont = true;
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDangNhap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDangNhap_ItemClick_2);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Tra Cứu";
            this.barButtonItem2.Id = 19;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnTraCuu
            // 
            this.btnTraCuu.Caption = "Tra cứu thông tin ";
            this.btnTraCuu.Id = 20;
            this.btnTraCuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTraCuu.ImageOptions.Image")));
            this.btnTraCuu.ImageOptions.SvgImageSize = new System.Drawing.Size(45, 45);
            this.btnTraCuu.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnTraCuu.ItemAppearance.Normal.Options.UseFont = true;
            this.btnTraCuu.ItemInMenuAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnTraCuu.ItemInMenuAppearance.Normal.Options.UseFont = true;
            this.btnTraCuu.Name = "btnTraCuu";
            this.btnTraCuu.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnTraCuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTraCuu_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 21;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "barButtonItem5";
            this.barButtonItem5.Id = 22;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("ribbonPage1.ImageOptions.SvgImage")));
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Hệ thống";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDangNhap);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnExit);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Phiên làm việc";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barUser);
            this.ribbonStatusBar.ItemLinks.Add(this.barTimer);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 948);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1700, 36);
            this.ribbonStatusBar.Click += new System.EventHandler(this.ribbonStatusBar_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(284, 104);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(294, 304);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(276, 422);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 38);
            this.label1.TabIndex = 3;
            this.label1.Text = "NEU Project Manager";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14F);
            this.label2.Location = new System.Drawing.Point(231, 472);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(418, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Khoa Hệ thống thông tin quản lý";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(1023, 1488);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(0, 19);
            this.labelControl1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(174, 627);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(561, 33);
            this.label3.TabIndex = 6;
            this.label3.Text = "Vui lòng đăng nhập để sử dụng hệ thống";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(214, 538);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(463, 64);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tra cứu, tham khảo đồ án sinh viên.\r\n  Hỗ trợ giảng viên quản lý đồ án.";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(-22, -22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 27);
            this.textBox1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 260);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(921, 688);
            this.panel2.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(921, 260);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(779, 688);
            this.panel1.TabIndex = 13;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(779, 688);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1700, 984);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "frmDangNhap";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Phần mềm quản lý đồ án";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem btnProfile;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnSettings;
        private DevExpress.XtraBars.BarButtonItem btnTraCuuGiangVien;
        private DevExpress.XtraBars.BarButtonItem btnTraCuuDoAn;
        private DevExpress.XtraBars.BarButtonItem btnTraCuuSinhVien;
        private DevExpress.XtraBars.BarButtonItem btnLogIn;
        private DevExpress.XtraBars.BarStaticItem barUser;
        private DevExpress.XtraBars.BarStaticItem barTimer;
        private DevExpress.XtraBars.BarStaticItem barClock;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevExpress.XtraBars.BarButtonItem btnDangNhap;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem btnTraCuu;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
    }
}