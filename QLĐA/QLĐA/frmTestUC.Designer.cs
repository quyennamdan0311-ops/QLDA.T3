namespace QLĐA
{
    partial class frmTestUC
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
            this.uC_TraCuu1 = new QLĐA.UC_TraCuu();
            this.SuspendLayout();
            // 
            // uC_TraCuu1
            // 
            this.uC_TraCuu1.Location = new System.Drawing.Point(31, 12);
            this.uC_TraCuu1.Name = "uC_TraCuu1";
            this.uC_TraCuu1.Size = new System.Drawing.Size(1843, 1088);
            this.uC_TraCuu1.TabIndex = 0;
            this.uC_TraCuu1.Load += new System.EventHandler(this.uC_TraCuu1_Load);
            // 
            // frmTestUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1927, 1125);
            this.Controls.Add(this.uC_TraCuu1);
            this.Name = "frmTestUC";
            this.Text = "frmTestUC";
            this.Load += new System.EventHandler(this.frmTestUC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UC_TraCuu uC_TraCuu1;
    }
}