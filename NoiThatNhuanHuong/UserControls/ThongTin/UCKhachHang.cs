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
    public partial class UCKhachHang : UserControl
    {
        public UCKhachHang()
        {
            InitializeComponent();
        }

        private void UCKhachHang_Load(object sender, EventArgs e)
        {
            BatDau();
        }

        void display()
        {
            gridControl1.DataSource = SQL_ThongTin.Display_KhachHang();
            fixHeaderName();
        }
        void fixHeaderName()
        {
            gridView1.Columns[0].Caption = "Mã khách hàng";
            gridView1.Columns[1].Caption = "SĐT";
            gridView1.Columns[2].Caption = "Tên khách hàng";
            gridView1.Columns[3].Caption = "Địa chỉ";
            gridView1.Columns[4].Caption = "Email";
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
            txtMaKhachHang.Enabled = false;
            txtTenKhachHang.Enabled = false;
            txtSDT.Enabled = false;
            txtEmail.Enabled = false;
            txtDiaChi.Enabled = false;
            txtMaKhachHang.Text = "";
            txtTenKhachHang.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
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
            txtMaKhachHang.Enabled = false;
            txtTenKhachHang.Enabled = true;
            txtEmail.Enabled = true;
            txtSDT.Enabled = true;
            txtDiaChi.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           // chucnang = 2;
            // button
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            // text
            txtMaKhachHang.Enabled = false;
            txtTenKhachHang.Enabled = true;
            txtEmail.Enabled = true;
            txtSDT.Enabled = true;
            txtDiaChi.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Thông Báo", MessageBoxButtons.YesNo))
            {
                SQL_ThongTin.Delete_KhachHang(txtMaKhachHang.Text);
                BatDau();
            }
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            txtMaKhachHang.Text = gridView1.GetRowCellValue(e.RowHandle, "MaKH").ToString();
            txtTenKhachHang.Text = gridView1.GetRowCellValue(e.RowHandle, "TenKH").ToString();
            txtSDT.Text = gridView1.GetRowCellValue(e.RowHandle, "SDT").ToString();
            txtEmail.Text = gridView1.GetRowCellValue(e.RowHandle, "Email").ToString();
            txtDiaChi.Text = gridView1.GetRowCellValue(e.RowHandle, "DiaChi").ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            BatDau();
        }

       
        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtTenKhachHang.Text == "" || txtSDT.Text == "" || txtEmail.Text =="" || txtDiaChi.Text=="")
            {
                MessageBox.Show("Dữ liệu chưa đủ.", "Thông Báo");
                // bắt lỗi               
                if (txtTenKhachHang.Text == "") errorProvider1.SetError(txtTenKhachHang, "Chưa điền tên Khách Hàng");
                if (txtSDT.Text == "") errorProvider1.SetError(txtSDT, "Chưa điền SĐT");
                if (txtEmail.Text == "") errorProvider1.SetError(txtEmail, "Chưa điền email");
                if (txtDiaChi.Text == "") errorProvider1.SetError(txtDiaChi, "Chưa điền địa chỉ");
            }
            else
            {
                if (chucnang == 1) // Nút thêm
                {
                    {
                        SQL_ThongTin.Add_KhachHang(txtTenKhachHang.Text, txtSDT.Text,txtDiaChi.Text,txtEmail.Text);
                        BatDau();
                    }
                }
                if (chucnang == 2)// nút sửa
                {
                    SQL_ThongTin.Edit__KhachHang(txtMaKhachHang.Text, txtTenKhachHang.Text, txtSDT.Text, txtDiaChi.Text, txtEmail.Text);
                    BatDau();
                }

            }
        }
    }
}
