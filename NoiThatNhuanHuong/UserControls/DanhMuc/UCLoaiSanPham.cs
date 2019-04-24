using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoiThatNhuanHuong.UserControls.DanhMuc
{
    public partial class UCLoaiSanPham : UserControl
    {
        public UCLoaiSanPham()
        {
            InitializeComponent();
        }

        private void UCDanhMuc_Load(object sender, EventArgs e)
        {
            BatDau();           
        }

        void display()
        {
            gridControl1.DataSource = SQL_DanhMuc.Display_LoaiSanPham();
            FixNColumnNames();
            cbbVatLieu.DataSource = SQL_DanhMuc.Display_VatLieu();
            cbbVatLieu.DisplayMember = "TenVL";
            cbbVatLieu.ValueMember = "MaVL";
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
            txtMaLoaiSP.Enabled = false;
            txtTenLoaiSP.Enabled = false;
            cbbVatLieu.Enabled = false;
            txtMaLoaiSP.Text = "";
            txtTenLoaiSP.Text = "";
            cbbVatLieu.Text = "";
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
            txtMaLoaiSP.Enabled = true;
            txtTenLoaiSP.Enabled = true;
            cbbVatLieu.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
          //  BatDau();
            chucnang = 2;
            // button
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            // text
            txtTenLoaiSP.Enabled = true;
            cbbVatLieu.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Thông Báo", MessageBoxButtons.YesNo))
            {
                SQL_DanhMuc.Delete_LoaiSanPham(txtMaLoaiSP.Text);
                BatDau();
            }
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            txtMaLoaiSP.Text = gridView1.GetRowCellValue(e.RowHandle, "MaLoaiSP").ToString();
            txtTenLoaiSP.Text = gridView1.GetRowCellValue(e.RowHandle, "TenLoaiSP").ToString();
            cbbVatLieu.Text= gridView1.GetRowCellValue(e.RowHandle, "TenVL").ToString();
        }
        public void FixNColumnNames()
        {
            gridView1.Columns[0].Caption = "Mã loại sản phẩm";
            gridView1.Columns[1].Caption = "Tên loại sản phẩm";
            gridView1.Columns[2].Caption = "Vật Liệu";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            BatDau();
        }

        DataTable LoaiSanPham = new DataTable();
        public bool checkma()
        {
            LoaiSanPham = SQL_DanhMuc.Display_LoaiSanPham(); 
            bool check = false; // không trùng
            for (int i = 0; i < LoaiSanPham.Rows.Count; i++)
                if (txtMaLoaiSP.Text == LoaiSanPham.Rows[i][0].ToString())
                {
                    check = true;   // trùng mã
                    break;
                }
            return check;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtMaLoaiSP.Text == "" || txtTenLoaiSP.Text == "" || cbbVatLieu.Text == "")
            {
                MessageBox.Show("Dữ liệu chưa đủ.", "Thông Báo");
                // bắt lỗi
                if (txtMaLoaiSP.Text == "") errorProvider1.SetError(txtMaLoaiSP, "Chưa điền mã loại sản phẩm");
                if (txtTenLoaiSP.Text == "") errorProvider1.SetError(txtTenLoaiSP, "Chưa điền tên loại sản shẩm");
                if (cbbVatLieu.Text == "") errorProvider1.SetError(cbbVatLieu, "Chưa chọn vật liệu");
            }
            else
            {
                if (chucnang == 1) // Nút thêm
                {
                    if (checkma() == true)
                    {
                        MessageBox.Show("Mã Loại Sản Phẩm đã tồn tại.", "Thông Báo");
                        //bắt lỗi
                        errorProvider1.SetError(txtMaLoaiSP, "Mã Loại Sản Phẩm đã tồn tại.");
                    }

                    else
                    {
                        SQL_DanhMuc.Add_LoaiSanPham(txtMaLoaiSP.Text, txtTenLoaiSP.Text, cbbVatLieu.SelectedValue.ToString());
                        BatDau();
                    }
                }
                if (chucnang == 2)// nút sửa
                {
                    SQL_DanhMuc.Edit_LoaiSanPham(txtMaLoaiSP.Text, txtTenLoaiSP.Text, cbbVatLieu.SelectedValue.ToString());
                    BatDau();
                }

            }
        }
    
    }
}
