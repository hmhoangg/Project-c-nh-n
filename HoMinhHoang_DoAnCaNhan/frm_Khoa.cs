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
    public partial class frm_Khoa : Form
    {
        public frm_Khoa()
        {
            InitializeComponent();
        }
        LOPDUNGCHUNG lopchung = new LOPDUNGCHUNG();
        private void frm_Khoa_Load(object sender, EventArgs e)
        {
            LoadKhoa();
        }
        public void LoadKhoa()
        {
            string sql = "Select * from KHOA";
            data_Khoa.DataSource = lopchung.LoadDL(sql);
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string sql = "Insert Into KHOA VALUES ('" + txt_MaKhoa.Text + "', N'" + txt_TenKhoa.Text + "', N'" + txt_GhiChu.Text + "')";
            int kq = lopchung.ThemSuaXoa(sql);
            if (kq >= 1) MessageBox.Show("Thêm mới khoa thành công");
            else MessageBox.Show("Thêm mới khoa Thất bại");
            LoadKhoa();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string sql = "Update KHOA set TenKhoa = N'" + txt_TenKhoa.Text + "', GhiChu = N'" + txt_GhiChu.Text + "'where MaKhoa = N'" + txt_MaKhoa.Text + "'";
            int kq = lopchung.ThemSuaXoa(sql);
            if (kq >= 1) MessageBox.Show("Sửa Khoa Thành Công");
            else MessageBox.Show("Sửa Khoa Thất Bại");
            LoadKhoa();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string sql = "Delete KHOA where MaKhoa = '" + txt_MaKhoa.Text + "'";
            int kq = lopchung.ThemSuaXoa(sql);
            if (kq >= 1) MessageBox.Show("Xóa khoa Thành Công");
            else MessageBox.Show("Xóa khoa Thất Bại");
            LoadKhoa();
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

        private void data_Khoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaKhoa.Text = data_Khoa.CurrentRow.Cells[0].Value.ToString();
            txt_TenKhoa.Text = data_Khoa.CurrentRow.Cells["TenKhoa"].Value.ToString();
            txt_GhiChu.Text = data_Khoa.CurrentRow.Cells["GhiChu"].Value.ToString();
        }
    }
}
