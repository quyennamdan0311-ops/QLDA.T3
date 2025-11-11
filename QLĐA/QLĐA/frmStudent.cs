using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLĐA
{
    public partial class frmStudent : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmStudent()
        {
            InitializeComponent();
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Đăng xuất khỏi phiên làm việc?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                using (var login = new frmLoginPopUp()) login.ShowDialog();
                this.Close(); // đóng form hiện tại sau khi login form xong
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            barStaticItem2.Caption = System.DateTime.Now.ToString(); 
        }

        private void barStaticItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
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