using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoMinhHoang_DoAnCaNhan
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frm_SinhVien"] == null)
            {
                frm_SinhVien sv = new frm_SinhVien();
                sv.MdiParent = this;
                sv.Show();
            }
            else Application.OpenForms["frm_SinhVien"].Activate();
        }

        private void khoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frm_Khoa"] == null)
            {
                frm_Khoa sv = new frm_Khoa();
                sv.MdiParent = this;
                sv.Show();
            }
            else Application.OpenForms["frm_Khoa"].Activate();
        }

        private void mônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frm_MonHoc"] == null)
            {
                frm_MonHoc sv = new frm_MonHoc();
                sv.MdiParent = this;
                sv.Show();
            }
            else Application.OpenForms["frm_MonHoc"].Activate();
        }
    }
}
  