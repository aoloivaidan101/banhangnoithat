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
    public partial class UCSanPham : UserControl
    {
        public UCSanPham()
        {
            InitializeComponent();
        }

        private void UCSanPham_Load(object sender, EventArgs e)
        {
            BatDau();
            // combobox
            cbbLoaiSP.DataSource = SQL_DanhMuc.Display_LoaiSanPham();
            cbbLoaiSP.DisplayMember = "TenLoaiSP";
            cbbLoaiSP.ValueMember = "MaLoaiSP";
            cbbNCC.DataSource = SQL_ThongTin.Display_NCC();
            cbbNCC.DisplayMember = "TenNCC";
            cbbNCC.ValueMember = "MaNCC";
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
            txtMaSP.Enabled = false;
            txtTenSP.Enabled = false;
            cbbLoaiSP.Enabled = false;
            cbbNCC.Enabled = false;
            txtGiaNhap.Enabled = false;
            txtGiaBan.Enabled = false;
            txtMoTa.Enabled = false;
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtMoTa.Text = "";
            txtGiaNhap.Text = "";
            txtGiaBan.Text = "";
            // Data table
            gridControl1.DataSource = SQL_ThongTin.Display_SanPham();
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
            txtMaSP.Enabled = true;
            txtTenSP.Enabled = true;
            cbbLoaiSP.Enabled = true;
            cbbNCC.Enabled = true;
            txtGiaNhap.Enabled = true;
            txtGiaBan.Enabled = true;
            txtMoTa.Enabled = true;
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
            txtTenSP.Enabled = true;
            cbbLoaiSP.Enabled = true;
            cbbNCC.Enabled = true;
            txtGiaNhap.Enabled = true;
            txtGiaBan.Enabled = true;
            txtMoTa.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Thông Báo", MessageBoxButtons.YesNo))
            {
                SQL_ThongTin.Delete_SanPham(txtMaSP.Text);
                BatDau();
            }
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            txtMaSP.Text = gridView1.GetRowCellValue(e.RowHandle, "Mã Sản Phẩm").ToString();
            txtTenSP.Text = gridView1.GetRowCellValue(e.RowHandle, "Tên Sản Phẩm").ToString();
            cbbNCC.Text = gridView1.GetRowCellValue(e.RowHandle, "Nhà Cung Cấp").ToString();
            cbbLoaiSP.Text = gridView1.GetRowCellValue(e.RowHandle, "Loại Sản Phẩm").ToString();
            txtGiaNhap.Text = gridView1.GetRowCellValue(e.RowHandle, "Giá Nhập").ToString();
            txtGiaBan.Text = gridView1.GetRowCellValue(e.RowHandle, "Giá Bán").ToString();
            txtMoTa.Text = gridView1.GetRowCellValue(e.RowHandle, "Mô Tả").ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            BatDau();
        }

        DataTable SanPham = new DataTable();
        public bool checkma()
        {
            SanPham = SQL_ThongTin.Display_SanPham();
            bool check = false; // không trùng
            for (int i = 0; i < SanPham.Rows.Count; i++)
                if (txtMaSP.Text == SanPham.Rows[i][0].ToString())
                {
                    check = true;   // trùng mã
                    break;
                }
            return check;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtMaSP.Text == "" || txtTenSP.Text == "" ||  txtGiaBan.Text==""||txtGiaNhap.Text=="")
            {
                MessageBox.Show("Dữ liệu chưa đủ.", "Thông Báo");
                // bắt lỗi
                errorProvider1.SetError(txtMaSP, "Chưa điền mã sản phẩm");
                errorProvider1.SetError(txtTenSP, "Chưa điền tên sản phẩm");            
                errorProvider1.SetError(txtGiaNhap, "Chưa điền giá nhập");
                errorProvider1.SetError(txtGiaBan, "Chưa điền giá bán");
            }
            else
            {
                if (chucnang == 1) // Nút thêm
                {
                    if (checkma() == true)
                    {
                        MessageBox.Show("Mã Sản Phẩm đã tồn tại.", "Thông Báo");
                        //bắt lỗi
                        errorProvider1.SetError(txtMaSP, "Mã Sản Phẩm đã tồn tại.");
                    }

                    else
                    {
                        SQL_ThongTin.Add_SanPham(txtMaSP.Text, txtTenSP.Text, cbbLoaiSP.SelectedValue.ToString(),cbbNCC.SelectedValue.ToString(),decimal.Parse(txtGiaNhap.Text),decimal.Parse(txtGiaBan.Text),0,txtMoTa.Text);
                        BatDau();
                    }
                }
                if (chucnang == 2)// nút sửa
                {
                    SQL_ThongTin.Edit_SanPham(txtMaSP.Text, txtTenSP.Text, cbbLoaiSP.SelectedValue.ToString(), cbbNCC.SelectedValue.ToString(), decimal.Parse(txtGiaNhap.Text), decimal.Parse(txtGiaBan.Text), txtMoTa.Text);
                    BatDau();
                }

            }
        }
    }
}
