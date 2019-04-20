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
    public partial class UCNhaCungCap : UserControl
    {
        public UCNhaCungCap()
        {
            InitializeComponent();
        }

        private void UCNhaCungCap_Load(object sender, EventArgs e)
        {
            BatDau();
        }

        void display()
        {
            gridControl1.DataSource = SQL_ThongTin.Display_NCC();
            fixHeaderName();
        }
        void fixHeaderName()
        {
            gridView1.Columns[0].Caption = "Mã nhà cung cấp";
            gridView1.Columns[1].Caption = "Tên nhà cung cấp";
            gridView1.Columns[2].Caption = "Địa chỉ";
            gridView1.Columns[3].Caption = "SĐT";
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
            txtMaNCC.Enabled = false;
            txtTenNCC.Enabled = false;
            txtSDT.Enabled = false;
            txtEmail.Enabled = false;
            txtDiaChi.Enabled = false;
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
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
            txtMaNCC.Enabled = true;
            txtTenNCC.Enabled = true;
            txtEmail.Enabled = true;
            txtSDT.Enabled = true;
            txtDiaChi.Enabled = true;
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
            txtMaNCC.Enabled = false;
            txtTenNCC.Enabled = true;
            txtEmail.Enabled = true;
            txtSDT.Enabled = true;
            txtDiaChi.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Thông Báo", MessageBoxButtons.YesNo))
            {
                SQL_ThongTin.Delete_NCC(txtMaNCC.Text);
                BatDau();
            }
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            txtMaNCC.Text = gridView1.GetRowCellValue(e.RowHandle, "MaNCC").ToString();
            txtTenNCC.Text = gridView1.GetRowCellValue(e.RowHandle, "TenNCC").ToString();
            txtSDT.Text = gridView1.GetRowCellValue(e.RowHandle, "SDTNCC").ToString();
            txtEmail.Text = gridView1.GetRowCellValue(e.RowHandle, "Email").ToString();
            txtDiaChi.Text = gridView1.GetRowCellValue(e.RowHandle, "DiaChi").ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            BatDau();
        }

        DataTable NhaCungCap = new DataTable();
        public bool checkma()
        {
            NhaCungCap = SQL_ThongTin.Display_NCC();
            bool check = false; // không trùng
            for (int i = 0; i < NhaCungCap.Rows.Count; i++)
                if (txtMaNCC.Text == NhaCungCap.Rows[i][0].ToString())
                {
                    check = true;   // trùng mã
                    break;
                }
            return check;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtMaNCC.Text == "" || txtTenNCC.Text == "" || txtSDT.Text == "" || txtEmail.Text == "" || txtDiaChi.Text == "")
            {
                MessageBox.Show("Dữ liệu chưa đủ.", "Thông Báo");
                // bắt lỗi         
                errorProvider1.SetError(txtMaNCC, "Chưa điền mã nhà cung cấp");
                errorProvider1.SetError(txtTenNCC, "Chưa điền tên nhà cung cấp");
                errorProvider1.SetError(txtSDT, "Chưa điền SĐT");
                errorProvider1.SetError(txtEmail, "Chưa điền email");
                errorProvider1.SetError(txtDiaChi, "Chưa điền địa chỉ");
            }
            else
            {
                if (chucnang == 1) // Nút thêm
                {
                    if (checkma() == true)
                    {
                        MessageBox.Show("Mã nhà cùng cấp đã tồn tại.", "Thông Báo");
                        //bắt lỗi
                        errorProvider1.SetError(txtMaNCC, "Mã nhà cùng cấp đã tồn tại.");
                    }
                    else
                    {
                        SQL_ThongTin.Add_NCC(txtMaNCC.Text, txtSDT.Text, txtTenNCC.Text, txtDiaChi.Text, txtEmail.Text);
                        BatDau();
                    }
                }
                if (chucnang == 2)// nút sửa
                {
                    SQL_ThongTin.Edit__NCC(txtMaNCC.Text, txtSDT.Text, txtTenNCC.Text, txtDiaChi.Text, txtEmail.Text);
                    BatDau();
                }

            }
        }
    }
}
