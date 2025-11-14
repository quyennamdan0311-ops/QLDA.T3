using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLĐA
{
    public partial class Manhinhchinh : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public Manhinhchinh()
        {
            InitializeComponent();
        }

        // Method để load UserControl vào container
        private void LoadUserControl(UserControl userControl)
        {
            
            fluentDesignFormContainer1.Controls.Clear();

            userControl.Dock = DockStyle.Fill;

          
            fluentDesignFormContainer1.Controls.Add(userControl);

            
            userControl.BringToFront();
        }

        private void fluentDesignFormContainer1_Click(object sender, EventArgs e)
        {

        }

        private void barStaticItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            
            UC_TraCuu ucTraCuu = new UC_TraCuu();
            LoadUserControl(ucTraCuu);
        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {

        }

        private void btnQuanLyThongTinSinhVien_Click(object sender, EventArgs e)
        {
            UC_CapNhatSinhVien uC_CapNhatSinhVien = new UC_CapNhatSinhVien();
            LoadUserControl(uC_CapNhatSinhVien);
        }

        private void btnQuanLyThongTinGV_Click(object sender, EventArgs e)
        {
            UC_CapNhatGiangVien uC_CapNhatGiangVien = new UC_CapNhatGiangVien();
            LoadUserControl(uC_CapNhatGiangVien);
        }
    }
}
