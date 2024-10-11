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
    public partial class frm_SinhVien : Form
    {
        public frm_SinhVien()
        {
            InitializeComponent();
        }
        LOPDUNGCHUNG lopchung = new LOPDUNGCHUNG();
        private void frm_SinhVien_Load(object sender, EventArgs e)
        {
            loadSinhVien();
            LoadKhoa();
        }
        public void loadSinhVien()
        {
            string sql = "Select * from SINHVIEN";
            data_SinhVien.DataSource = lopchung.LoadDL(sql);
        }
        public void LoadKhoa()
        {
            string sql = "Select * from KHOA";
            cb_Khoa.DataSource = lopchung.LoadDL(sql);
            cb_Khoa.ValueMember = "MaKhoa";
            cb_Khoa.DisplayMember = "TenKhoa";
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string sql = "Insert Into SINHVIEN VALUES ('" + txt_MaSV.Text + "',N'" + txt_HoTen.Text + "',N'" + txt_DiaChi.Text + "',convert(datetime,'" + dt_NgaySinh.Text + "',103),N'" + cb_Khoa.SelectedValue + "',N'" + txt_Lop.Text + "')";
            int kq = lopchung.ThemSuaXoa(sql);
            if (kq >= 1) MessageBox.Show("Thêm mới sinh viên thành công");
            else MessageBox.Show("Thêm mới sinh viên Thất bại");
            loadSinhVien();
            LoadKhoa();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string sql = "Update SINHVIEN SET HoTen=N'" + txt_HoTen.Text + "',diachi=N'" + txt_DiaChi.Text + "',ngaysinh = convert(datetime,'" + dt_NgaySinh.Text + "',103),TenKhoa = N'" + cb_Khoa.SelectedValue + "',lop = N'" + txt_Lop.Text + "'  WHERE MaSV = N'" + txt_MaSV.Text + "'";

            int kq = lopchung.ThemSuaXoa(sql);
            if (kq >= 1)
            {
                MessageBox.Show("Sửa sinh viên Thành Công");
            }
            else MessageBox.Show("Sửa sinh viên Thất Bại");
            loadSinhVien();
            LoadKhoa();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string sql = "Delete SINHVIEN where MaSV = '" + txt_MaSV.Text + "'";
            int kq = lopchung.ThemSuaXoa(sql);
            if (kq >= 1) MessageBox.Show("Xóa sinh viên Thành Công");
            else MessageBox.Show("Xóa sinh viên Thất Bại");
            loadSinhVien();
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
        private void data_SinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaSV.Text = data_SinhVien.CurrentRow.Cells[0].Value.ToString();
            txt_HoTen.Text = data_SinhVien.CurrentRow.Cells["HoTen"].Value.ToString();
            txt_DiaChi.Text = data_SinhVien.CurrentRow.Cells["DiaChi"].Value.ToString();
            dt_NgaySinh.Text = data_SinhVien.CurrentRow.Cells["NgaySinh"].Value.ToString();
            cb_Khoa.SelectedValue = data_SinhVien.CurrentRow.Cells["TenKhoa"].Value.ToString();
            txt_Lop.Text = data_SinhVien.CurrentRow.Cells["Lop"].Value.ToString();   
        }  
    }
}
