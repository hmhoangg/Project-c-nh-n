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
    public partial class frm_DangNhap : Form
    {
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void frm_DangNhap_Load(object sender, EventArgs e)
        {

        }
        int dem = 0;
        LOPDUNGCHUNG lopchung = new LOPDUNGCHUNG();
        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string sql = "Select COUNT (*) from THONGTINTAIKHOAN where TenDangNhap = '" + txt_DangNhap.Text + "' and MatKhau = '" + txt_MatKhau.Text + "'";
            int kq = (int)lopchung.ExecuteScalar(sql);
            if (kq >= 1)
            {
                MessageBox.Show(" Đăng Nhập Thành Công");
                frm_Main pt = new frm_Main();
                pt.Show();
            }
            else
            {
                dem++;
                MessageBox.Show(" Bạn đã nhập sai " + dem.ToString() + " Lần ");
                if (dem == 3) Application.Exit();
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {

        }
    }
}
