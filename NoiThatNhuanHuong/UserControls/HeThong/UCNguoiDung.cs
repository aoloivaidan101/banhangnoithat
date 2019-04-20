using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoiThatNhuanHuong.UserControls.HeThong
{
    public partial class UCNguoiDung : UserControl
    {
        public UCNguoiDung()
        {
            InitializeComponent();
        }

        void display()
        {
            gridControl1.DataSource = SQL_HeThong.Display_NguoiDung();
            FixNColumnNames();
        }
        private void UCNguoiDung_Load(object sender, EventArgs e)
        {
            BatDau();         
        }

        int chucnang;
        void BatDau()
        {
            chucnang = 0;
            // button
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            // Text
            txtMaNguoiDung.Enabled = false;
            txtMatKhau.Enabled = false;
            txtHoTen.Enabled = false;
            txtTenDangNhap.Enabled = false;


            txtMaNguoiDung.Text = "";
            txtMatKhau.Text = "";
            txtHoTen.Text = "";
            txtTenDangNhap.Text = "";


            // Data table
            display();
            // Bắt lỗi
            errorProvider1.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BatDau();
            chucnang = 1;
            // button
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            // text
            txtMatKhau.Enabled = true;
            txtHoTen.Enabled = true;
            txtTenDangNhap.Enabled = true;          
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            BatDau();
            chucnang = 2;
            // button
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            // text
            txtMatKhau.Enabled = true;
            txtHoTen.Enabled = true;
            txtTenDangNhap.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Thông Báo", MessageBoxButtons.YesNo))
            {
                SQL_HeThong.Delete_Nguoidung(int.Parse(txtMaNguoiDung.Text));
                BatDau();
                // xóa phân quyền
            }
            
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            txtMaNguoiDung.Text = gridView1.GetRowCellValue(e.RowHandle, "MaNguoiDung").ToString();
            txtHoTen.Text = gridView1.GetRowCellValue(e.RowHandle, "HoTen").ToString();
            txtTenDangNhap.Text = gridView1.GetRowCellValue(e.RowHandle, "TenDangNhap").ToString();
            txtMatKhau.Text = gridView1.GetRowCellValue(e.RowHandle, "MatKhau").ToString();      
        }
        public void FixNColumnNames()
        {
            gridView1.Columns[0].Caption = "Mã người dùng";
            gridView1.Columns[1].Caption = "Họ tên";
            gridView1.Columns[2].Caption = "Tên đăng nhập";
            gridView1.Columns[3].Caption = "Mật khẩu";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            BatDau();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtMaNguoiDung.Text == "" || txtHoTen.Text==""||txtTenDangNhap.Text==""|| txtMatKhau.Text == "")
            {
                MessageBox.Show("Dữ liệu chưa đủ.", "Thông Báo");
                // bắt lỗi
                errorProvider1.SetError(txtMaNguoiDung, "Chưa điền mã người dùng");
                errorProvider1.SetError(txtMatKhau, "Chưa điền mật khẩu");            
            }
            else
            {
                if (chucnang == 1) // Nút thêm
                {                
                        SQL_HeThong.Add_NguoiDung(txtHoTen.Text,txtTenDangNhap.Text, txtMatKhau.Text);
                        SQL_HeThong.Add_PhanQuyen(int.Parse(txtMaNguoiDung.Text),false,false,false,false,false,false,false);
                        BatDau();
                }
                if (chucnang == 2)// nút sửa
                {
                    SQL_HeThong.Edit__NguoiDung(int.Parse(txtMaNguoiDung.Text), txtHoTen.Text,txtTenDangNhap.Text, txtMatKhau.Text);
                    BatDau();
                }

            }
        }

       

       
    }
}
