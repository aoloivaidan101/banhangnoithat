using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoiThatNhuanHuong.UserControls.ThongTin
{
    public partial class UCNhanVien : UserControl
    {
        public UCNhanVien()
        {
            InitializeComponent();
        }

        private void UCNhanVien_Load(object sender, EventArgs e)
        {
            BatDau();
            // combobox
            cbbChucVu.DataSource = SQL_DanhMuc.Display_ChucVu();
            cbbChucVu.DisplayMember = "MaCV";
            cbbChucVu.ValueMember = "TenCV";
        }

        void display()
        {
            gridControl1.DataSource = SQL_ThongTin.Display_NhanVien();
            fixHeaderName();
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
            txtMaNV.Enabled = false;
            txtTenNV.Enabled = false;
            cbbChucVu.Enabled = false;
            txtSDT.Enabled = false;
            txtEmail.Enabled = false;
            txtDiaChi.Enabled = false;
            rdoNam.Enabled = false;
            rdoNu.Enabled = false;
            dpkNgaySinh.Enabled = false;
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            // Data table
            display();
            // Bắt lỗi 
            errorProvider1.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            chucnang = 1;
            // button
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            // text
            txtMaNV.Enabled = true;
            txtTenNV.Enabled = true;
            cbbChucVu.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
            txtDiaChi.Enabled = true;
            rdoNam.Enabled = true;
            rdoNu.Enabled = true;
            dpkNgaySinh.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            chucnang = 2;
            // button
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            // text
            txtTenNV.Enabled = true;
            cbbChucVu.Enabled = true;
            rdoNam.Enabled = true;
            rdoNu.Enabled = true;
            dpkNgaySinh.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
            txtDiaChi.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Thông Báo", MessageBoxButtons.YesNo))
            {
                SQL_ThongTin.Delete_NhanVien(txtMaNV.Text);
                BatDau();
            }
            // else chưa viết
        }

        void fixHeaderName()
        {
            gridView1.Columns[0].Caption = "Mã nhân viên";
            gridView1.Columns[1].Caption = "Tên Nhân Viên";
            gridView1.Columns[2].Caption = "Chức Vụ";
            gridView1.Columns[3].Caption = "Giới Tính";
            gridView1.Columns[4].Caption = "Ngày Sinh";
            gridView1.Columns[5].Caption = "Số Điện Thoại";
            gridView1.Columns[6].Caption = "Email";
            gridView1.Columns[7].Caption = "Địa Chỉ";

        }
        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            txtMaNV.Text = gridView1.GetRowCellValue(e.RowHandle, "MaNV").ToString();
            txtTenNV.Text = gridView1.GetRowCellValue(e.RowHandle, "TenNV").ToString();
            cbbChucVu.Text = gridView1.GetRowCellValue(e.RowHandle, "TenCV").ToString();
            if (gridView1.GetRowCellValue(e.RowHandle, "GioiTinh").ToString() == "Nam")
                rdoNam.Checked = true;
            if (gridView1.GetRowCellValue(e.RowHandle, "GioiTinh").ToString() == "Nữ")
                rdoNu.Checked = true;
            dpkNgaySinh.Text = gridView1.GetRowCellValue(e.RowHandle, "NgaySinh").ToString();
            txtSDT.Text = gridView1.GetRowCellValue(e.RowHandle, "SDTNV").ToString();
            txtEmail.Text = gridView1.GetRowCellValue(e.RowHandle, "Email").ToString();
            txtDiaChi.Text = gridView1.GetRowCellValue(e.RowHandle, "DiaChi").ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            BatDau();
        }

        DataTable NhanVien = new DataTable();
        public bool checkma()
        {
            NhanVien = SQL_ThongTin.Display_NhanVien();
            bool check = false; // không trùng
            for (int i = 0; i < NhanVien.Rows.Count; i++)
                if (txtMaNV.Text == NhanVien.Rows[i][0].ToString())
                {
                    check = true;   // trùng mã
                    break;
                }
            return check;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtMaNV.Text == "" || txtTenNV.Text == "" || (rdoNam.Checked == false && rdoNu.Checked==false)  || txtEmail.Text == "" || txtSDT.Text == "" || txtDiaChi.Text=="")
            {
                MessageBox.Show("Dữ liệu chưa đủ.", "Thông Báo");
                // bắt lỗi
                errorProvider1.SetError(txtMaNV, "Chưa điền mã nhân viên");
                errorProvider1.SetError(txtTenNV, "Chưa điền tên nhân viên");       
                if (rdoNam.Checked == false && rdoNu.Checked == false)
                    errorProvider1.SetError(rdoNu, "Chưa chọn giới tính");
                errorProvider1.SetError(txtSDT, "Chưa điền SĐT");
                errorProvider1.SetError(txtDiaChi, "Chưa điền địa chỉ");
                errorProvider1.SetError(txtEmail, "Chưa điền Email");
            }
            else
            {
                if (chucnang == 1) // Nút thêm
                {
                    if (checkma() == true)
                    {
                        MessageBox.Show("Mã Sản Phẩm đã tồn tại.", "Thông Báo");
                        //bắt lỗi
                        errorProvider1.SetError(txtMaNV, "Mã Sản Phẩm đã tồn tại.");
                    }

                    else
                    {
                        SQL_ThongTin.Add_NhanVien(txtMaNV.Text, txtTenNV.Text, cbbChucVu.SelectedValue.ToString(), radio_To_string(), dpkNgaySinh.Value.ToString("yyyy-MM-dd"), txtSDT.Text, txtDiaChi.Text,txtEmail.Text);
                        BatDau();
                    }
                }
                if (chucnang == 2)// nút sửa
                {
                    SQL_ThongTin.Edit__NhanVien(txtMaNV.Text, txtTenNV.Text, cbbChucVu.SelectedValue.ToString(), radio_To_string(), dpkNgaySinh.Value.ToString("yyyy-MM-dd"), txtSDT.Text, txtDiaChi.Text, txtEmail.Text);
                    BatDau();
                }

            }
        }
        public string radio_To_string()
        {
            return (rdoNam.Checked == true) ? "true" : "false";
        } // check radio -> string      : gọi hàm khi thêm/sửa
    }
}
