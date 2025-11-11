using DevExpress.XtraBars;
using QLĐA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_QLDA
{
    public partial class frmDangNhap : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
         

        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void btnTraCuuGiangVien_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnTraCuuDoAn_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
        {

        }

    

        private void barClock_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            barTimer.Caption = System.DateTime.Now.ToString();
        }

        private void barTimer_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_ItemClick_2(object sender, ItemClickEventArgs e)
        {
            using (frmLoginPopUp frm = new frmLoginPopUp())
            {
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }

        private void ribbonStatusBar_Click(object sender, EventArgs e)
        {

        }

        private void btnTraCuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (frmTraCuu frm = new frmTraCuu())
            {
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }
    }
}