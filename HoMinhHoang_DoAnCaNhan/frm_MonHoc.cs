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
    public partial class frm_MonHoc : Form
    {
        public frm_MonHoc()
        {
            InitializeComponent();
        }
        LOPDUNGCHUNG lopchung = new LOPDUNGCHUNG();
        private void frm_MonHoc_Load(object sender, EventArgs e)
        {
            loadMonHoc();
        }
        public void loadMonHoc()
        {
            string sql = "Select * from MONHOC";
            dt_MonHoc.DataSource = lopchung.LoadDL(sql);
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string sql = "Insert Into MONHOC VALUES ('" + txt_MaMonHoc.Text + "', N'" + txt_TenMonHoc.Text + "', N'" + txt_SoTinChi.Text + "', N'" + txt_GhiChu.Text + "')";
            int kq = lopchung.ThemSuaXoa(sql);
            if (kq >= 1) MessageBox.Show("Thêm mới môn học thành công");
            else MessageBox.Show("Thêm mới môn học Thất bại");
            loadMonHoc();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string sql = "Update MONHOC set TenMonHoc = N'" + txt_TenMonHoc.Text + "', SoTC = N'" + txt_SoTinChi.Text + "', GhiChu = N'" + txt_GhiChu.Text + "'where MaMonHoc = N'" + txt_MaMonHoc.Text + "'";
            int kq = lopchung.ThemSuaXoa(sql);
            if (kq >= 1) MessageBox.Show("Sửa môn học Thành Công");
            else MessageBox.Show("Sửa môn học Thất Bại");
            loadMonHoc();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string sql = "Delete MONHOC where MaMonHoc = '" + txt_MaMonHoc.Text + "'";
            int kq = lopchung.ThemSuaXoa(sql);
            if (kq >= 1) MessageBox.Show("Xóa môn học Thành Công");
            else MessageBox.Show("Xóa môn học Thất Bại");
            loadMonHoc();
        }
        private void btn_Dong_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn thật sự có muốn thoát hay không", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void dt_MonHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaMonHoc.Text = dt_MonHoc.CurrentRow.Cells[0].Value.ToString();
            txt_TenMonHoc.Text = dt_MonHoc.CurrentRow.Cells["TenMonHoc"].Value.ToString();
            txt_SoTinChi.Text = dt_MonHoc.CurrentRow.Cells["SoTC"].Value.ToString();
            txt_GhiChu.Text = dt_MonHoc.CurrentRow.Cells["GhiChu"].Value.ToString();
        }
    }
}
