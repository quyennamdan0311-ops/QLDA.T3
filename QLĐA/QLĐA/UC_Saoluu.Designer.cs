namespace QLĐA
{
    partial class UC_Saoluu
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
            this.btnBrowseSave = new System.Windows.Forms.Button();
            this.txtDuongDanLuuFile = new System.Windows.Forms.TextBox();
            this.btnBackup = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowseLoad = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.txtDuongDanLoadFile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowseSave
            // 
            this.btnBrowseSave.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnBrowseSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseSave.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBrowseSave.Location = new System.Drawing.Point(717, 56);
            this.btnBrowseSave.Name = "btnBrowseSave";
            this.btnBrowseSave.Size = new System.Drawing.Size(159, 57);
            this.btnBrowseSave.TabIndex = 3;
            this.btnBrowseSave.Text = "Browse";
            this.btnBrowseSave.UseVisualStyleBackColor = false;
            this.btnBrowseSave.Click += new System.EventHandler(this.btnBrowseSave_Click_1);
            // 
            // txtDuongDanLuuFile
            // 
            this.txtDuongDanLuuFile.Location = new System.Drawing.Point(171, 65);
            this.txtDuongDanLuuFile.Name = "txtDuongDanLuuFile";
            this.txtDuongDanLuuFile.Size = new System.Drawing.Size(520, 42);
            this.txtDuongDanLuuFile.TabIndex = 2;
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnBackup.Location = new System.Drawing.Point(366, 127);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(159, 68);
            this.btnBackup.TabIndex = 1;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnSaoLuu_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBrowseLoad);
            this.groupBox2.Controls.Add(this.btnRestore);
            this.groupBox2.Controls.Add(this.txtDuongDanLoadFile);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(160, 394);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(926, 217);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Restore dữ liệu";
            // 
            // btnBrowseLoad
            // 
            this.btnBrowseLoad.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnBrowseLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseLoad.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBrowseLoad.Location = new System.Drawing.Point(717, 65);
            this.btnBrowseLoad.Name = "btnBrowseLoad";
            this.btnBrowseLoad.Size = new System.Drawing.Size(159, 48);
            this.btnBrowseLoad.TabIndex = 6;
            this.btnBrowseLoad.Text = "Browse";
            this.btnBrowseLoad.UseVisualStyleBackColor = false;
            this.btnBrowseLoad.Click += new System.EventHandler(this.btnBrowseLoad_Click_1);
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnRestore.Location = new System.Drawing.Point(366, 149);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(159, 62);
            this.btnRestore.TabIndex = 5;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click_1);
            // 
            // txtDuongDanLoadFile
            // 
            this.txtDuongDanLoadFile.Location = new System.Drawing.Point(224, 86);
            this.txtDuongDanLoadFile.Name = "txtDuongDanLoadFile";
            this.txtDuongDanLoadFile.Size = new System.Drawing.Size(451, 42);
            this.txtDuongDanLoadFile.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "Chọn file";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(411, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "SAO LƯU - PHỤC HỒI DỮ LIỆU";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(198, 44);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(23, 9);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtDuongDanLuuFile);
            this.groupBox4.Controls.Add(this.btnBrowseSave);
            this.groupBox4.Controls.Add(this.btnBackup);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(160, 158);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(882, 201);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sao lưu dữ liệu";
            // 
            // UC_Saoluu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Name = "UC_Saoluu";
            this.Size = new System.Drawing.Size(1212, 757);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDuongDanLuuFile;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnBrowseSave;
        private System.Windows.Forms.Button btnBrowseLoad;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.TextBox txtDuongDanLoadFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}
